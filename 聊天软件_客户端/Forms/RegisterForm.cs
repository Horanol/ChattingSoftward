using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 聊天软件_客户端
{
    public partial class RegisterForm : Form
    {
        private Client client;
        private string selectIconPath = "";
        private string IconBufferPath = "";
        private string userName = "";
        private string userPassword = "";
        private string userConfirmPassword = "";
        private string userSaying = "";
        private bool userNameIsChanged = false;
        public static Action<bool> OnCheckUserName;

        public RegisterForm()
        {
            InitializeComponent();
        }
        public RegisterForm(Client _client)
        {
            InitializeComponent();
            client = _client;
            //这种方法的路径名后面没有"\"符号，要自行添加
            IconBufferPath = Environment.CurrentDirectory + "\\IconBuffer";
            if (!Directory.Exists(IconBufferPath))
            {
                Directory.CreateDirectory(IconBufferPath);
            }
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            OnCheckUserName += CheckUserName;
        }
        private void iconBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "图片文件(*.jpg,*.gif,*.bmp)|*.jpg;*.gif;*.bmp";//  |  号前面是注释，后面是过滤的扩展名，用逗号隔开
            ofd.RestoreDirectory = false;//关闭对话框前还原原来路径
            ofd.Title = "请选择头像";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectIconPath = ofd.FileName;
            }
            //在头像窗口中暂时显示头像
            iconBox.ImageLocation = selectIconPath;
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {
            userName = userNameBox.Text;
            userNameIsChanged = true;
        }
        private void userNameBox_Leave(object sender, EventArgs e)
        {
            if (userNameIsChanged)
            {
                SignInProtocol pro = new SignInProtocol(userName, "");
                if (!client.SendMessage(pro.ToString()))
                {
                    MessageBox.Show("无法连接服务器！");
                }
                userNameIsChanged = false;
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            userPassword = passwordBox.Text;
        }

        private void confirmPasswordBox_TextChanged(object sender, EventArgs e)
        {
            userConfirmPassword = confirmPasswordBox.Text;
        }

        private void confirmPasswordBox_Leave(object sender, EventArgs e)
        {
            if (userConfirmPassword != userPassword)
            {
                passwordErrorWarnLabel.Visible = true;
            }
            else
            {
                passwordErrorWarnLabel.Visible = false;
            }
        }

        private void sayingBox_TextChanged(object sender, EventArgs e)
        {
            userSaying = sayingBox.Text;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            if (userName == "")
            {
                MessageBox.Show("请输入用户名！");
            }
            else if (userPassword == "")
            {
                MessageBox.Show("请输入密码！");
            }
            else if (userConfirmPassword == "")
            {
                MessageBox.Show("请确认密码！");
            }
            else if (passwordErrorWarnLabel.Visible == true)
            {
                MessageBox.Show("两次密码不一致！");
            }
            else if (userNameOccupiedLabel.Text != "")
            {
                MessageBox.Show("用户名已被占用！");
            }
            else
            {
                SubmitUserInfo();
            }
        }
        private void SubmitUserInfo()
        {
            UserDetailInfo info;
            if (selectIconPath != "")
            {
                //提取图片后缀名并构造新的图片缓存路径
                string newIconExtension = Path.GetExtension(selectIconPath);
                string newIconPathWithFullName = IconBufferPath + "\\" + "Icon_" + userName + newIconExtension;

                //把图片从用户选定路径复制到程序所在目录下的图片缓存目录
                File.Copy(selectIconPath, newIconPathWithFullName, true);

                //用新的图片路径构造UserDetailInfo
                info = new UserDetailInfo(userName, userPassword, userSaying, newIconPathWithFullName,null);
            }
            else
                info = new UserDetailInfo(userName, userPassword, userSaying, "",null);

            //构建UserDetailInfoProtocol协议消息并提交给服务器
            UserDetailInfoProtocol infoPro = new UserDetailInfoProtocol(info);

            //若有头像，则先发送头像过去
            if (infoPro.iconPath != "")
            {
                FileHandler handler = new FileHandler(client);
                //若头像发送成功，则继续保存其他信息
                if (handler.SendFile(client.clientIPAddress.ToString(),"server",info.iconPath))
                    goto SendMessage;
                else
                    MessageBox.Show("无法发送头像！");
            }//若没有头像，直接保存其他信息
            else
                goto SendMessage;
            //保存其他信息
        SendMessage:
            if (client.SendMessage(infoPro.ToString()))
            {
                //本地保存用户信息
                UserInfo.SaveNewUserInfo(info);
                MessageBox.Show("提交成功！");
                this.Close();
            }
            else
                MessageBox.Show("无法连接服务器！");

        }
        private void CheckUserName(bool available)
        {
            //这里有一个很奇怪的bug，当userNameOccupiedLabel.visable初始为false时，
            //就不能用visable来控制它了，可能跟用委托调用有关
            if (available)
                userNameOccupiedLabel.Text = "";
            else
                userNameOccupiedLabel.Text = "用户名已被占用";
        }





    }
}
