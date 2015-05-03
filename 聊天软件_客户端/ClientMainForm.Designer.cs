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
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sayingLabel = new System.Windows.Forms.Label();
            this.JoeyBtn = new System.Windows.Forms.Button();
            this.ttBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconBox
            // 
            this.iconBox.Location = new System.Drawing.Point(8, 3);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(120, 120);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 0;
            this.iconBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameLabel.Location = new System.Drawing.Point(143, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(161, 23);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "test";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(7, 129);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(297, 374);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(8, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "添加好友";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ttBtn);
            this.panel1.Controls.Add(this.JoeyBtn);
            this.panel1.Controls.Add(this.sayingLabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.iconBox);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 565);
            this.panel1.TabIndex = 5;
            // 
            // sayingLabel
            // 
            this.sayingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sayingLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sayingLabel.Location = new System.Drawing.Point(143, 38);
            this.sayingLabel.Name = "sayingLabel";
            this.sayingLabel.Size = new System.Drawing.Size(157, 85);
            this.sayingLabel.TabIndex = 5;
            this.sayingLabel.Text = "今天是个好日子";
            // 
            // JoeyBtn
            // 
            this.JoeyBtn.Location = new System.Drawing.Point(54, 248);
            this.JoeyBtn.Name = "JoeyBtn";
            this.JoeyBtn.Size = new System.Drawing.Size(75, 23);
            this.JoeyBtn.TabIndex = 6;
            this.JoeyBtn.Text = "JoeyBtn";
            this.JoeyBtn.UseVisualStyleBackColor = true;
            this.JoeyBtn.Click += new System.EventHandler(this.JoeyBtn_Click);
            // 
            // ttBtn
            // 
            this.ttBtn.Location = new System.Drawing.Point(54, 315);
            this.ttBtn.Name = "ttBtn";
            this.ttBtn.Size = new System.Drawing.Size(75, 23);
            this.ttBtn.TabIndex = 7;
            this.ttBtn.Text = "ttBtn";
            this.ttBtn.UseVisualStyleBackColor = true;
            this.ttBtn.Click += new System.EventHandler(this.ttBtn_Click);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 582);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(500, 700);
            this.MinimumSize = new System.Drawing.Size(344, 450);
            this.Name = "ClientMainForm";
            this.Text = "六度聊天软件";
            this.Load += new System.EventHandler(this.ClientMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sayingLabel;
        private System.Windows.Forms.Button ttBtn;
        private System.Windows.Forms.Button JoeyBtn;
    }
}

