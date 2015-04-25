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
        private UserDetailInfo? info;
        public ClientMainForm()
        {
            InitializeComponent();
        }
        public ClientMainForm(Client client)
        {
            myClient = client;
            InitializeComponent();
        }
        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            info = UserInfo.GetUserDetailInfo(myClient.clientName);
            if (info != null)//或写成info.hasValue
            {
                this.nameLabel.Text = info.Value.userName;//注意要通过Value获取值
                this.sayingLabel.Text = info.Value.sayings;
                this.iconBox.ImageLocation = info.Value.iconPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFriendsForm adForm = new AddFriendsForm();
            adForm.Show();
        }




    }
}
