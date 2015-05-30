using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Media;
namespace 聊天软件_客户端
{
    public partial class ClientMainForm : Form
    {
        private Client myClient;
        private PublicUserInfo? userInfo;
        private int index = 0;
        private int notifyIconChangeIndex;
        private Dictionary<string, Customized_FriendsItemPanel> itemPanels;

        private AddFriendsForm adForm;

        private Dictionary<string, List<string>> conversationBufferDictionary;

        //用于创建好友确认窗口
        public static Action<Client, AddFriendsRequestProtocol> OnShowRespondRequestForm;
        //用于创建会话窗口
        public static Action<string> OnShowConversationForm;
        //用于创建文件接受确认窗口
        public static Action<SendFileRequestProtocol> OnShowFileRequestForm;
        //更新好友列表
        public static Action OnUpdateFriendsList;
        //接受新的未接消息
        public static Action<string, string> OnReceiveMsgInMainPanel;

        #region 与主面板初始化相关方法
        public ClientMainForm()
        {
            InitializeComponent();
        }
        public ClientMainForm(Client client)
        {
            myClient = client;
            itemPanels = new Dictionary<string, Customized_FriendsItemPanel>();
            conversationBufferDictionary = new Dictionary<string, List<string>>();

            InitializeComponent();

        }
        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            InitializeUserInfo();
            InitializeFriendsList();
            GetOfflineMsg();

            OnShowRespondRequestForm += ShowRespondRequestForm;
            OnShowConversationForm += ShowConversationForm;
            OnUpdateFriendsList += UpdateFriendsList;
            OnReceiveMsgInMainPanel += ReceiveMsgInMainPanel;
            OnShowFileRequestForm += ShowFileRequestForm;
        }
        private void InitializeUserInfo()
        {
            userInfo = UserInfo.GetPublicUserInfo(myClient.clientName);
            if (userInfo != null)//或写成info.hasValue
            {
                //设置名字标签和托盘图标的提示语
                this.nameLabel.Text = userInfo.Value.name;
                this.notifyIcon.Text = "昵称：" + userInfo.Value.name;

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
                if (info != null)
                {
                    if (info.Value.friendsName != null)
                    {
                        PublicUserInfo?[] friendsInfo = new PublicUserInfo?[info.Value.friendsName.Length];

                        for (int i = 0; i < friendsInfo.Length; i++)
                        {
                            friendsInfo[i] = UserInfo.GetPublicFriendsInfo(info.Value.friendsName[i]);
                        }
                        GenerateFriendsItems(friendsInfo);
                    }
                }

            }
            catch
            {

            }

        }
        private void GetOfflineMsg()
        {
            MessageProtocol pro = new MessageProtocol("client", "", "ReadyToReceiveOfflineMsg");
            myClient.SendMessage(pro.ToString());
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
        #endregion


        #region 由主面板创建的其他窗口方法
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
            //确保只出现一个对话窗口
            if (!LogicController.dictionary.ContainsKey(friendsName))
            {
                ConversationForm newForm = new ConversationForm(myClient.clientName, friendsName);
                newForm.Show();
            }
            else
            {
                if (LogicController.dictionary[friendsName].WindowState == FormWindowState.Minimized)
                {
                    LogicController.dictionary[friendsName].WindowState = FormWindowState.Normal;
                }
                LogicController.dictionary[friendsName].Focus();
            }
        }
        private void ShowReceivedMsgForms()
        {
            foreach (string name in conversationBufferDictionary.Keys)
            {
                ConversationForm newForm = new ConversationForm(myClient.clientName, name);
                newForm.Show();
                foreach (string msg in conversationBufferDictionary[name])
                {
                    newForm.ReceiveMessage(msg);
                }
            }
        }
        private void addFriendsBtn_Click(object sender, EventArgs e)
        {
            if (adForm == null)
                adForm = new AddFriendsForm(myClient);
            adForm.Show();
        }
        private void ShowFileRequestForm(SendFileRequestProtocol pro)
        {
            this.Invoke(new Action(delegate()
            {
                FileRequestForm form = new FileRequestForm(pro);
                form.Show();
            }));
        }
        #endregion

        #region 作用于主面板上的方法
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            if (blinkTimer.Enabled == true)
            {
                blinkTimer.Enabled = false;
                this.notifyIcon.Icon = (System.Drawing.Icon)聊天软件_客户端.Properties.Resources.mainIcon;
                ShowReceivedMsgForms();
                conversationBufferDictionary.Clear();

            }
        }
        private void ClientMainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        //主面板接受到消息后，缓存到字典中
        public void ReceiveMsgInMainPanel(string friendsName, string msg)
        {
            if (conversationBufferDictionary.ContainsKey(friendsName))
            {
                conversationBufferDictionary[friendsName].Add(msg);
            }
            else
            {
                List<string> newStr = new List<string>();
                newStr.Add(msg);
                conversationBufferDictionary.Add(friendsName, newStr);
            }
            ShowNewMsgEffect();
        }
        private void ShowNewMsgEffect()
        {
            this.Invoke(new Action(delegate()
            {
                //图标闪动
                blinkTimer.Start();
                //播放消息音效
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"E:\CPlusProject\LearnTCPProgramming\聊天软件_客户端\sounds\msg.wav";
                player.Play();
            }));

        }
        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            if (notifyIconChangeIndex == 0)
            {
                this.notifyIcon.Icon = (System.Drawing.Icon)聊天软件_客户端.Properties.Resources.mainIcon;
                notifyIconChangeIndex = 1;
                return;
            }
            else
            {
                this.notifyIcon.Icon = (System.Drawing.Icon)聊天软件_客户端.Properties.Resources.tranparentIcon;
                notifyIconChangeIndex = 0;
                return;
            }
        }
        #endregion







    }
}
