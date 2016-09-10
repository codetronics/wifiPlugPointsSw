/*
 * Created by SharpDevelop.
 * User: codetronics
 * Date: 6/27/2016
 * Time: 1:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WiFiPlugPoints
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private const byte GPIO0 = 0x01;
		private const byte GPIO2 = 0x04;
		private const byte SW2 = GPIO2;
		private const byte SW1 = GPIO0;
		private bool updateScanData;
		private cHwNode selNode;
		private UdpClient hbClient;
		private IPEndPoint udp_ipe;
		private List<byte[]> hbNodeRespList;
		private List<cHwNode> nodeList;
		private bool fTimerStarted;
		private bool schTaskSwState;
		private UInt32 autoTaskCntDown;
		private static bool fUserDetected;

	    /// <summary>
	    /// 
	    /// </summary>
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			hbNodeRespList = new List<byte[]>();
			nodeList = new List<cHwNode>();
			
			udp_ipe = new IPEndPoint(IPAddress.Any, 6556);
			hbClient = new UdpClient(udp_ipe);	
            hbClient.BeginReceive(new AsyncCallback(ReceiveCallback), udp_ipe);
            
			selNode = null;
			updateScanData = false;
			fTimerStarted = false;
			fUserDetected = false;
			autoTaskCntDown = 0;
			schTaskSwState = true; // SW Off -> true
			
			// UI related
			TimeOutNUD.Maximum = Decimal.MaxValue;
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MainFormLoad(object sender, EventArgs e)
		{
			button1.PerformClick();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MainFormResize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.BalloonTipText = "is running in the background.";
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                ShowInTaskbar = false;
            }
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ar"></param>
		public void ReceiveCallback(IAsyncResult ar)
        {	
			IPEndPoint rem_ipe = new IPEndPoint(IPAddress.Any, 8875); // Just init. random data
			
			byte[] resp = hbClient.EndReceive(ar, ref rem_ipe); // remp_ipe will contain the originating host IP

			Debug.WriteLine("Received: " + BitConverter.ToString(resp) + " from IP: " + rem_ipe.Address.ToString());
			
			// Before we add, check the packet to ensure no error.
			// * [SIG. 1B][RSVD. 1B][FW. VER. 2B][IPv4 4B][MAC ADDR. 6B][CHKSUM 1B]
			int sum = 0;
			for(int i = 0; i < 14; i++)
           	{
				sum += resp[i];
           	}
			sum &= 0xFF;
			if(sum == resp[14])
			{
	        	if(hbNodeRespList.Any(x => x.SequenceEqual(resp)) == false)
	        	{
	        		// Before we add, check the packet to ensure no error.
	        		hbNodeRespList.Add(resp);
	        	}			
			}
			else
			{
				Debug.WriteLine("Checksum validation failed.");
			}
            updateScanData = true;
            // Check to make sure we are done. Else, collect more data.

            hbClient.BeginReceive(new AsyncCallback(ReceiveCallback), udp_ipe);
        }
		
		/// <summary>
		/// Handles the "Scan" button click event. It will initiate a node scan routine.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Button1Click(object sender, EventArgs e)
		{
			hbClient.Send(new byte[2] { 0xAA, 0x55 }, 2, "255.255.255.255", 60000);
            hbNodeRespList.Clear();
		}
	

		/// <summary>
		/// Selects the node in the Combobox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectBtnClick(object sender, EventArgs e)
		{
			Debug.WriteLine("Selected Node: " + comboBox1.Text);
			SelectedNodeLbl.ForeColor = Color.Red;
			foreach (var el in nodeList) 
			{
				if(el.GetIPAddr() == comboBox1.Text)
				{
					selNode = el;
					// We can start sending commands to the selected Node.
					SelectedNodeLbl.Text = el.GetIPAddr();
					
					var client = new TcpClient();
					// Half a second timeout. If still can't establish connection, then
					// the Node can be considered as dead (from app perspective).
		            if (!client.ConnectAsync(el.GetIPAddr(), 60000).Wait(500))
		            {
		                // Connection failure
		                SelectedNodeLbl.ForeColor = Color.Red;
		                Debug.WriteLine("Failed to connect to node(" + el.GetIPAddr() + ").");
		                return;
		            }
		            client.Close();
		            SelectedNodeLbl.ForeColor = Color.Green;
		            return;
				}
			}
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Timer1Tick(object sender, EventArgs e)
		{
			if(updateScanData)
			{
				updateScanData = false;
				// Clear the old list.
				nodeList.Clear();
				textBox1.Text = "";
				comboBox1.Items.Clear();
				for(int i = 0; i < hbNodeRespList.Count; i++)
				{
					// Process Data
					nodeList.Add(new cHwNode(hbNodeRespList[i]));
					textBox1.Text += "Node " + Convert.ToString(i+1) + ": " + nodeList[i].GetIPAddr() + " | " 
						+ nodeList[i].GetMACAddr() + " | " + nodeList[i].GetFirmwareVersion() + Environment.NewLine;
					comboBox1.Items.Add(nodeList[i].GetIPAddr());
				}
			}
		}
   
		/// <summary>
		/// Please refer to this site: http://www.pinvoke.net/default.aspx/user32.getlastinputinfo
		/// </summary>
		/// <returns></returns>
	    static uint GetLastInputTime()
    	{
	        uint idleTime = 0;
	        LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
	        lastInputInfo.cbSize = (uint)Marshal.SizeOf( lastInputInfo );
	        lastInputInfo.dwTime = 0;
	
	        uint envTicks = (uint)Environment.TickCount;
	
	        if ( GetLastInputInfo( ref lastInputInfo ) )
	        {
		        uint lastInputTick = lastInputInfo.dwTime;
		        idleTime = envTicks - lastInputTick;
        	}

        	return (( idleTime > 0 ) ? ( idleTime / 1000 ) : 0);
   	 	}
	       
	    /// <summary>
	    /// Handles the button click event.
	    /// </summary>
	    /// <param name="sender"></param>
	    /// <param name="e"></param>
		void GPIOButtonClick(object sender, EventArgs e)
		{
			Button obj = (Button) sender;
			
			if(selNode == null)
			{
				MessageBox.Show("Please select a node first.");
				return;
			}
			
			if(obj.Text == "SW 1 ON")
			{
				selNode.ActuateGPIO(GPIO0, false);
				obj.Text = "SW 1 OFF";
			}
			else if(obj.Text == "SW 1 OFF")
			{
				selNode.ActuateGPIO(GPIO0, true);
				obj.Text = "SW 1 ON";
			}
			else if(obj.Text == "SW 2 ON")
			{
				selNode.ActuateGPIO(GPIO2, false);
				obj.Text = "SW 2 OFF";
			}
			else if(obj.Text == "SW 2 OFF")
			{
				selNode.ActuateGPIO(GPIO2, true);
				obj.Text = "SW 2 ON";
			}
		}
		
		/// <summary>
		/// Clicking on this button will initiate the FOTA upgrade process.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Button6Click(object sender, EventArgs e)
		{
			DialogResult ret = MessageBox.Show("Are you sure you want to initiate FOTA upgrade?", "Confirmation", MessageBoxButtons.YesNo);
			if(ret == DialogResult.Yes)
			{ 
				MessageBox.Show("Okay, please ensure that you have disconnected appliances from the plug points before clicking OK.");
			} // End of ret == DialogResult.Yes

		}
		
		/// <summary>
		/// This is for Automation Task. It uses the low level mouse hook to decide
		/// if it needs to switch on or off a particular switch.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AutomationTimerTick(object sender, EventArgs e)
		{
			UInt32 timeout;
			
			timeout = (UInt32) TimeOutNUD.Value;

			if(AutomationEnCB.Checked)
			{
				var percent = ( ((float) GetLastInputTime() / ( (float) TimeOutNUD.Value ) ) ) * 100.0;
				if(((int) percent) <= 100) progressBar1.Value = (int) percent;
				
				if(GetLastInputTime() >= timeout)
				{
					// We have reached the specified duration for which no user activity is detected.
					// Switch OFF if is not OFF
					if(!schTaskSwState)
					{
						Debug.WriteLine("Timeout reached. Switch is OFF.");
						if(radioButton1.Checked) selNode.ActuateGPIO(SW2, true);
						else selNode.ActuateGPIO(SW1, true);
						schTaskSwState = true;
					}
				}
				else
				{
					// If it is OFF, we switch it ON.
					if(schTaskSwState)
					{
						Debug.WriteLine("Switch is ON.");
						if(radioButton1.Checked) selNode.ActuateGPIO(SW2, false);
						else selNode.ActuateGPIO(SW1, false);
						schTaskSwState = false;
					}
				}
			}
			else
			{
				schTaskSwState = true; // Reset
			}
		}

		/// <summary>
		/// This timer handles the Timer feature. I want to believe that there is a much more
		/// elegant way to achieve this but for now this serves the purpose (a note to myself).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OneSecondTimerTick(object sender, EventArgs e)
		{
			if(SchedulerEnCB.Checked) // if it is true, then perform the task
			{
				if (DateTime.Now >= dateTimePicker1.Value && DateTime.Now <= dateTimePicker2.Value) // Period
				{
					// Check whether we should On or Off the SW.
					// DefaultSWStateCB.Checked -> If it is checked, we have to send TRUE to OFF the SW.
					if(!fTimerStarted)
					{
						selNode.ActuateGPIO((radioButton1.Checked ? SW1 : SW2), DefaultSWStateCB.Checked);
						fTimerStarted = true;
					}
				}
				else
				{
					if(fTimerStarted)
					{
						// Send only once. Since it's using TCP, i doubt we might have issue.
						// The packet will be received by the Node. But, if the Node restarts, then it might
						// be out of sync with the app. Maybe will consider a feature to resend the packet
						// at a defined interval.
						selNode.ActuateGPIO((radioButton1.Checked ? SW1 : SW2), true);
						fTimerStarted = false;
						
						// Check if we need to repeat it everyday
						if(checkBox1.Checked)
						{
							dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
							dateTimePicker2.Value = dateTimePicker2.Value.AddDays(1);
						}
					}
				}
				
			}
			else
				fTimerStarted = false; // Reset
	
		}
			
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void NotifyIcon1DoubleClick(object sender, EventArgs e)
		{
	        WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
		}
	    
		
		
		[DllImport("user32.dll")]
		private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
		
	    [StructLayout( LayoutKind.Sequential )]
	    struct LASTINPUTINFO
	    {
	        public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));
	
	        [MarshalAs(UnmanagedType.U4)]
	        public UInt32 cbSize;    
	        [MarshalAs(UnmanagedType.U4)]
	        public UInt32 dwTime;
	    }	
	} // End of class MainForm
	


}
