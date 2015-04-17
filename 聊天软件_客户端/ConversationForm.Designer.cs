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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversationForm));
            this.emojiBtn = new System.Windows.Forms.Button();
            this.sendMessageBtn = new System.Windows.Forms.Button();
            this.fileBtn = new System.Windows.Forms.Button();
            this.sendMessageBox = new System.Windows.Forms.TextBox();
            this.shakeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.showMessageBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // emojiBtn
            // 
            this.emojiBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.emojiBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emojiBtn.Location = new System.Drawing.Point(18, 5);
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
            this.sendMessageBtn.Location = new System.Drawing.Point(496, 54);
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
            this.fileBtn.Location = new System.Drawing.Point(144, 5);
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
            this.sendMessageBox.Location = new System.Drawing.Point(18, 41);
            this.sendMessageBox.Multiline = true;
            this.sendMessageBox.Name = "sendMessageBox";
            this.sendMessageBox.Size = new System.Drawing.Size(460, 63);
            this.sendMessageBox.TabIndex = 0;
            // 
            // shakeBtn
            // 
            this.shakeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shakeBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shakeBtn.Location = new System.Drawing.Point(276, 5);
            this.shakeBtn.Name = "shakeBtn";
            this.shakeBtn.Size = new System.Drawing.Size(75, 29);
            this.shakeBtn.TabIndex = 5;
            this.shakeBtn.Text = "抖一下";
            this.shakeBtn.UseVisualStyleBackColor = true;
            this.shakeBtn.Click += new System.EventHandler(this.shakeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Controls.Add(this.shakeBtn);
            this.panel1.Controls.Add(this.sendMessageBox);
            this.panel1.Controls.Add(this.fileBtn);
            this.panel1.Controls.Add(this.sendMessageBtn);
            this.panel1.Controls.Add(this.emojiBtn);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(12, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 153);
            this.panel1.TabIndex = 6;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.Location = new System.Drawing.Point(17, 110);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(329, 18);
            this.statusLabel.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dc28731dfdea771f69bee8c3a77499b5.jpg");
            this.imageList1.Images.SetKeyName(1, "海豹君.png");
            this.imageList1.Images.SetKeyName(2, "阿狸.jpg");
            // 
            // showMessageBox
            // 
            this.showMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.showMessageBox.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showMessageBox.Location = new System.Drawing.Point(30, 12);
            this.showMessageBox.Multiline = true;
            this.showMessageBox.Name = "showMessageBox";
            this.showMessageBox.ReadOnly = true;
            this.showMessageBox.Size = new System.Drawing.Size(555, 366);
            this.showMessageBox.TabIndex = 7;
            this.showMessageBox.Text = "测试测试";
            // 
            // ConversationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 521);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showMessageBox);
            this.MaximumSize = new System.Drawing.Size(700, 650);
            this.MinimumSize = new System.Drawing.Size(550, 450);
            this.Name = "ConversationForm";
            this.Text = "和XXX的会话";
            this.Load += new System.EventHandler(this.ConversationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button emojiBtn;
        private System.Windows.Forms.Button sendMessageBtn;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.TextBox sendMessageBox;
        private System.Windows.Forms.Button shakeBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox showMessageBox;
        private System.Windows.Forms.Label statusLabel;

    }
}