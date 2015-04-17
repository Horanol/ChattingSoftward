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
    public partial class ConversationForm : Form
    {
        private string destinationName;
        private string sourceName;
        private Client client;
        public ConversationForm(string _sourceName,string _destinationName,Client _client)
        {
            InitializeComponent();
            destinationName = _destinationName;
            sourceName = _sourceName;
            client = _client;
        }
        public ConversationForm()
        {
            InitializeComponent();
        }

        private void shakeBtn_Click(object sender, EventArgs e)
        {

        }

        private void ConversationForm_Load(object sender, EventArgs e)
        {
            this.Text = "和" + destinationName + "的会话";
        }

        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            string msg = this.sendMessageBox.Text;
            MessageProtocol pro = new MessageProtocol(sourceName, destinationName, msg);
            string newMsg = pro.ToString();
            if (client.TryConnectToServer())
            {
                if (client.SendMessage(newMsg))
                {
                    showMessageBox.Text += msg;
                    statusLabel.Text = "发送成功";
                }
                else
                    statusLabel.Text = "发送失败";
            }
            else
                statusLabel.Text = "无法连接服务器";
        }
    }
}
