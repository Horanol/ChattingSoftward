namespace 聊天软件_客户端
{
    partial class ShowDetailInfoForm
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
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.sayingLabel = new System.Windows.Forms.Label();
            this.sexLabelShow = new System.Windows.Forms.Label();
            this.ageLabelShow = new System.Windows.Forms.Label();
            this.addFriendBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // iconBox
            // 
            this.iconBox.Location = new System.Drawing.Point(12, 12);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(120, 120);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 0;
            this.iconBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameLabel.Location = new System.Drawing.Point(170, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(168, 23);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "测试测试";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sayingLabel
            // 
            this.sayingLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sayingLabel.Location = new System.Drawing.Point(12, 166);
            this.sayingLabel.Name = "sayingLabel";
            this.sayingLabel.Size = new System.Drawing.Size(326, 209);
            this.sayingLabel.TabIndex = 2;
            this.sayingLabel.Text = "测试测试测试";
            // 
            // sexLabelShow
            // 
            this.sexLabelShow.AutoSize = true;
            this.sexLabelShow.Location = new System.Drawing.Point(150, 56);
            this.sexLabelShow.Name = "sexLabelShow";
            this.sexLabelShow.Size = new System.Drawing.Size(41, 12);
            this.sexLabelShow.TabIndex = 3;
            this.sexLabelShow.Text = "性别：";
            // 
            // ageLabelShow
            // 
            this.ageLabelShow.AutoSize = true;
            this.ageLabelShow.Location = new System.Drawing.Point(150, 97);
            this.ageLabelShow.Name = "ageLabelShow";
            this.ageLabelShow.Size = new System.Drawing.Size(41, 12);
            this.ageLabelShow.TabIndex = 4;
            this.ageLabelShow.Text = "年龄：";
            // 
            // addFriendBtn
            // 
            this.addFriendBtn.Location = new System.Drawing.Point(152, 389);
            this.addFriendBtn.Name = "addFriendBtn";
            this.addFriendBtn.Size = new System.Drawing.Size(75, 23);
            this.addFriendBtn.TabIndex = 5;
            this.addFriendBtn.Text = "添加好友";
            this.addFriendBtn.UseVisualStyleBackColor = true;
            this.addFriendBtn.Click += new System.EventHandler(this.addFriendBtn_Click);
            // 
            // ShowDetailInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 436);
            this.Controls.Add(this.addFriendBtn);
            this.Controls.Add(this.ageLabelShow);
            this.Controls.Add(this.sexLabelShow);
            this.Controls.Add(this.sayingLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.iconBox);
            this.Name = "ShowDetailInfoForm";
            this.Text = "ShowDetailInfoForm";
            this.Load += new System.EventHandler(this.ShowDetailInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label sayingLabel;
        private System.Windows.Forms.Label sexLabelShow;
        private System.Windows.Forms.Label ageLabelShow;
        private System.Windows.Forms.Button addFriendBtn;
    }
}