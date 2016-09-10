/*
 * Created by SharpDevelop.
 * User: codetronics
 * Date: 6/27/2016
 * Time: 1:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WiFiPlugPoints
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button SelectBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label SelectedNodeLbl;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Timer AutomationTimer;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox SchedulerEnCB;
		private System.Windows.Forms.CheckBox AutomationEnCB;
		private System.Windows.Forms.Timer OneSecondTimer;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.CheckBox DefaultSWStateCB;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.NumericUpDown TimeOutNUD;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
  		{
  			this.components = new System.ComponentModel.Container();
  			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
  			this.button1 = new System.Windows.Forms.Button();
  			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
  			this.timer1 = new System.Windows.Forms.Timer(this.components);
  			this.textBox1 = new System.Windows.Forms.TextBox();
  			this.comboBox1 = new System.Windows.Forms.ComboBox();
  			this.label1 = new System.Windows.Forms.Label();
  			this.SelectBtn = new System.Windows.Forms.Button();
  			this.label2 = new System.Windows.Forms.Label();
  			this.SelectedNodeLbl = new System.Windows.Forms.Label();
  			this.button2 = new System.Windows.Forms.Button();
  			this.button3 = new System.Windows.Forms.Button();
  			this.button6 = new System.Windows.Forms.Button();
  			this.AutomationTimer = new System.Windows.Forms.Timer(this.components);
  			this.tabControl1 = new System.Windows.Forms.TabControl();
  			this.tabPage1 = new System.Windows.Forms.TabPage();
  			this.checkBox1 = new System.Windows.Forms.CheckBox();
  			this.DefaultSWStateCB = new System.Windows.Forms.CheckBox();
  			this.radioButton2 = new System.Windows.Forms.RadioButton();
  			this.radioButton1 = new System.Windows.Forms.RadioButton();
  			this.SchedulerEnCB = new System.Windows.Forms.CheckBox();
  			this.label4 = new System.Windows.Forms.Label();
  			this.label3 = new System.Windows.Forms.Label();
  			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
  			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
  			this.tabPage2 = new System.Windows.Forms.TabPage();
  			this.TimeOutNUD = new System.Windows.Forms.NumericUpDown();
  			this.progressBar1 = new System.Windows.Forms.ProgressBar();
  			this.label6 = new System.Windows.Forms.Label();
  			this.label5 = new System.Windows.Forms.Label();
  			this.AutomationEnCB = new System.Windows.Forms.CheckBox();
  			this.OneSecondTimer = new System.Windows.Forms.Timer(this.components);
  			this.tabControl1.SuspendLayout();
  			this.tabPage1.SuspendLayout();
  			this.tabPage2.SuspendLayout();
  			((System.ComponentModel.ISupportInitialize)(this.TimeOutNUD)).BeginInit();
  			this.SuspendLayout();
  			// 
  			// button1
  			// 
  			this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.button1.Location = new System.Drawing.Point(274, 12);
  			this.button1.Name = "button1";
  			this.button1.Size = new System.Drawing.Size(65, 91);
  			this.button1.TabIndex = 0;
  			this.button1.Text = "Scan";
  			this.button1.UseVisualStyleBackColor = true;
  			this.button1.Click += new System.EventHandler(this.Button1Click);
  			// 
  			// notifyIcon1
  			// 
  			this.notifyIcon1.BalloonTipText = "Test";
  			this.notifyIcon1.BalloonTipTitle = "Wireless Plug Points App";
  			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
  			this.notifyIcon1.Text = "Wireless Plug Points App";
  			this.notifyIcon1.Visible = true;
  			this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1DoubleClick);
  			// 
  			// timer1
  			// 
  			this.timer1.Enabled = true;
  			this.timer1.Interval = 250;
  			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
  			// 
  			// textBox1
  			// 
  			this.textBox1.Location = new System.Drawing.Point(12, 12);
  			this.textBox1.Multiline = true;
  			this.textBox1.Name = "textBox1";
  			this.textBox1.Size = new System.Drawing.Size(256, 91);
  			this.textBox1.TabIndex = 1;
  			// 
  			// comboBox1
  			// 
  			this.comboBox1.FormattingEnabled = true;
  			this.comboBox1.Location = new System.Drawing.Point(106, 119);
  			this.comboBox1.Name = "comboBox1";
  			this.comboBox1.Size = new System.Drawing.Size(162, 21);
  			this.comboBox1.TabIndex = 2;
  			// 
  			// label1
  			// 
  			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.label1.Location = new System.Drawing.Point(12, 119);
  			this.label1.Name = "label1";
  			this.label1.Size = new System.Drawing.Size(88, 21);
  			this.label1.TabIndex = 3;
  			this.label1.Text = "Select Node:";
  			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
  			// 
  			// SelectBtn
  			// 
  			this.SelectBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.SelectBtn.Location = new System.Drawing.Point(274, 115);
  			this.SelectBtn.Name = "SelectBtn";
  			this.SelectBtn.Size = new System.Drawing.Size(65, 28);
  			this.SelectBtn.TabIndex = 4;
  			this.SelectBtn.Text = "Select";
  			this.SelectBtn.UseVisualStyleBackColor = true;
  			this.SelectBtn.Click += new System.EventHandler(this.SelectBtnClick);
  			// 
  			// label2
  			// 
  			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.label2.Location = new System.Drawing.Point(12, 389);
  			this.label2.Name = "label2";
  			this.label2.Size = new System.Drawing.Size(100, 23);
  			this.label2.TabIndex = 5;
  			this.label2.Text = "Selected Node:";
  			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
  			// 
  			// SelectedNodeLbl
  			// 
  			this.SelectedNodeLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.SelectedNodeLbl.Location = new System.Drawing.Point(115, 389);
  			this.SelectedNodeLbl.Name = "SelectedNodeLbl";
  			this.SelectedNodeLbl.Size = new System.Drawing.Size(100, 23);
  			this.SelectedNodeLbl.TabIndex = 6;
  			this.SelectedNodeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
  			// 
  			// button2
  			// 
  			this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.button2.Location = new System.Drawing.Point(12, 155);
  			this.button2.Name = "button2";
  			this.button2.Size = new System.Drawing.Size(157, 37);
  			this.button2.TabIndex = 7;
  			this.button2.Text = "SW 1 ON";
  			this.button2.UseVisualStyleBackColor = true;
  			this.button2.Click += new System.EventHandler(this.GPIOButtonClick);
  			// 
  			// button3
  			// 
  			this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.button3.Location = new System.Drawing.Point(175, 155);
  			this.button3.Name = "button3";
  			this.button3.Size = new System.Drawing.Size(160, 37);
  			this.button3.TabIndex = 8;
  			this.button3.Text = "SW 2 ON";
  			this.button3.UseVisualStyleBackColor = true;
  			this.button3.Click += new System.EventHandler(this.GPIOButtonClick);
  			// 
  			// button6
  			// 
  			this.button6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.button6.Location = new System.Drawing.Point(12, 198);
  			this.button6.Name = "button6";
  			this.button6.Size = new System.Drawing.Size(323, 36);
  			this.button6.TabIndex = 11;
  			this.button6.Text = "FOTA";
  			this.button6.UseVisualStyleBackColor = true;
  			this.button6.Click += new System.EventHandler(this.Button6Click);
  			// 
  			// AutomationTimer
  			// 
  			this.AutomationTimer.Enabled = true;
  			this.AutomationTimer.Interval = 1000;
  			this.AutomationTimer.Tick += new System.EventHandler(this.AutomationTimerTick);
  			// 
  			// tabControl1
  			// 
  			this.tabControl1.Controls.Add(this.tabPage1);
  			this.tabControl1.Controls.Add(this.tabPage2);
  			this.tabControl1.Location = new System.Drawing.Point(15, 240);
  			this.tabControl1.Name = "tabControl1";
  			this.tabControl1.SelectedIndex = 0;
  			this.tabControl1.Size = new System.Drawing.Size(320, 146);
  			this.tabControl1.TabIndex = 12;
  			// 
  			// tabPage1
  			// 
  			this.tabPage1.Controls.Add(this.checkBox1);
  			this.tabPage1.Controls.Add(this.DefaultSWStateCB);
  			this.tabPage1.Controls.Add(this.radioButton2);
  			this.tabPage1.Controls.Add(this.radioButton1);
  			this.tabPage1.Controls.Add(this.SchedulerEnCB);
  			this.tabPage1.Controls.Add(this.label4);
  			this.tabPage1.Controls.Add(this.label3);
  			this.tabPage1.Controls.Add(this.dateTimePicker2);
  			this.tabPage1.Controls.Add(this.dateTimePicker1);
  			this.tabPage1.Location = new System.Drawing.Point(4, 22);
  			this.tabPage1.Name = "tabPage1";
  			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
  			this.tabPage1.Size = new System.Drawing.Size(312, 120);
  			this.tabPage1.TabIndex = 0;
  			this.tabPage1.Text = "Timer";
  			this.tabPage1.UseVisualStyleBackColor = true;
  			// 
  			// checkBox1
  			// 
  			this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.checkBox1.Location = new System.Drawing.Point(48, 89);
  			this.checkBox1.Name = "checkBox1";
  			this.checkBox1.Size = new System.Drawing.Size(179, 24);
  			this.checkBox1.TabIndex = 19;
  			this.checkBox1.Text = "Do It Everyday ?";
  			this.checkBox1.UseVisualStyleBackColor = true;
  			// 
  			// DefaultSWStateCB
  			// 
  			this.DefaultSWStateCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.DefaultSWStateCB.Location = new System.Drawing.Point(233, 36);
  			this.DefaultSWStateCB.Name = "DefaultSWStateCB";
  			this.DefaultSWStateCB.Size = new System.Drawing.Size(60, 45);
  			this.DefaultSWStateCB.TabIndex = 18;
  			this.DefaultSWStateCB.Text = "OFF";
  			this.DefaultSWStateCB.UseVisualStyleBackColor = true;
  			// 
  			// radioButton2
  			// 
  			this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
  			this.radioButton2.Location = new System.Drawing.Point(189, 6);
  			this.radioButton2.Name = "radioButton2";
  			this.radioButton2.Size = new System.Drawing.Size(73, 24);
  			this.radioButton2.TabIndex = 17;
  			this.radioButton2.Text = "SW 2";
  			this.radioButton2.UseVisualStyleBackColor = true;
  			// 
  			// radioButton1
  			// 
  			this.radioButton1.Checked = true;
  			this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
  			this.radioButton1.Location = new System.Drawing.Point(123, 6);
  			this.radioButton1.Name = "radioButton1";
  			this.radioButton1.Size = new System.Drawing.Size(73, 24);
  			this.radioButton1.TabIndex = 16;
  			this.radioButton1.TabStop = true;
  			this.radioButton1.Text = "SW 1";
  			this.radioButton1.UseVisualStyleBackColor = true;
  			// 
  			// SchedulerEnCB
  			// 
  			this.SchedulerEnCB.Font = new System.Drawing.Font("Segoe UI", 9F);
  			this.SchedulerEnCB.Location = new System.Drawing.Point(13, 7);
  			this.SchedulerEnCB.Name = "SchedulerEnCB";
  			this.SchedulerEnCB.Size = new System.Drawing.Size(104, 24);
  			this.SchedulerEnCB.TabIndex = 15;
  			this.SchedulerEnCB.Text = "Enable Task ?";
  			this.SchedulerEnCB.UseVisualStyleBackColor = true;
  			// 
  			// label4
  			// 
  			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.label4.Location = new System.Drawing.Point(4, 62);
  			this.label4.Name = "label4";
  			this.label4.Size = new System.Drawing.Size(44, 20);
  			this.label4.TabIndex = 14;
  			this.label4.Text = "End:";
  			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
  			// 
  			// label3
  			// 
  			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.label3.Location = new System.Drawing.Point(4, 36);
  			this.label3.Name = "label3";
  			this.label3.Size = new System.Drawing.Size(44, 20);
  			this.label3.TabIndex = 13;
  			this.label3.Text = "Start:";
  			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
  			// 
  			// dateTimePicker2
  			// 
  			this.dateTimePicker2.CustomFormat = "ddd,MMM dd   hh:mm:ss tt";
  			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
  			this.dateTimePicker2.Location = new System.Drawing.Point(48, 62);
  			this.dateTimePicker2.Name = "dateTimePicker2";
  			this.dateTimePicker2.ShowUpDown = true;
  			this.dateTimePicker2.Size = new System.Drawing.Size(179, 20);
  			this.dateTimePicker2.TabIndex = 1;
  			// 
  			// dateTimePicker1
  			// 
  			this.dateTimePicker1.CustomFormat = "ddd,MMM dd   hh:mm:ss tt";
  			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
  			this.dateTimePicker1.Location = new System.Drawing.Point(48, 36);
  			this.dateTimePicker1.Name = "dateTimePicker1";
  			this.dateTimePicker1.ShowUpDown = true;
  			this.dateTimePicker1.Size = new System.Drawing.Size(179, 20);
  			this.dateTimePicker1.TabIndex = 0;
  			// 
  			// tabPage2
  			// 
  			this.tabPage2.Controls.Add(this.TimeOutNUD);
  			this.tabPage2.Controls.Add(this.progressBar1);
  			this.tabPage2.Controls.Add(this.label6);
  			this.tabPage2.Controls.Add(this.label5);
  			this.tabPage2.Controls.Add(this.AutomationEnCB);
  			this.tabPage2.Location = new System.Drawing.Point(4, 22);
  			this.tabPage2.Name = "tabPage2";
  			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
  			this.tabPage2.Size = new System.Drawing.Size(312, 120);
  			this.tabPage2.TabIndex = 1;
  			this.tabPage2.Text = "Automation";
  			this.tabPage2.UseVisualStyleBackColor = true;
  			// 
  			// TimeOutNUD
  			// 
  			this.TimeOutNUD.Location = new System.Drawing.Point(106, 41);
  			this.TimeOutNUD.Name = "TimeOutNUD";
  			this.TimeOutNUD.Size = new System.Drawing.Size(140, 20);
  			this.TimeOutNUD.TabIndex = 20;
  			this.TimeOutNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
  			this.TimeOutNUD.Value = new decimal(new int[] {
			60,
			0,
			0,
			0});
  			// 
  			// progressBar1
  			// 
  			this.progressBar1.Location = new System.Drawing.Point(77, 94);
  			this.progressBar1.Name = "progressBar1";
  			this.progressBar1.Size = new System.Drawing.Size(229, 20);
  			this.progressBar1.TabIndex = 19;
  			// 
  			// label6
  			// 
  			this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.label6.Location = new System.Drawing.Point(3, 91);
  			this.label6.Name = "label6";
  			this.label6.Size = new System.Drawing.Size(68, 23);
  			this.label6.TabIndex = 18;
  			this.label6.Text = "Progress:";
  			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
  			// 
  			// label5
  			// 
  			this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
  			this.label5.Location = new System.Drawing.Point(0, 37);
  			this.label5.Name = "label5";
  			this.label5.Size = new System.Drawing.Size(100, 23);
  			this.label5.TabIndex = 13;
  			this.label5.Text = "Timeout (secs):";
  			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
  			// 
  			// AutomationEnCB
  			// 
  			this.AutomationEnCB.Font = new System.Drawing.Font("Segoe UI", 9F);
  			this.AutomationEnCB.Location = new System.Drawing.Point(13, 7);
  			this.AutomationEnCB.Name = "AutomationEnCB";
  			this.AutomationEnCB.Size = new System.Drawing.Size(104, 24);
  			this.AutomationEnCB.TabIndex = 16;
  			this.AutomationEnCB.Text = "Enable Task ?";
  			this.AutomationEnCB.UseVisualStyleBackColor = true;
  			// 
  			// OneSecondTimer
  			// 
  			this.OneSecondTimer.Enabled = true;
  			this.OneSecondTimer.Interval = 1000;
  			this.OneSecondTimer.Tick += new System.EventHandler(this.OneSecondTimerTick);
  			// 
  			// MainForm
  			// 
  			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
  			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
  			this.ClientSize = new System.Drawing.Size(347, 421);
  			this.Controls.Add(this.tabControl1);
  			this.Controls.Add(this.button6);
  			this.Controls.Add(this.button3);
  			this.Controls.Add(this.button2);
  			this.Controls.Add(this.SelectedNodeLbl);
  			this.Controls.Add(this.label2);
  			this.Controls.Add(this.SelectBtn);
  			this.Controls.Add(this.label1);
  			this.Controls.Add(this.comboBox1);
  			this.Controls.Add(this.textBox1);
  			this.Controls.Add(this.button1);
  			this.Name = "MainForm";
  			this.Text = "Wireless Plug Points App";
  			this.Load += new System.EventHandler(this.MainFormLoad);
  			this.Resize += new System.EventHandler(this.MainFormResize);
  			this.tabControl1.ResumeLayout(false);
  			this.tabPage1.ResumeLayout(false);
  			this.tabPage2.ResumeLayout(false);
  			((System.ComponentModel.ISupportInitialize)(this.TimeOutNUD)).EndInit();
  			this.ResumeLayout(false);
  			this.PerformLayout();

  		}// 
	}
}
