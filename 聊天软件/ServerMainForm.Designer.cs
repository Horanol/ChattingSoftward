namespace 聊天软件
{
    partial class ServerMainForm
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
            this.serverLogBox = new System.Windows.Forms.TextBox();
            this.ipAddressBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listenBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverLogBox
            // 
            this.serverLogBox.Location = new System.Drawing.Point(97, 105);
            this.serverLogBox.Multiline = true;
            this.serverLogBox.Name = "serverLogBox";
            this.serverLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverLogBox.Size = new System.Drawing.Size(443, 359);
            this.serverLogBox.TabIndex = 0;
            // 
            // ipAddressBox
            // 
            this.ipAddressBox.Location = new System.Drawing.Point(95, 53);
            this.ipAddressBox.Name = "ipAddressBox";
            this.ipAddressBox.Size = new System.Drawing.Size(148, 21);
            this.ipAddressBox.TabIndex = 1;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(304, 53);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(99, 21);
            this.portBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口号";
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(454, 50);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(75, 23);
            this.listenBtn.TabIndex = 5;
            this.listenBtn.Text = "开始监听";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.listenBtn_Click);
            // 
            // ServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 537);
            this.Controls.Add(this.serverLogBox);
            this.Controls.Add(this.listenBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipAddressBox);
            this.Name = "ServerMainForm";
            this.Text = "ServerMainForm";
            this.Load += new System.EventHandler(this.ServerMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddressBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button listenBtn;
        public System.Windows.Forms.TextBox serverLogBox;


    }
}

