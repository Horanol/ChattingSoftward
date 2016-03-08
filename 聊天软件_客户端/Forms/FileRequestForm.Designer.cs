namespace 聊天软件_客户端
{
    partial class FileRequestForm
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
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.tipsLabel2 = new System.Windows.Forms.Label();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.rejectBtn = new System.Windows.Forms.Button();
            this.tipsLabel3 = new System.Windows.Forms.Label();
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
            this.iconBox.TabIndex = 1;
            this.iconBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameLabel.Location = new System.Drawing.Point(174, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(272, 46);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Joey";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tipsLabel
            // 
            this.tipsLabel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipsLabel.Location = new System.Drawing.Point(165, 58);
            this.tipsLabel.Name = "tipsLabel";
            this.tipsLabel.Size = new System.Drawing.Size(306, 28);
            this.tipsLabel.TabIndex = 3;
            this.tipsLabel.Text = "这货要发给你这个叫";
            this.tipsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.fileNameLabel.Location = new System.Drawing.Point(165, 107);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(306, 28);
            this.fileNameLabel.TabIndex = 4;
            this.fileNameLabel.Text = "文件名.扩展名";
            this.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tipsLabel2
            // 
            this.tipsLabel2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipsLabel2.Location = new System.Drawing.Point(176, 152);
            this.tipsLabel2.Name = "tipsLabel2";
            this.tipsLabel2.Size = new System.Drawing.Size(295, 28);
            this.tipsLabel2.TabIndex = 5;
            this.tipsLabel2.Text = "的文（zhong）件（zi）";
            this.tipsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.acceptBtn.Location = new System.Drawing.Point(58, 259);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(160, 35);
            this.acceptBtn.TabIndex = 6;
            this.acceptBtn.Text = "老夫笑纳了";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // rejectBtn
            // 
            this.rejectBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rejectBtn.Location = new System.Drawing.Point(277, 259);
            this.rejectBtn.Name = "rejectBtn";
            this.rejectBtn.Size = new System.Drawing.Size(160, 35);
            this.rejectBtn.TabIndex = 7;
            this.rejectBtn.Text = "滚！";
            this.rejectBtn.UseVisualStyleBackColor = true;
            // 
            // tipsLabel3
            // 
            this.tipsLabel3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipsLabel3.Location = new System.Drawing.Point(165, 192);
            this.tipsLabel3.Name = "tipsLabel3";
            this.tipsLabel3.Size = new System.Drawing.Size(295, 28);
            this.tipsLabel3.TabIndex = 8;
            this.tipsLabel3.Text = "客官接受否？";
            this.tipsLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 306);
            this.Controls.Add(this.tipsLabel3);
            this.Controls.Add(this.rejectBtn);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.tipsLabel2);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.tipsLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.iconBox);
            this.Name = "FileRequestForm";
            this.Text = "文件接受请求";
            this.Load += new System.EventHandler(this.FileRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label tipsLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label tipsLabel2;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button rejectBtn;
        private System.Windows.Forms.Label tipsLabel3;
    }
}