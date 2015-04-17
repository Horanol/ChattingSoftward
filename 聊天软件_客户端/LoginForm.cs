using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 聊天软件_客户端
{
    public partial class LoginForm : Form
    {
        public Client client;
        public string clientName;
        private Thread clientThread;
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


        }
        private void IniatializeContection()
        {
            client = new Client(this);
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

            clientName = this.userNameBox.Text;
            string password = this.passwordBox.Text;
            SignInProtocol pro = new SignInProtocol(clientName, password);
            string msg = pro.ToString();

            if (client.TryConnectToServer())
            {
                this.statusLabel.Text = "已连接服务器";
                if (!client.SendMessage(msg))
                {
                    MessageBox.Show("无法发送！");
                }

            }
            else
                MessageBox.Show("无法连接服务器！");

        }

        public void AcceptLogin()
        {
            //不能用新线程打开新窗口，这样线程结束后窗口会关闭
            //主线程的窗口不能关闭，只能隐藏
            //Thread clientMainThread = new Thread(new ThreadStart(OpenClientMainForm));
            //clientMainThread.Start();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void RefuseLogin()
        {
            MessageBox.Show("用户名或密码错误！");
        }
        private void OpenClientMainForm()
        {
            testForm mainForm = new testForm();
            mainForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }




    }
}
