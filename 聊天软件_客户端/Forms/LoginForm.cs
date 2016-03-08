using System;
using System.Windows.Forms;
using System.Threading;

namespace 聊天软件_客户端
{
    public partial class LoginForm : Form
    {
        public Client client;
        private string clientName = "";
        private string password = "";
        private Thread clientThread;

        //声明静态的委托，使得其他类可以调用委托绑定的方法
        public static Action OnAcceptLogin;
        public static Action OnRefuseLogin;
        public static Action OnAlreadyLogin;

        public RegisterForm registerForm;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            clientThread = new Thread(new ThreadStart(IniatializeContection));
            //默认是前台线程，要设置成后台线程，在主窗口关闭后结束线程
            clientThread.IsBackground = true;
            clientThread.Name = "IniatializeContectionThread";
            clientThread.Start();

            //使其他线程能操作主窗口的控件
            Control.CheckForIllegalCrossThreadCalls = false;

            clientName = 聊天软件_客户端.Properties.Settings.Default.rememberedName;
            userNameBox.Text = clientName;

            password = 聊天软件_客户端.Properties.Settings.Default.rememberedPassword;
            passwordBox.Text = password;

            this.rememberUserNameCheckBox.Checked = 聊天软件_客户端.Properties.Settings.Default.userNameBoxChecked;
            this.rememberPasswordCheckBox.Checked = 聊天软件_客户端.Properties.Settings.Default.passwordBoxChecked;
            //绑定登录和拒绝登录方法
            OnAcceptLogin += AcceptLogin;
            OnRefuseLogin += RefuseLogin;
            OnAlreadyLogin += AlreadyLogin;
        }
        private void IniatializeContection()
        {
            client = new Client();
            if (client.TryConnectToServer())
            {
                this.statusLabel.Text = "已连接服务器";
            }
            else
            {
                this.statusLabel.Text = "未连接服务器";
            }
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (clientName == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            else
            {
                SignInProtocol pro = new SignInProtocol(clientName, password);
                string msg = pro.ToString();
                if (client.TryConnectToServer())
                {
                    this.statusLabel.Text = "已连接服务器";
                    if (!client.SendMessage(msg))
                        MessageBox.Show("无法发送！");
                }
                else
                    MessageBox.Show("无法连接服务器！");

            }
        }
        private void AcceptLogin()
        {
            //不能用新线程打开新窗口，这样线程结束后窗口会关闭
            //主线程的窗口不能关闭，只能隐藏
            //Thread clientMainThread = new Thread(new ThreadStart(OpenClientMainForm));
            //clientMainThread.Start();
            //登录成功，设置client的clientName
            client.clientName = this.clientName;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void RefuseLogin()
        {
            MessageBox.Show("用户名或密码错误！");
        }
        private void AlreadyLogin()
        {
            MessageBox.Show("当前用户已经登录！");
        }
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            if (registerForm == null || registerForm.IsDisposed)
            {
                registerForm = new RegisterForm(client);
                registerForm.Show();
            }
            else
            {
                //若窗体被最小化了，把它正常化并聚焦
                if (registerForm.WindowState == FormWindowState.Minimized)
                {
                    registerForm.WindowState = FormWindowState.Normal;
                }
                registerForm.Focus();
            }
        }

        private void userNameBox_Leave(object sender, EventArgs e)
        {
            PublicUserInfo? publicInfo = UserInfo.GetPublicUserInfo(clientName);
            if (publicInfo != null)
            {
                if(publicInfo.Value.iconPath != "")
                     userIconBox.ImageLocation = publicInfo.Value.iconPath;
                else
                    userIconBox.Image = global::聊天软件_客户端.Properties.Resources.cantFindPicture;
            }
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {
            clientName = this.userNameBox.Text;
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            password = this.passwordBox.Text;
        }

        private void rememberUserNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rememberUserNameCheckBox.Checked)
            {
                聊天软件_客户端.Properties.Settings.Default.rememberedName = this.userNameBox.Text;
                聊天软件_客户端.Properties.Settings.Default.userNameBoxChecked = true;
                聊天软件_客户端.Properties.Settings.Default.Save();
            }
            else
            {
                聊天软件_客户端.Properties.Settings.Default.rememberedName = "";
                聊天软件_客户端.Properties.Settings.Default.userNameBoxChecked = false;
                聊天软件_客户端.Properties.Settings.Default.Save(); 
            }
        }

        private void rememberPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rememberPasswordCheckBox.Checked)
            {
                聊天软件_客户端.Properties.Settings.Default.rememberedPassword = this.passwordBox.Text;
                聊天软件_客户端.Properties.Settings.Default.passwordBoxChecked = true;
                聊天软件_客户端.Properties.Settings.Default.Save();
            }
            else
            {
                聊天软件_客户端.Properties.Settings.Default.rememberedPassword = "";
                聊天软件_客户端.Properties.Settings.Default.passwordBoxChecked = false;
                聊天软件_客户端.Properties.Settings.Default.Save();
            }
        }







    }
}
