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
    public partial class ClientMainForm : Form
    {
        private Client myClient;
        private PublicUserInfo? info;

        //一个静态Action委托，用于调用创建好友确认窗体的方法
        public static Action<Client, AddFriendsRequestProtocol> OnShowRespondRequestForm;

        public ClientMainForm()
        {
            InitializeComponent();
        }
        public ClientMainForm(Client client)
        {
            myClient = client;
            InitializeComponent();
            OnShowRespondRequestForm += ShowRespondRequestForm;
        }
        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            info = UserInfo.GetPublicUserInfo(myClient.clientName);
            if (info != null)//或写成info.hasValue
            {
                this.nameLabel.Text = info.Value.name;//注意要通过Value获取值

                if(info.Value.saying != "")
                    this.sayingLabel.Text = info.Value.saying;
                if(info.Value.iconPath != "")
                    this.iconBox.ImageLocation = info.Value.iconPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                delegate(Client cl, AddFriendsRequestProtocol pro){
                    AddFriendsRespondForm fo = new AddFriendsRespondForm(cl, pro);
                    fo.Show();
                }),
                new object[] { _client, _pro });
        }


    }
}
