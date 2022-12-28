namespace Socket_test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.G_chooseSC = new System.Windows.Forms.GroupBox();
            this.T_IP = new System.Windows.Forms.TextBox();
            this.Being_Client = new System.Windows.Forms.Button();
            this.Being_Server = new System.Windows.Forms.Button();
            this.G_Server = new System.Windows.Forms.GroupBox();
            this.L_SFileName = new System.Windows.Forms.Label();
            this.B_SChooseFile = new System.Windows.Forms.Button();
            this.T_SMessage = new System.Windows.Forms.TextBox();
            this.B_SDisConnect = new System.Windows.Forms.Button();
            this.R_SsendFile = new System.Windows.Forms.RadioButton();
            this.R_SsendMessage = new System.Windows.Forms.RadioButton();
            this.B_SGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.C_SChooseSendTo = new System.Windows.Forms.ComboBox();
            this.G_Client = new System.Windows.Forms.GroupBox();
            this.L_CFileName = new System.Windows.Forms.Label();
            this.B_CChooseFile = new System.Windows.Forms.Button();
            this.T_CMessage = new System.Windows.Forms.TextBox();
            this.L_CconnectStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B_CDisConnect = new System.Windows.Forms.Button();
            this.B_CGo = new System.Windows.Forms.Button();
            this.R_CsendFile = new System.Windows.Forms.RadioButton();
            this.R_CsendMessage = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSL_Send_packet = new System.Windows.Forms.ToolStripStatusLabel();
            this.STTL_packet = new System.Windows.Forms.ToolStripStatusLabel();
            this.G_ShowArea = new System.Windows.Forms.GroupBox();
            this.List_Text = new System.Windows.Forms.ListBox();
            this.Test1 = new System.Windows.Forms.Button();
            this.G_chooseSC.SuspendLayout();
            this.G_Server.SuspendLayout();
            this.G_Client.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.G_ShowArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // G_chooseSC
            // 
            this.G_chooseSC.Controls.Add(this.T_IP);
            this.G_chooseSC.Controls.Add(this.Being_Client);
            this.G_chooseSC.Controls.Add(this.Being_Server);
            this.G_chooseSC.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.G_chooseSC.Location = new System.Drawing.Point(349, 191);
            this.G_chooseSC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.G_chooseSC.Name = "G_chooseSC";
            this.G_chooseSC.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.G_chooseSC.Size = new System.Drawing.Size(299, 120);
            this.G_chooseSC.TabIndex = 0;
            this.G_chooseSC.TabStop = false;
            this.G_chooseSC.Text = "Server or Client";
            // 
            // T_IP
            // 
            this.T_IP.Location = new System.Drawing.Point(112, 30);
            this.T_IP.Name = "T_IP";
            this.T_IP.Size = new System.Drawing.Size(181, 34);
            this.T_IP.TabIndex = 3;
            this.T_IP.Text = "127.0.0.1";
            // 
            // Being_Client
            // 
            this.Being_Client.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Being_Client.Location = new System.Drawing.Point(112, 70);
            this.Being_Client.Name = "Being_Client";
            this.Being_Client.Size = new System.Drawing.Size(181, 43);
            this.Being_Client.TabIndex = 1;
            this.Being_Client.Text = "Client";
            this.Being_Client.UseVisualStyleBackColor = true;
            this.Being_Client.Click += new System.EventHandler(this.Being_Click);
            // 
            // Being_Server
            // 
            this.Being_Server.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Being_Server.Location = new System.Drawing.Point(6, 27);
            this.Being_Server.Name = "Being_Server";
            this.Being_Server.Size = new System.Drawing.Size(100, 86);
            this.Being_Server.TabIndex = 0;
            this.Being_Server.Text = "Server";
            this.Being_Server.UseVisualStyleBackColor = true;
            this.Being_Server.Click += new System.EventHandler(this.Being_Click);
            // 
            // G_Server
            // 
            this.G_Server.Controls.Add(this.L_SFileName);
            this.G_Server.Controls.Add(this.B_SChooseFile);
            this.G_Server.Controls.Add(this.T_SMessage);
            this.G_Server.Controls.Add(this.B_SDisConnect);
            this.G_Server.Controls.Add(this.R_SsendFile);
            this.G_Server.Controls.Add(this.R_SsendMessage);
            this.G_Server.Controls.Add(this.B_SGo);
            this.G_Server.Controls.Add(this.label1);
            this.G_Server.Controls.Add(this.C_SChooseSendTo);
            this.G_Server.Location = new System.Drawing.Point(12, 13);
            this.G_Server.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.G_Server.Name = "G_Server";
            this.G_Server.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.G_Server.Size = new System.Drawing.Size(331, 161);
            this.G_Server.TabIndex = 1;
            this.G_Server.TabStop = false;
            this.G_Server.Text = "Server";
            // 
            // L_SFileName
            // 
            this.L_SFileName.AutoSize = true;
            this.L_SFileName.Location = new System.Drawing.Point(177, 96);
            this.L_SFileName.Name = "L_SFileName";
            this.L_SFileName.Size = new System.Drawing.Size(41, 19);
            this.L_SFileName.TabIndex = 8;
            this.L_SFileName.Text = "NaN";
            // 
            // B_SChooseFile
            // 
            this.B_SChooseFile.Location = new System.Drawing.Point(93, 92);
            this.B_SChooseFile.Name = "B_SChooseFile";
            this.B_SChooseFile.Size = new System.Drawing.Size(78, 27);
            this.B_SChooseFile.TabIndex = 7;
            this.B_SChooseFile.Text = "choose";
            this.B_SChooseFile.UseVisualStyleBackColor = true;
            this.B_SChooseFile.Click += new System.EventHandler(this.B_ChooseFile_Click);
            // 
            // T_SMessage
            // 
            this.T_SMessage.Location = new System.Drawing.Point(93, 60);
            this.T_SMessage.Name = "T_SMessage";
            this.T_SMessage.Size = new System.Drawing.Size(236, 27);
            this.T_SMessage.TabIndex = 2;
            // 
            // B_SDisConnect
            // 
            this.B_SDisConnect.Location = new System.Drawing.Point(6, 127);
            this.B_SDisConnect.Name = "B_SDisConnect";
            this.B_SDisConnect.Size = new System.Drawing.Size(109, 27);
            this.B_SDisConnect.TabIndex = 18;
            this.B_SDisConnect.Text = "DisConnect";
            this.B_SDisConnect.UseVisualStyleBackColor = true;
            this.B_SDisConnect.Click += new System.EventHandler(this.B_DisConnect_Click);
            // 
            // R_SsendFile
            // 
            this.R_SsendFile.AutoSize = true;
            this.R_SsendFile.Location = new System.Drawing.Point(10, 94);
            this.R_SsendFile.Name = "R_SsendFile";
            this.R_SsendFile.Size = new System.Drawing.Size(111, 23);
            this.R_SsendFile.TabIndex = 10;
            this.R_SsendFile.TabStop = true;
            this.R_SsendFile.Text = "Send File：";
            this.R_SsendFile.UseVisualStyleBackColor = true;
            // 
            // R_SsendMessage
            // 
            this.R_SsendMessage.AutoSize = true;
            this.R_SsendMessage.Location = new System.Drawing.Point(10, 61);
            this.R_SsendMessage.Name = "R_SsendMessage";
            this.R_SsendMessage.Size = new System.Drawing.Size(110, 23);
            this.R_SsendMessage.TabIndex = 9;
            this.R_SsendMessage.TabStop = true;
            this.R_SsendMessage.Text = "Message：";
            this.R_SsendMessage.UseVisualStyleBackColor = true;
            // 
            // B_SGo
            // 
            this.B_SGo.Location = new System.Drawing.Point(247, 127);
            this.B_SGo.Name = "B_SGo";
            this.B_SGo.Size = new System.Drawing.Size(78, 27);
            this.B_SGo.TabIndex = 6;
            this.B_SGo.Text = "Go";
            this.B_SGo.UseVisualStyleBackColor = true;
            this.B_SGo.Click += new System.EventHandler(this.B_Go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Send to：";
            // 
            // C_SChooseSendTo
            // 
            this.C_SChooseSendTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.C_SChooseSendTo.FormattingEnabled = true;
            this.C_SChooseSendTo.Items.AddRange(new object[] {
            "ALL"});
            this.C_SChooseSendTo.Location = new System.Drawing.Point(93, 27);
            this.C_SChooseSendTo.Name = "C_SChooseSendTo";
            this.C_SChooseSendTo.Size = new System.Drawing.Size(232, 27);
            this.C_SChooseSendTo.TabIndex = 0;
            this.C_SChooseSendTo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.C_SChooseSendTo_MouseClick);
            // 
            // G_Client
            // 
            this.G_Client.Controls.Add(this.L_CFileName);
            this.G_Client.Controls.Add(this.B_CChooseFile);
            this.G_Client.Controls.Add(this.T_CMessage);
            this.G_Client.Controls.Add(this.L_CconnectStatus);
            this.G_Client.Controls.Add(this.label2);
            this.G_Client.Controls.Add(this.B_CDisConnect);
            this.G_Client.Controls.Add(this.B_CGo);
            this.G_Client.Controls.Add(this.R_CsendFile);
            this.G_Client.Controls.Add(this.R_CsendMessage);
            this.G_Client.Location = new System.Drawing.Point(349, 13);
            this.G_Client.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.G_Client.Name = "G_Client";
            this.G_Client.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.G_Client.Size = new System.Drawing.Size(331, 161);
            this.G_Client.TabIndex = 2;
            this.G_Client.TabStop = false;
            this.G_Client.Text = "Client";
            // 
            // L_CFileName
            // 
            this.L_CFileName.AutoSize = true;
            this.L_CFileName.Location = new System.Drawing.Point(173, 96);
            this.L_CFileName.Name = "L_CFileName";
            this.L_CFileName.Size = new System.Drawing.Size(41, 19);
            this.L_CFileName.TabIndex = 13;
            this.L_CFileName.Text = "NaN";
            // 
            // B_CChooseFile
            // 
            this.B_CChooseFile.Location = new System.Drawing.Point(89, 92);
            this.B_CChooseFile.Name = "B_CChooseFile";
            this.B_CChooseFile.Size = new System.Drawing.Size(78, 27);
            this.B_CChooseFile.TabIndex = 12;
            this.B_CChooseFile.Text = "choose";
            this.B_CChooseFile.UseVisualStyleBackColor = true;
            this.B_CChooseFile.Click += new System.EventHandler(this.B_ChooseFile_Click);
            // 
            // T_CMessage
            // 
            this.T_CMessage.Location = new System.Drawing.Point(89, 60);
            this.T_CMessage.Name = "T_CMessage";
            this.T_CMessage.Size = new System.Drawing.Size(236, 27);
            this.T_CMessage.TabIndex = 11;
            // 
            // L_CconnectStatus
            // 
            this.L_CconnectStatus.AutoSize = true;
            this.L_CconnectStatus.Location = new System.Drawing.Point(146, 30);
            this.L_CconnectStatus.Name = "L_CconnectStatus";
            this.L_CconnectStatus.Size = new System.Drawing.Size(41, 19);
            this.L_CconnectStatus.TabIndex = 20;
            this.L_CconnectStatus.Text = "NaN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Connect Status：";
            // 
            // B_CDisConnect
            // 
            this.B_CDisConnect.Location = new System.Drawing.Point(6, 127);
            this.B_CDisConnect.Name = "B_CDisConnect";
            this.B_CDisConnect.Size = new System.Drawing.Size(109, 27);
            this.B_CDisConnect.TabIndex = 17;
            this.B_CDisConnect.Text = "DisConnect";
            this.B_CDisConnect.UseVisualStyleBackColor = true;
            this.B_CDisConnect.Click += new System.EventHandler(this.B_DisConnect_Click);
            // 
            // B_CGo
            // 
            this.B_CGo.Location = new System.Drawing.Point(247, 127);
            this.B_CGo.Name = "B_CGo";
            this.B_CGo.Size = new System.Drawing.Size(78, 27);
            this.B_CGo.TabIndex = 16;
            this.B_CGo.Text = "Go";
            this.B_CGo.UseVisualStyleBackColor = true;
            this.B_CGo.Click += new System.EventHandler(this.B_Go_Click);
            // 
            // R_CsendFile
            // 
            this.R_CsendFile.AutoSize = true;
            this.R_CsendFile.Location = new System.Drawing.Point(6, 94);
            this.R_CsendFile.Name = "R_CsendFile";
            this.R_CsendFile.Size = new System.Drawing.Size(111, 23);
            this.R_CsendFile.TabIndex = 15;
            this.R_CsendFile.TabStop = true;
            this.R_CsendFile.Text = "Send File：";
            this.R_CsendFile.UseVisualStyleBackColor = true;
            // 
            // R_CsendMessage
            // 
            this.R_CsendMessage.AutoSize = true;
            this.R_CsendMessage.Location = new System.Drawing.Point(6, 61);
            this.R_CsendMessage.Name = "R_CsendMessage";
            this.R_CsendMessage.Size = new System.Drawing.Size(110, 23);
            this.R_CsendMessage.TabIndex = 14;
            this.R_CsendMessage.TabStop = true;
            this.R_CsendMessage.Text = "Message：";
            this.R_CsendMessage.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_Send_packet,
            this.STTL_packet});
            this.statusStrip1.Location = new System.Drawing.Point(0, 358);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(687, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSSL_Send_packet
            // 
            this.TSSL_Send_packet.Name = "TSSL_Send_packet";
            this.TSSL_Send_packet.Size = new System.Drawing.Size(109, 19);
            this.TSSL_Send_packet.Text = "Send packet：";
            // 
            // STTL_packet
            // 
            this.STTL_packet.Name = "STTL_packet";
            this.STTL_packet.Size = new System.Drawing.Size(41, 19);
            this.STTL_packet.Text = "NaN";
            // 
            // G_ShowArea
            // 
            this.G_ShowArea.Controls.Add(this.List_Text);
            this.G_ShowArea.Location = new System.Drawing.Point(12, 181);
            this.G_ShowArea.Name = "G_ShowArea";
            this.G_ShowArea.Size = new System.Drawing.Size(331, 174);
            this.G_ShowArea.TabIndex = 4;
            this.G_ShowArea.TabStop = false;
            this.G_ShowArea.Text = "Text Area";
            // 
            // List_Text
            // 
            this.List_Text.FormattingEnabled = true;
            this.List_Text.ItemHeight = 19;
            this.List_Text.Location = new System.Drawing.Point(10, 26);
            this.List_Text.Name = "List_Text";
            this.List_Text.Size = new System.Drawing.Size(315, 137);
            this.List_Text.TabIndex = 0;
            // 
            // Test1
            // 
            this.Test1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Test1.Location = new System.Drawing.Point(349, 318);
            this.Test1.Name = "Test1";
            this.Test1.Size = new System.Drawing.Size(88, 37);
            this.Test1.TabIndex = 4;
            this.Test1.Text = "Test1";
            this.Test1.UseVisualStyleBackColor = true;
            this.Test1.Click += new System.EventHandler(this.Test1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 383);
            this.Controls.Add(this.Test1);
            this.Controls.Add(this.G_ShowArea);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.G_Client);
            this.Controls.Add(this.G_Server);
            this.Controls.Add(this.G_chooseSC);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.G_chooseSC.ResumeLayout(false);
            this.G_chooseSC.PerformLayout();
            this.G_Server.ResumeLayout(false);
            this.G_Server.PerformLayout();
            this.G_Client.ResumeLayout(false);
            this.G_Client.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.G_ShowArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox G_chooseSC;
        private System.Windows.Forms.Button Being_Client;
        private System.Windows.Forms.Button Being_Server;
        private System.Windows.Forms.GroupBox G_Server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox C_SChooseSendTo;
        private System.Windows.Forms.GroupBox G_Client;
        private System.Windows.Forms.Label L_SFileName;
        private System.Windows.Forms.Button B_SChooseFile;
        private System.Windows.Forms.Button B_SGo;
        private System.Windows.Forms.TextBox T_SMessage;
        private System.Windows.Forms.TextBox T_IP;
        private System.Windows.Forms.RadioButton R_SsendFile;
        private System.Windows.Forms.RadioButton R_SsendMessage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_Send_packet;
        private System.Windows.Forms.ToolStripStatusLabel STTL_packet;
        private System.Windows.Forms.Button B_SDisConnect;
        private System.Windows.Forms.Button B_CDisConnect;
        private System.Windows.Forms.Button B_CGo;
        private System.Windows.Forms.RadioButton R_CsendFile;
        private System.Windows.Forms.RadioButton R_CsendMessage;
        private System.Windows.Forms.Label L_CFileName;
        private System.Windows.Forms.Button B_CChooseFile;
        private System.Windows.Forms.TextBox T_CMessage;
        private System.Windows.Forms.GroupBox G_ShowArea;
        private System.Windows.Forms.ListBox List_Text;
        private System.Windows.Forms.Label L_CconnectStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Test1;
    }
}

