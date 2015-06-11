namespace 聊天软件_客户端
{
    partial class ClientMainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                this.notifyIcon.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addFriendsBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sayingLabel = new System.Windows.Forms.Label();
            this.friendsListPanel = new System.Windows.Forms.Panel();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.blinkTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameLabel.Location = new System.Drawing.Point(140, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(161, 23);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "并没有名字";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addFriendsBtn
            // 
            this.addFriendsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFriendsBtn.Location = new System.Drawing.Point(19, 630);
            this.addFriendsBtn.Name = "addFriendsBtn";
            this.addFriendsBtn.Size = new System.Drawing.Size(80, 23);
            this.addFriendsBtn.TabIndex = 4;
            this.addFriendsBtn.Text = "添加好友";
            this.addFriendsBtn.UseVisualStyleBackColor = true;
            this.addFriendsBtn.Click += new System.EventHandler(this.addFriendsBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.sayingLabel);
            this.mainPanel.Controls.Add(this.friendsListPanel);
            this.mainPanel.Controls.Add(this.addFriendsBtn);
            this.mainPanel.Controls.Add(this.iconBox);
            this.mainPanel.Controls.Add(this.nameLabel);
            this.mainPanel.Location = new System.Drawing.Point(6, 5);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(310, 660);
            this.mainPanel.TabIndex = 5;
            // 
            // sayingLabel
            // 
            this.sayingLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sayingLabel.Location = new System.Drawing.Point(135, 46);
            this.sayingLabel.Name = "sayingLabel";
            this.sayingLabel.Size = new System.Drawing.Size(166, 77);
            this.sayingLabel.TabIndex = 6;
            this.sayingLabel.Text = "并没有说说";
            // 
            // friendsListPanel
            // 
            this.friendsListPanel.AutoScroll = true;
            this.friendsListPanel.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.friendsListPanel.Location = new System.Drawing.Point(5, 130);
            this.friendsListPanel.Name = "friendsListPanel";
            this.friendsListPanel.Size = new System.Drawing.Size(300, 490);
            this.friendsListPanel.TabIndex = 5;
            // 
            // iconBox
            // 
            this.iconBox.Image = global::聊天软件_客户端.Properties.Resources.cantFindPicture;
            this.iconBox.Location = new System.Drawing.Point(8, 3);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(120, 120);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 0;
            this.iconBox.TabStop = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = global::聊天软件_客户端.Properties.Resources.mainIcon;
            this.notifyIcon.Text = "有消息!";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // blinkTimer
            // 
            this.blinkTimer.Interval = 200;
            this.blinkTimer.Tick += new System.EventHandler(this.blinkTimer_Tick);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 673);
            this.Controls.Add(this.mainPanel);
            this.MaximumSize = new System.Drawing.Size(500, 750);
            this.MinimumSize = new System.Drawing.Size(344, 450);
            this.Name = "ClientMainForm";
            this.Text = "六度聊天软件";
            this.Load += new System.EventHandler(this.ClientMainForm_Load);
            this.SizeChanged += new System.EventHandler(this.ClientMainForm_SizeChanged);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button addFriendsBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel friendsListPanel;
        private System.Windows.Forms.Label sayingLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer blinkTimer;
    }
}

