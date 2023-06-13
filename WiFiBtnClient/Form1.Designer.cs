namespace WiFiBtnClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnConnectionClose = new Button();
            btnConnection = new Button();
            txtPort = new TextBox();
            label2 = new Label();
            txtIP = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtLog = new TextBox();
            groupBox2 = new GroupBox();
            btnWrite4Light3 = new Button();
            btnWrite3Light3 = new Button();
            btnWrite2Light3 = new Button();
            btnWrite1Light3 = new Button();
            btnWrite4Light1 = new Button();
            btnWrite3Light1 = new Button();
            btnWrite2Light1 = new Button();
            btnWrite1Light1 = new Button();
            btnWrite4Status1 = new Button();
            btnWrite3Status1 = new Button();
            btnWrite2Status1 = new Button();
            btnWrite1Status1 = new Button();
            btnWrite4Status0 = new Button();
            btnWrite3Status0 = new Button();
            btnWrite2Status0 = new Button();
            btnWrite1Status0 = new Button();
            label3 = new Label();
            btnWriteAddr = new Button();
            txtAddr = new TextBox();
            btnReadAddr = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnConnectionClose);
            panel1.Controls.Add(btnConnection);
            panel1.Controls.Add(txtPort);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtIP);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(711, 45);
            panel1.TabIndex = 0;
            // 
            // btnConnectionClose
            // 
            btnConnectionClose.Enabled = false;
            btnConnectionClose.Location = new Point(355, 12);
            btnConnectionClose.Name = "btnConnectionClose";
            btnConnectionClose.Size = new Size(73, 23);
            btnConnectionClose.TabIndex = 5;
            btnConnectionClose.Text = "断开连接";
            btnConnectionClose.UseVisualStyleBackColor = true;
            btnConnectionClose.Click += btnConnectionClose_Click;
            // 
            // btnConnection
            // 
            btnConnection.Location = new Point(276, 12);
            btnConnection.Name = "btnConnection";
            btnConnection.Size = new Size(73, 23);
            btnConnection.TabIndex = 4;
            btnConnection.Text = "连接";
            btnConnection.UseVisualStyleBackColor = true;
            btnConnection.Click += btnConnection_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(215, 12);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(55, 23);
            txtPort.TabIndex = 3;
            txtPort.Text = "8899";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 15);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(53, 12);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(118, 23);
            txtIP.TabIndex = 1;
            txtIP.Text = "10.76.92.136";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(19, 17);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtLog);
            groupBox1.Location = new Point(12, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 486);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "日志信息";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(6, 22);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Both;
            txtLog.Size = new Size(369, 458);
            txtLog.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnWrite4Light3);
            groupBox2.Controls.Add(btnWrite3Light3);
            groupBox2.Controls.Add(btnWrite2Light3);
            groupBox2.Controls.Add(btnWrite1Light3);
            groupBox2.Controls.Add(btnWrite4Light1);
            groupBox2.Controls.Add(btnWrite3Light1);
            groupBox2.Controls.Add(btnWrite2Light1);
            groupBox2.Controls.Add(btnWrite1Light1);
            groupBox2.Controls.Add(btnWrite4Status1);
            groupBox2.Controls.Add(btnWrite3Status1);
            groupBox2.Controls.Add(btnWrite2Status1);
            groupBox2.Controls.Add(btnWrite1Status1);
            groupBox2.Controls.Add(btnWrite4Status0);
            groupBox2.Controls.Add(btnWrite3Status0);
            groupBox2.Controls.Add(btnWrite2Status0);
            groupBox2.Controls.Add(btnWrite1Status0);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnWriteAddr);
            groupBox2.Controls.Add(txtAddr);
            groupBox2.Controls.Add(btnReadAddr);
            groupBox2.Location = new Point(399, 63);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(324, 486);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "控制";
            // 
            // btnWrite4Light3
            // 
            btnWrite4Light3.Location = new Point(163, 386);
            btnWrite4Light3.Name = "btnWrite4Light3";
            btnWrite4Light3.Size = new Size(151, 23);
            btnWrite4Light3.TabIndex = 19;
            btnWrite4Light3.Text = "下发按钮4灯灭";
            btnWrite4Light3.UseVisualStyleBackColor = true;
            btnWrite4Light3.Click += btnWrite4Light3_Click;
            // 
            // btnWrite3Light3
            // 
            btnWrite3Light3.Location = new Point(6, 386);
            btnWrite3Light3.Name = "btnWrite3Light3";
            btnWrite3Light3.Size = new Size(151, 23);
            btnWrite3Light3.TabIndex = 18;
            btnWrite3Light3.Text = "下发按钮3灯灭";
            btnWrite3Light3.UseVisualStyleBackColor = true;
            btnWrite3Light3.Click += btnWrite3Light3_Click;
            // 
            // btnWrite2Light3
            // 
            btnWrite2Light3.Location = new Point(163, 357);
            btnWrite2Light3.Name = "btnWrite2Light3";
            btnWrite2Light3.Size = new Size(151, 23);
            btnWrite2Light3.TabIndex = 17;
            btnWrite2Light3.Text = "下发按钮2灯灭";
            btnWrite2Light3.UseVisualStyleBackColor = true;
            btnWrite2Light3.Click += btnWrite2Light3_Click;
            // 
            // btnWrite1Light3
            // 
            btnWrite1Light3.Location = new Point(6, 357);
            btnWrite1Light3.Name = "btnWrite1Light3";
            btnWrite1Light3.Size = new Size(151, 23);
            btnWrite1Light3.TabIndex = 16;
            btnWrite1Light3.Text = "下发按钮1灯灭";
            btnWrite1Light3.UseVisualStyleBackColor = true;
            btnWrite1Light3.Click += btnWrite1Light3_Click;
            // 
            // btnWrite4Light1
            // 
            btnWrite4Light1.Location = new Point(163, 314);
            btnWrite4Light1.Name = "btnWrite4Light1";
            btnWrite4Light1.Size = new Size(151, 23);
            btnWrite4Light1.TabIndex = 15;
            btnWrite4Light1.Text = "下发按钮4灯亮";
            btnWrite4Light1.UseVisualStyleBackColor = true;
            btnWrite4Light1.Click += btnWrite4Light1_Click;
            // 
            // btnWrite3Light1
            // 
            btnWrite3Light1.Location = new Point(6, 314);
            btnWrite3Light1.Name = "btnWrite3Light1";
            btnWrite3Light1.Size = new Size(151, 23);
            btnWrite3Light1.TabIndex = 14;
            btnWrite3Light1.Text = "下发按钮3灯亮";
            btnWrite3Light1.UseVisualStyleBackColor = true;
            btnWrite3Light1.Click += btnWrite3Light1_Click;
            // 
            // btnWrite2Light1
            // 
            btnWrite2Light1.Location = new Point(163, 285);
            btnWrite2Light1.Name = "btnWrite2Light1";
            btnWrite2Light1.Size = new Size(151, 23);
            btnWrite2Light1.TabIndex = 13;
            btnWrite2Light1.Text = "下发按钮2灯亮";
            btnWrite2Light1.UseVisualStyleBackColor = true;
            btnWrite2Light1.Click += btnWrite2Light1_Click;
            // 
            // btnWrite1Light1
            // 
            btnWrite1Light1.Location = new Point(6, 285);
            btnWrite1Light1.Name = "btnWrite1Light1";
            btnWrite1Light1.Size = new Size(151, 23);
            btnWrite1Light1.TabIndex = 12;
            btnWrite1Light1.Text = "下发按钮1灯亮";
            btnWrite1Light1.UseVisualStyleBackColor = true;
            btnWrite1Light1.Click += btnWrite1Light1_Click;
            // 
            // btnWrite4Status1
            // 
            btnWrite4Status1.Location = new Point(163, 238);
            btnWrite4Status1.Name = "btnWrite4Status1";
            btnWrite4Status1.Size = new Size(151, 23);
            btnWrite4Status1.TabIndex = 11;
            btnWrite4Status1.Text = "下发按钮4呼叫状态";
            btnWrite4Status1.UseVisualStyleBackColor = true;
            btnWrite4Status1.Click += btnWrite4Status1_Click;
            // 
            // btnWrite3Status1
            // 
            btnWrite3Status1.Location = new Point(6, 238);
            btnWrite3Status1.Name = "btnWrite3Status1";
            btnWrite3Status1.Size = new Size(151, 23);
            btnWrite3Status1.TabIndex = 10;
            btnWrite3Status1.Text = "下发按钮3呼叫状态";
            btnWrite3Status1.UseVisualStyleBackColor = true;
            btnWrite3Status1.Click += btnWrite3Status1_Click;
            // 
            // btnWrite2Status1
            // 
            btnWrite2Status1.Location = new Point(163, 209);
            btnWrite2Status1.Name = "btnWrite2Status1";
            btnWrite2Status1.Size = new Size(151, 23);
            btnWrite2Status1.TabIndex = 9;
            btnWrite2Status1.Text = "下发按钮2呼叫状态";
            btnWrite2Status1.UseVisualStyleBackColor = true;
            btnWrite2Status1.Click += btnWrite2Status1_Click;
            // 
            // btnWrite1Status1
            // 
            btnWrite1Status1.Location = new Point(6, 209);
            btnWrite1Status1.Name = "btnWrite1Status1";
            btnWrite1Status1.Size = new Size(151, 23);
            btnWrite1Status1.TabIndex = 8;
            btnWrite1Status1.Text = "下发按钮1呼叫状态";
            btnWrite1Status1.UseVisualStyleBackColor = true;
            btnWrite1Status1.Click += btnWrite1Status1_Click;
            // 
            // btnWrite4Status0
            // 
            btnWrite4Status0.Location = new Point(163, 170);
            btnWrite4Status0.Name = "btnWrite4Status0";
            btnWrite4Status0.Size = new Size(151, 23);
            btnWrite4Status0.TabIndex = 7;
            btnWrite4Status0.Text = "下发按钮4完成状态";
            btnWrite4Status0.UseVisualStyleBackColor = true;
            btnWrite4Status0.Click += btnWrite4Status0_Click;
            // 
            // btnWrite3Status0
            // 
            btnWrite3Status0.Location = new Point(6, 170);
            btnWrite3Status0.Name = "btnWrite3Status0";
            btnWrite3Status0.Size = new Size(151, 23);
            btnWrite3Status0.TabIndex = 6;
            btnWrite3Status0.Text = "下发按钮3完成状态";
            btnWrite3Status0.UseVisualStyleBackColor = true;
            btnWrite3Status0.Click += btnWrite3Status0_Click;
            // 
            // btnWrite2Status0
            // 
            btnWrite2Status0.Location = new Point(163, 141);
            btnWrite2Status0.Name = "btnWrite2Status0";
            btnWrite2Status0.Size = new Size(151, 23);
            btnWrite2Status0.TabIndex = 5;
            btnWrite2Status0.Text = "下发按钮2完成状态";
            btnWrite2Status0.UseVisualStyleBackColor = true;
            btnWrite2Status0.Click += btnWrite2Status0_Click;
            // 
            // btnWrite1Status0
            // 
            btnWrite1Status0.Location = new Point(6, 141);
            btnWrite1Status0.Name = "btnWrite1Status0";
            btnWrite1Status0.Size = new Size(151, 23);
            btnWrite1Status0.TabIndex = 4;
            btnWrite1Status0.Text = "下发按钮1完成状态";
            btnWrite1Status0.UseVisualStyleBackColor = true;
            btnWrite1Status0.Click += btnWrite1Status0_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 54);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 3;
            label3.Text = "设备地址";
            // 
            // btnWriteAddr
            // 
            btnWriteAddr.Location = new Point(6, 80);
            btnWriteAddr.Name = "btnWriteAddr";
            btnWriteAddr.Size = new Size(151, 23);
            btnWriteAddr.TabIndex = 2;
            btnWriteAddr.Text = "主机写从机的设备地址";
            btnWriteAddr.UseVisualStyleBackColor = true;
            btnWriteAddr.Click += btnWriteAddr_Click;
            // 
            // txtAddr
            // 
            txtAddr.Location = new Point(70, 51);
            txtAddr.Name = "txtAddr";
            txtAddr.Size = new Size(87, 23);
            txtAddr.TabIndex = 1;
            // 
            // btnReadAddr
            // 
            btnReadAddr.Location = new Point(6, 22);
            btnReadAddr.Name = "btnReadAddr";
            btnReadAddr.Size = new Size(151, 23);
            btnReadAddr.TabIndex = 0;
            btnReadAddr.Text = "主机读从机的设备地址";
            btnReadAddr.UseVisualStyleBackColor = true;
            btnReadAddr.Click += btnReadAddr_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 561);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "按钮控制";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnConnection;
        private TextBox txtPort;
        private Label label2;
        private TextBox txtIP;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtLog;
        private Button btnReadAddr;
        private TextBox txtAddr;
        private Button btnWriteAddr;
        private Label label3;
        private Button btnWrite1Status0;
        private Button btnWrite4Status0;
        private Button btnWrite3Status0;
        private Button btnWrite2Status0;
        private Button btnWrite4Status1;
        private Button btnWrite3Status1;
        private Button btnWrite2Status1;
        private Button btnWrite1Status1;
        private Button btnWrite4Light1;
        private Button btnWrite3Light1;
        private Button btnWrite2Light1;
        private Button btnWrite1Light1;
        private Button btnWrite4Light3;
        private Button btnWrite3Light3;
        private Button btnWrite2Light3;
        private Button btnWrite1Light3;
        private Button btnConnectionClose;
    }
}