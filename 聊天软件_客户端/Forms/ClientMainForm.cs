using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 聊天软件_客户端
{
    public partial class ClientMainForm : Form
    {
        private Client myClient;
        private PublicUserInfo? userInfo;
        private int index = 0;
        private Dictionary<string, Customized_FriendsItemPanel> itemPanels;

        //一个静态Action委托，用于调用创建好友确认窗体的方法
        public static Action<Client, AddFriendsRequestProtocol> OnShowRespondRequestForm;
        //用于创建会话窗口
        public static Action<string> OnShowConversationForm;
        //更新好友列表
        public static Action OnUpdateFriendsList;

        public ClientMainForm()
        {
            InitializeComponent();
        }
        public ClientMainForm(Client client)
        {
            myClient = client;
            itemPanels = new Dictionary<string, Customized_FriendsItemPanel>();
            InitializeComponent();
            OnShowRespondRequestForm += ShowRespondRequestForm;
            OnShowConversationForm += ShowConversationForm;
            OnUpdateFriendsList += UpdateFriendsList;
        }
        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            InitializeUserInfo();
            InitializeFriendsList();
        }
        private void InitializeUserInfo()
        {
            userInfo = UserInfo.GetPublicUserInfo(myClient.clientName);
            if (userInfo != null)//或写成info.hasValue
            {
                this.nameLabel.Text = userInfo.Value.name;//注意要通过Value获取值

                if (userInfo.Value.saying != "")
                    this.sayingLabel.Text = userInfo.Value.saying;
                if (userInfo.Value.iconPath != "")
                    this.iconBox.ImageLocation = userInfo.Value.iconPath;
            }
        }
        /// <summary>
        ///从UserInfo中读取用户好友信息，构建好友列表
        /// </summary>
        public void InitializeFriendsList()
        {
            try
            {
                this.friendsListPanel.Controls.Clear();
                PrivateUserInfo? info = UserInfo.GetPrivateUserInfo(myClient.clientName);
                PublicUserInfo?[] friendsInfo = new PublicUserInfo?[info.Value.friendsName.Length];
                if (info != null)
                {
                    for (int i = 0; i < friendsInfo.Length; i++)
                    {
                        friendsInfo[i] = UserInfo.GetPublicFriendsInfo(info.Value.friendsName[i]);
                    }
                }
                GenerateFriendsItems(friendsInfo);
            }
            catch
            {
 
            }

        }
        public void UpdateFriendsList()
        {
            this.Invoke(new Action(InitializeFriendsList));
        }
        private void GenerateFriendsItems(PublicUserInfo?[] info)
        {
            this.SuspendLayout();
            this.friendsListPanel.VerticalScroll.Value = 0;
            for (int i = 0; i < info.Length; i++)
            {
                if (info[i] != null)
                {
                    Customized_FriendsItemPanel itemPanel = new Customized_FriendsItemPanel(index);
                    itemPanel.SetInitialzation((PublicUserInfo)info[i]);
                    this.friendsListPanel.Controls.Add(itemPanel.singleFriendsPanel);
                    itemPanels.Add(info[i].Value.name, itemPanel);
                    index++;
                }
            }
            this.ResumeLayout();
            this.PerformLayout();
        }

        private void addFriendsBtn_Click(object sender, EventArgs e)
        {
            AddFriendsForm adForm = new AddFriendsForm(myClient);
            adForm.Show();
        }

        private void JoeyBtn_Click(object sender, EventArgs e)
        {
            ConversationForm JoeyForm = new ConversationForm("Joey", "tt", myClient);
            JoeyForm.Show();
        }

        private void ttBtn_Click(object sender, EventArgs e)
        {
            ConversationForm ttForm = new ConversationForm("tt", "Joey", myClient);
            ttForm.Show();
        }

        private void ShowRespondRequestForm(Client _client, AddFriendsRequestProtocol _pro)
        {
            //在监听线程里调用这个委托方法
            //这里用Invoke表示通过主UI线程创建窗体
            //括号里面传入一个匿名的无参Action委托
            //委托里传入一个匿名无参方法

            //this.Invoke(new Action(delegate(){
            //    RespondFriendsRequestForm fo = new RespondFriendsRequestForm(_client, _pro);
            //    fo.Show();
            //}));

            //或者这样写，通过Invoke传递两个参数
            //匿名Action接受两个参数
            //Action括号里的匿名方法接受两个参数

            this.Invoke(new Action<Client, AddFriendsRequestProtocol>(
                delegate(Client cl, AddFriendsRequestProtocol pro)
                {
                    AddFriendsRespondForm fo = new AddFriendsRespondForm(cl, pro);
                    fo.Show();
                }),
                new object[] { _client, _pro });
        }

        public void ShowConversationForm(string friendsName)
        {
            ConversationForm newForm = new ConversationForm(myClient.clientName, friendsName, myClient);
            newForm.Show();
        }




    }
}
