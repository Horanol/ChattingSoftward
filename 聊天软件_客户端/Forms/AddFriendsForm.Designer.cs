namespace 聊天软件_客户端
{
    partial class AddFriendsForm
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
            this.inputNameBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.showInfosPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // inputNameBox
            // 
            this.inputNameBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputNameBox.Location = new System.Drawing.Point(33, 34);
            this.inputNameBox.Name = "inputNameBox";
            this.inputNameBox.Size = new System.Drawing.Size(401, 29);
            this.inputNameBox.TabIndex = 0;
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchBtn.Location = new System.Drawing.Point(504, 34);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(110, 29);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "查找";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchLabel.Location = new System.Drawing.Point(179, 9);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(107, 20);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "请输入对方昵称";
            // 
            // showInfosPanel
            // 
            this.showInfosPanel.AutoScroll = true;
            this.showInfosPanel.Location = new System.Drawing.Point(33, 74);
            this.showInfosPanel.Name = "showInfosPanel";
            this.showInfosPanel.Size = new System.Drawing.Size(610, 310);
            this.showInfosPanel.TabIndex = 0;
            // 
            // AddFriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 402);
            this.Controls.Add(this.showInfosPanel);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.inputNameBox);
            this.MaximumSize = new System.Drawing.Size(680, 440);
            this.MinimumSize = new System.Drawing.Size(680, 440);
            this.Name = "AddFriendsForm";
            this.Text = "添加好友";
            this.Load += new System.EventHandler(this.AddFriendsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputNameBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Panel showInfosPanel;

    }
}