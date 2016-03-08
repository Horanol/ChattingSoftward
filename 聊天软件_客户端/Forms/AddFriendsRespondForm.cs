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
    public partial class AddFriendsRespondForm : Form
    {
        private Client myClient;
        private AddFriendsRequestProtocol pro;

        //public RespondFriendsRequestForm()
        //{
        //    InitializeComponent();
        //}
        public AddFriendsRespondForm(Client _client, AddFriendsRequestProtocol _pro)
        {
            InitializeComponent();
            myClient = _client;
            pro = _pro;
        }

        /// <summary>
        /// 点击确认按钮时，向服务器发送好友确认信息，
        /// 向服务器发送好友信息请求
        /// 并在本地的UserInfo中修改好友关系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptBtn_Click(object sender, EventArgs e)
        {
            AddFriendsRespondProtocol respondPro = new AddFriendsRespondProtocol(pro.sponsor, pro.respondent, "Accepted");
            if (myClient.TryConnectToServer())
            {
                if (myClient.SendMessage(respondPro.ToString()))
                {
                    //修改好友关系
                    UserInfo.AddFriend(pro.respondent, pro.sponsor);
                    //发送好友信息请求
                    GetFriendsInfoProtocol getPro = new GetFriendsInfoProtocol(pro.sponsor);
                    myClient.SendMessage(getPro.ToString());


                    this.Close();
                }
                else
                    MessageBox.Show("无法发送！");
            }
            else
                MessageBox.Show("无法连接服务器！");
        }
        /// <summary>
        /// 点击拒绝按钮时，向服务器发送拒绝好友请求的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rejectBtn_Click(object sender, EventArgs e)
        {
            AddFriendsRespondProtocol respondPro = new AddFriendsRespondProtocol(pro.sponsor, pro.respondent, "Rejected");
            if (myClient.TryConnectToServer())
            {
                if (!myClient.SendMessage(respondPro.ToString()))
                    MessageBox.Show("无法发送！");
                else
                {
                    this.Close();
                }
            }
            else
                MessageBox.Show("无法连接服务器！");
        }
        private void RespondFriendsRequestForm_Load(object sender, EventArgs e)
        {
            //这里的myName 就是指发起好友请求的一方的名字
            this.nameLabel.Text = pro.sponsor;
        }




    }
}
