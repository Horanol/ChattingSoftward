namespace 聊天软件_客户端
{
    partial class AddFriendsRespondForm
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
            this.tipsLabel = new System.Windows.Forms.Label();
            this.rejectBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // iconBox
            // 
            this.iconBox.Image = global::聊天软件_客户端.Properties.Resources.草泥马;
            this.iconBox.Location = new System.Drawing.Point(29, 12);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(130, 220);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 0;
            this.iconBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameLabel.Location = new System.Drawing.Point(165, 46);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(272, 46);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Joey";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tipsLabel
            // 
            this.tipsLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipsLabel.Location = new System.Drawing.Point(165, 163);
            this.tipsLabel.Name = "tipsLabel";
            this.tipsLabel.Size = new System.Drawing.Size(272, 28);
            this.tipsLabel.TabIndex = 2;
            this.tipsLabel.Text = "请求添加你为好友";
            this.tipsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rejectBtn
            // 
            this.rejectBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rejectBtn.Location = new System.Drawing.Point(261, 255);
            this.rejectBtn.Name = "rejectBtn";
            this.rejectBtn.Size = new System.Drawing.Size(160, 35);
            this.rejectBtn.TabIndex = 4;
            this.rejectBtn.Text = "滚！";
            this.rejectBtn.UseVisualStyleBackColor = true;
            this.rejectBtn.Click += new System.EventHandler(this.rejectBtn_Click);
            // 
            // acceptBtn
            // 
            this.acceptBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.acceptBtn.Location = new System.Drawing.Point(76, 255);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(160, 35);
            this.acceptBtn.TabIndex = 5;
            this.acceptBtn.Text = "一开始我是接受的";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // RespondFriendsRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 306);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.rejectBtn);
            this.Controls.Add(this.tipsLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.iconBox);
            this.Name = "RespondFriendsRequestForm";
            this.Text = "好友验证";
            this.Load += new System.EventHandler(this.RespondFriendsRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label tipsLabel;
        private System.Windows.Forms.Button rejectBtn;
        private System.Windows.Forms.Button acceptBtn;
    }
}