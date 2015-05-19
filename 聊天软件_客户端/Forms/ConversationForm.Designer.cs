namespace 聊天软件_客户端
{
    partial class ConversationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.emojiBtn = new System.Windows.Forms.Button();
            this.sendMessageBtn = new System.Windows.Forms.Button();
            this.fileBtn = new System.Windows.Forms.Button();
            this.sendMessageBox = new System.Windows.Forms.TextBox();
            this.shakeBtn = new System.Windows.Forms.Button();
            this.sendMessagePanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.messagesContainerPanel = new System.Windows.Forms.Panel();
            this.sendMessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // emojiBtn
            // 
            this.emojiBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.emojiBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emojiBtn.Location = new System.Drawing.Point(18, 2);
            this.emojiBtn.Name = "emojiBtn";
            this.emojiBtn.Size = new System.Drawing.Size(75, 29);
            this.emojiBtn.TabIndex = 3;
            this.emojiBtn.Text = "发表情";
            this.emojiBtn.UseVisualStyleBackColor = true;
            // 
            // sendMessageBtn
            // 
            this.sendMessageBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sendMessageBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendMessageBtn.Location = new System.Drawing.Point(565, 66);
            this.sendMessageBtn.Name = "sendMessageBtn";
            this.sendMessageBtn.Size = new System.Drawing.Size(76, 29);
            this.sendMessageBtn.TabIndex = 1;
            this.sendMessageBtn.Text = "发送";
            this.sendMessageBtn.UseVisualStyleBackColor = true;
            this.sendMessageBtn.Click += new System.EventHandler(this.sendMessageBtn_Click);
            // 
            // fileBtn
            // 
            this.fileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileBtn.Location = new System.Drawing.Point(144, 2);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(75, 29);
            this.fileBtn.TabIndex = 4;
            this.fileBtn.Text = "发文件";
            this.fileBtn.UseVisualStyleBackColor = true;
            // 
            // sendMessageBox
            // 
            this.sendMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMessageBox.Location = new System.Drawing.Point(18, 38);
            this.sendMessageBox.Multiline = true;
            this.sendMessageBox.Name = "sendMessageBox";
            this.sendMessageBox.Size = new System.Drawing.Size(532, 87);
            this.sendMessageBox.TabIndex = 0;
            // 
            // shakeBtn
            // 
            this.shakeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shakeBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shakeBtn.Location = new System.Drawing.Point(276, 2);
            this.shakeBtn.Name = "shakeBtn";
            this.shakeBtn.Size = new System.Drawing.Size(75, 29);
            this.shakeBtn.TabIndex = 5;
            this.shakeBtn.Text = "抖一下";
            this.shakeBtn.UseVisualStyleBackColor = true;
            this.shakeBtn.Click += new System.EventHandler(this.shakeBtn_Click);
            // 
            // sendMessagePanel
            // 
            this.sendMessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMessagePanel.Controls.Add(this.statusLabel);
            this.sendMessagePanel.Controls.Add(this.shakeBtn);
            this.sendMessagePanel.Controls.Add(this.sendMessageBox);
            this.sendMessagePanel.Controls.Add(this.fileBtn);
            this.sendMessagePanel.Controls.Add(this.sendMessageBtn);
            this.sendMessagePanel.Controls.Add(this.emojiBtn);
            this.sendMessagePanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sendMessagePanel.Location = new System.Drawing.Point(12, 461);
            this.sendMessagePanel.Name = "sendMessagePanel";
            this.sendMessagePanel.Size = new System.Drawing.Size(655, 150);
            this.sendMessagePanel.TabIndex = 6;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.Location = new System.Drawing.Point(3, 128);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(329, 18);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "已连接服务器";
            // 
            // messagesContainerPanel
            // 
            this.messagesContainerPanel.AutoScroll = true;
            this.messagesContainerPanel.Location = new System.Drawing.Point(30, 12);
            this.messagesContainerPanel.Name = "messagesContainerPanel";
            this.messagesContainerPanel.Size = new System.Drawing.Size(637, 445);
            this.messagesContainerPanel.TabIndex = 7;
            // 
            // ConversationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 612);
            this.Controls.Add(this.messagesContainerPanel);
            this.Controls.Add(this.sendMessagePanel);
            this.MaximumSize = new System.Drawing.Size(700, 650);
            this.MinimumSize = new System.Drawing.Size(550, 450);
            this.Name = "ConversationForm";
            this.Text = "和XXX的会话";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConversationForm_FormClosed);
            this.Load += new System.EventHandler(this.ConversationForm_Load);
            this.sendMessagePanel.ResumeLayout(false);
            this.sendMessagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button emojiBtn;
        private System.Windows.Forms.Button sendMessageBtn;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.TextBox sendMessageBox;
        private System.Windows.Forms.Button shakeBtn;
        private System.Windows.Forms.Panel sendMessagePanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel messagesContainerPanel;

    }
}