using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 聊天软件_客户端
{
    public partial class ShowDetailInfoForm : Form
    {
        private PublicUserInfo info;
        private Client myClient;
        public ShowDetailInfoForm()
        {
            InitializeComponent();
        }
        public ShowDetailInfoForm(PublicUserInfo _info,Client _myClient)
        {
            InitializeComponent();
            info = _info;
            myClient = _myClient;
        }
        private void ShowDetailInfoForm_Load(object sender, EventArgs e)
        {
            //展示头像
            if (info.iconPath != "")
                iconBox.ImageLocation = info.iconPath;
            else
                iconBox.Image = global::聊天软件_客户端.Properties.Resources.cantFindPicture;
            //展示昵称和说说
            nameLabel.Text = info.name;
            sayingLabel.Text = info.saying;
        }

        private void addFriendBtn_Click(object sender, EventArgs e)
        {
            AddFriendsRequestProtocol pro = new AddFriendsRequestProtocol(myClient.clientName, info.name);
            string msg = pro.ToString();
            if (myClient.TryConnectToServer())
            {
                if (!myClient.SendMessage(msg))
                    MessageBox.Show("无法发送！");
                else
                {
                    MessageBox.Show(this, "好友请求已发送！", "提示");
                    this.Close();
                }
            }
            else
                MessageBox.Show("无法连接服务器！");
        }
    }
}
