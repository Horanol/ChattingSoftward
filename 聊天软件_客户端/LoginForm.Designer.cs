namespace 聊天软件_客户端
{
    partial class LoginForm
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
            this.userIconBox = new System.Windows.Forms.PictureBox();
            this.topBackgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.findPasswordBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.rememberUserNameCheckBox = new System.Windows.Forms.CheckBox();
            this.rememberPasswordCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.userIconBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBackgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userIconBox
            // 
            this.userIconBox.Image = global::聊天软件_客户端.Properties.Resources.cantFindPicture;
            this.userIconBox.Location = new System.Drawing.Point(22, 152);
            this.userIconBox.Name = "userIconBox";
            this.userIconBox.Size = new System.Drawing.Size(120, 120);
            this.userIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userIconBox.TabIndex = 0;
            this.userIconBox.TabStop = false;
            // 
            // topBackgroundPictureBox
            // 
            this.topBackgroundPictureBox.Location = new System.Drawing.Point(2, 0);
            this.topBackgroundPictureBox.Name = "topBackgroundPictureBox";
            this.topBackgroundPictureBox.Size = new System.Drawing.Size(500, 140);
            this.topBackgroundPictureBox.TabIndex = 1;
            this.topBackgroundPictureBox.TabStop = false;
            // 
            // userNameBox
            // 
            this.userNameBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameBox.Location = new System.Drawing.Point(166, 163);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(235, 29);
            this.userNameBox.TabIndex = 0;
            this.userNameBox.Text = "Joey";
            this.userNameBox.TextChanged += new System.EventHandler(this.userNameBox_TextChanged);
            this.userNameBox.Leave += new System.EventHandler(this.userNameBox_Leave);
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordBox.Location = new System.Drawing.Point(166, 193);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(235, 29);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.Text = "123";
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.TextChanged += new System.EventHandler(this.passwordBox_TextChanged);
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginBtn.Location = new System.Drawing.Point(197, 256);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(163, 34);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "登录";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // signUpBtn
            // 
            this.signUpBtn.Location = new System.Drawing.Point(416, 169);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(75, 23);
            this.signUpBtn.TabIndex = 3;
            this.signUpBtn.Text = "注册账号";
            this.signUpBtn.UseVisualStyleBackColor = true;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // findPasswordBtn
            // 
            this.findPasswordBtn.Location = new System.Drawing.Point(416, 199);
            this.findPasswordBtn.Name = "findPasswordBtn";
            this.findPasswordBtn.Size = new System.Drawing.Size(75, 23);
            this.findPasswordBtn.TabIndex = 4;
            this.findPasswordBtn.Text = "找回密码";
            this.findPasswordBtn.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(20, 281);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(122, 12);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "statusLabel";
            // 
            // rememberUserNameCheckBox
            // 
            this.rememberUserNameCheckBox.AutoSize = true;
            this.rememberUserNameCheckBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rememberUserNameCheckBox.Location = new System.Drawing.Point(181, 228);
            this.rememberUserNameCheckBox.Name = "rememberUserNameCheckBox";
            this.rememberUserNameCheckBox.Size = new System.Drawing.Size(84, 24);
            this.rememberUserNameCheckBox.TabIndex = 6;
            this.rememberUserNameCheckBox.Text = "记住账户";
            this.rememberUserNameCheckBox.UseVisualStyleBackColor = true;
            this.rememberUserNameCheckBox.CheckedChanged += new System.EventHandler(this.rememberUserNameCheckBox_CheckedChanged);
            // 
            // rememberPasswordCheckBox
            // 
            this.rememberPasswordCheckBox.AutoSize = true;
            this.rememberPasswordCheckBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rememberPasswordCheckBox.Location = new System.Drawing.Point(286, 228);
            this.rememberPasswordCheckBox.Name = "rememberPasswordCheckBox";
            this.rememberPasswordCheckBox.Size = new System.Drawing.Size(84, 24);
            this.rememberPasswordCheckBox.TabIndex = 7;
            this.rememberPasswordCheckBox.Text = "记住密码";
            this.rememberPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 302);
            this.Controls.Add(this.rememberPasswordCheckBox);
            this.Controls.Add(this.rememberUserNameCheckBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.findPasswordBtn);
            this.Controls.Add(this.signUpBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.topBackgroundPictureBox);
            this.Controls.Add(this.userIconBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 340);
            this.MinimumSize = new System.Drawing.Size(520, 340);
            this.Name = "LoginForm";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userIconBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBackgroundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox userIconBox;
        private System.Windows.Forms.PictureBox topBackgroundPictureBox;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Button findPasswordBtn;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox rememberUserNameCheckBox;
        private System.Windows.Forms.CheckBox rememberPasswordCheckBox;
    }
}