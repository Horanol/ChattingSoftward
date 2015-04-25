namespace 聊天软件_客户端
{
    partial class RegisterForm
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
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.sayingBox = new System.Windows.Forms.TextBox();
            this.sayingLabel = new System.Windows.Forms.Label();
            this.iconLabel = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.passwordErrorWarnLabel = new System.Windows.Forms.Label();
            this.userNameOccupiedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // iconBox
            // 
            this.iconBox.Location = new System.Drawing.Point(13, 70);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(120, 120);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 0;
            this.iconBox.TabStop = false;
            this.iconBox.Click += new System.EventHandler(this.iconBox_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameLabel.Location = new System.Drawing.Point(153, 30);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(93, 20);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "请输入用户名";
            // 
            // userNameBox
            // 
            this.userNameBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameBox.Location = new System.Drawing.Point(157, 53);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(180, 26);
            this.userNameBox.TabIndex = 2;
            this.userNameBox.TextChanged += new System.EventHandler(this.userNameBox_TextChanged);
            this.userNameBox.Leave += new System.EventHandler(this.userNameBox_Leave);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordLabel.Location = new System.Drawing.Point(153, 96);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(79, 20);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "请输入密码";
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordBox.Location = new System.Drawing.Point(157, 119);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(180, 26);
            this.passwordBox.TabIndex = 4;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.TextChanged += new System.EventHandler(this.passwordBox_TextChanged);
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmPasswordLabel.Location = new System.Drawing.Point(153, 159);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(107, 20);
            this.confirmPasswordLabel.TabIndex = 5;
            this.confirmPasswordLabel.Text = "请重复确认密码";
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmPasswordBox.Location = new System.Drawing.Point(157, 191);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.Size = new System.Drawing.Size(180, 26);
            this.confirmPasswordBox.TabIndex = 6;
            this.confirmPasswordBox.UseSystemPasswordChar = true;
            this.confirmPasswordBox.TextChanged += new System.EventHandler(this.confirmPasswordBox_TextChanged);
            this.confirmPasswordBox.Leave += new System.EventHandler(this.confirmPasswordBox_Leave);
            // 
            // sayingBox
            // 
            this.sayingBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sayingBox.Location = new System.Drawing.Point(13, 262);
            this.sayingBox.Multiline = true;
            this.sayingBox.Name = "sayingBox";
            this.sayingBox.Size = new System.Drawing.Size(324, 192);
            this.sayingBox.TabIndex = 7;
            this.sayingBox.TextChanged += new System.EventHandler(this.sayingBox_TextChanged);
            // 
            // sayingLabel
            // 
            this.sayingLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sayingLabel.Location = new System.Drawing.Point(92, 229);
            this.sayingLabel.Name = "sayingLabel";
            this.sayingLabel.Size = new System.Drawing.Size(184, 23);
            this.sayingLabel.TabIndex = 8;
            this.sayingLabel.Text = "一句话介绍一下你自己？";
            // 
            // iconLabel
            // 
            this.iconLabel.AutoSize = true;
            this.iconLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iconLabel.Location = new System.Drawing.Point(42, 37);
            this.iconLabel.Name = "iconLabel";
            this.iconLabel.Size = new System.Drawing.Size(65, 20);
            this.iconLabel.TabIndex = 9;
            this.iconLabel.Text = "设置头像";
            // 
            // submitBtn
            // 
            this.submitBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submitBtn.Location = new System.Drawing.Point(149, 467);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 28);
            this.submitBtn.TabIndex = 10;
            this.submitBtn.Text = "提交";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // passwordErrorWarnLabel
            // 
            this.passwordErrorWarnLabel.AutoSize = true;
            this.passwordErrorWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordErrorWarnLabel.Location = new System.Drawing.Point(266, 165);
            this.passwordErrorWarnLabel.Name = "passwordErrorWarnLabel";
            this.passwordErrorWarnLabel.Size = new System.Drawing.Size(89, 12);
            this.passwordErrorWarnLabel.TabIndex = 11;
            this.passwordErrorWarnLabel.Text = "两次密码不一致";
            this.passwordErrorWarnLabel.Visible = false;
            // 
            // userNameOccupiedLabel
            // 
            this.userNameOccupiedLabel.ForeColor = System.Drawing.Color.Red;
            this.userNameOccupiedLabel.Location = new System.Drawing.Point(266, 37);
            this.userNameOccupiedLabel.Name = "userNameOccupiedLabel";
            this.userNameOccupiedLabel.Size = new System.Drawing.Size(89, 12);
            this.userNameOccupiedLabel.TabIndex = 13;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 512);
            this.Controls.Add(this.userNameOccupiedLabel);
            this.Controls.Add(this.passwordErrorWarnLabel);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.iconLabel);
            this.Controls.Add(this.sayingLabel);
            this.Controls.Add(this.sayingBox);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.iconBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "注册新用户";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.TextBox confirmPasswordBox;
        private System.Windows.Forms.TextBox sayingBox;
        private System.Windows.Forms.Label sayingLabel;
        private System.Windows.Forms.Label iconLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label passwordErrorWarnLabel;
        private System.Windows.Forms.Label userNameOccupiedLabel;
    }
}