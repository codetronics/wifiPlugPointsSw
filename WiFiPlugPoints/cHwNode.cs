/*
 * Created by SharpDevelop.
 * User: codetronics
 * Date: 6/30/2016
 * Time: 9:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace WiFiPlugPoints
{
	/// <summary>
	/// To create an object to represent each nodes. May need to work on this a bit as
	/// a node can be further classified as INPUT and OUTPUT.
	/// </summary>
	public class cHwNode
	{
		private byte[] _macAddr;
		private byte[] _ipAddr; // Ver. 4
		private Int16 _fwVer;
		
		// The constructor needs the bytes that will be received when the node
		// is sent a heartbeat message.
		public cHwNode(byte[] data)
		{
			// Decode the data. Assume the packet has been checked for error.
			// * [SIG. 1B][RSVD. 1B][FW. VER. 2B][IPv4 4B][MAC ADDR. 6B][CHKSUM 1B]
			_ipAddr = new byte[4];
			_macAddr = new byte[6];
			
			_fwVer = data[3]; // Lower byte
			_fwVer |= (Int16) (data[2] << 8); // Upper byte
			
			// IPv4
			for(int i = 0; i < 4; i++) _ipAddr[i] = data[i+4];

			// MAC Address
			for(int i = 0; i < 6; i++) _macAddr[i] = data[i+8];

		}
		
		public String GetMACAddr()
		{
			return BitConverter.ToString(_macAddr);
		}
		
		public String GetIPAddr()
		{
			return Convert.ToString(_ipAddr[0]) + "." + Convert.ToString(_ipAddr[1]) + "." + Convert.ToString(_ipAddr[2]) + "." + Convert.ToString(_ipAddr[3]);
		}
		
		public String GetFirmwareVersion()
		{
			return Convert.ToString(_fwVer);
		}
		
		// Sends command to the TCP Server at port 60000
		public bool SendCommand(byte cmd, byte[] data)
		{
            var client = new TcpClient();

            if (!client.ConnectAsync(GetIPAddr(), 60000).Wait(1000))
            {
                // connection failure
                Debug.WriteLine("[SendCommand] Failed to connect to the node (" + GetIPAddr() + ")");
                return false;
            }
            Stream stm = client.GetStream();
            try
            {
            	byte[] payload;
            	payload = new byte[3 + data.Length];
            	payload[0] = 0xAA; // Preamble
            	payload[1] = (byte) payload.Length;; // Length : Preamble + LENGTH + CMD + ...
            	payload[2] = cmd;
            	// Copy data into payload
            	for(int i = 0; i < data.Length; i++) payload[3+i] = data[i];
            	
                //stm.Write(payload, 0, payload.Length);
                stm.BeginWrite(payload, 0, payload.Length, new AsyncCallback(SendCommandCallback), client);

            }
            catch(Exception errr)
            {
            	Debug.WriteLine("[SendCommand] Failed to write to the node (" + GetIPAddr() + ")");
            	client.Close(); // Since write failed, then just close the tcp connection.
            	return false;
            }
            
            stm.Flush(); // At this point, the write should be done. Force the app to send it right now.
            return true;
		}


	    private static void SendCommandCallback(IAsyncResult ar) {
	        try {
	            // Get the TcpClient object.
	            TcpClient client = (TcpClient) ar.AsyncState;
				Stream stm = client.GetStream();
				// End the async write.
	            stm.EndWrite(ar);
	            Debug.WriteLine("[SendCommandCallback] Data sent!");
	
	            // Close the tcp connection.
	            client.Close();
	        } catch (Exception e) {
	            Debug.WriteLine("[SendCommandCallback] " + e.ToString());
	        }
		}		
		/* Specialised function to actuate GPIOs
		 * This function handles the communication protocol with the node.
		 * It accepts the gpio pin for which the state must be changed.
		 * Take note that this function does not know whether that particular
		 * gpio is output.
		 * 
		 * Recommended Arguments for ESP-01:
		 * gpio -> 0x01 for GPIO0 & 0x04 for GPIO2. These are the only outputs supported.
		 * state -> false for LOW and true for HIGH.
		 * You can actuate both gpios in one call since each gpio is represented by
		 * individual bit.
		 */ 
		public bool ActuateGPIO(byte gpio, bool state)
		{

            if(state) 
            	return SendCommand(0x01, new byte[]{gpio});
            else 
            	return SendCommand(0x02, new byte[]{gpio});
		}
	}
}
