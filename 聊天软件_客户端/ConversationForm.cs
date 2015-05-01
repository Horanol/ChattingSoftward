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
        private  int currentHeight = 0;
        private UserDetailInfo? info;

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
            info = UserInfo.GetUserDetailInfo(sourceName);

        }

        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            string msg = this.sendMessageBox.Text;
            if (msg != "")
            {
                MessageProtocol pro = new MessageProtocol(sourceName, destinationName, msg);
                string newMsg = pro.ToString();
                SendMessageShow(msg);
                this.sendMessageBox.Text = "";
            }
                //if (client.TryConnectToServer())
            //{
                //if (client.SendMessage(newMsg))
                //{
                //    SendMessage(msg);
                //    SendMessageShow(msg);
                //    statusLabel.Text = "发送成功";
                //}
                //else
                //    statusLabel.Text = "发送失败";
            //}
            //else
            //    statusLabel.Text = "无法连接服务器";
        }
        private void SendMessage(string str)
        {
 
        }
        /// <summary>
        /// 发送信息显示框，在右边
        /// </summary>
        /// <param name="str"></param>
        private void SendMessageShow(string str)
        {
            //设置iconBox
            PictureBox iconBox = new PictureBox();
            if (info == null)
            {
                iconBox.Image = global::聊天软件_客户端.Properties.Resources.cantFindPicture;
            }
            else
            {
                iconBox.ImageLocation = info.Value.iconPath;
            }
            iconBox.Location = new System.Drawing.Point(580, 0);
            iconBox.Size = new System.Drawing.Size(40, 40);
            iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            iconBox.TabStop = false;

            //设置messageLabel
            Label messageLabel = new Label();
            //默认从代码段实例化的Label是固定大小的,100*23
            messageLabel.AutoSize = true;
            messageLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            messageLabel.Text = str;
            messageLabel.Location = new System.Drawing.Point(5, 1);
            messageLabel.BackColor = Color.Transparent;

            //Graphics g = Graphics.FromHwnd(messageLabel.Handle);
            //SizeF size = g.MeasureString(messageLabel.Text, messageLabel.Font);//获取大小
            //g.Dispose();

            //设置bubbleBox
            PictureBox bubbleBox = new PictureBox();
            //一定要先把Label装在Box里面，不然Label的Size不会自动改变！
            bubbleBox.Controls.Add(messageLabel);

            bubbleBox.Image = global::聊天软件_客户端.Properties.Resources.rightBubble;
            bubbleBox.Size = new System.Drawing.Size(messageLabel.Size.Width + 20, messageLabel.Size.Height + 10);
            bubbleBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            bubbleBox.Location = new System.Drawing.Point(570 - bubbleBox.Size.Width, 5);

            //设置messagePanel
            Panel messagePanel = new Panel();
            messagePanel.Controls.Add(bubbleBox);
            messagePanel.Controls.Add(iconBox);
            messagePanel.Location = new System.Drawing.Point(0, currentHeight);
            messagePanel.Size = new System.Drawing.Size(620, bubbleBox.Size.Height + 10);
            messagePanel.MinimumSize = new System.Drawing.Size(620, 40);

            this.messagesContainerPanel.VerticalScroll.Value = 0;
            this.messagesContainerPanel.Controls.Add(messagePanel);
            this.PerformLayout();
            this.messagesContainerPanel.AutoScrollPosition = messagePanel.Location;
            currentHeight += messagePanel.Size.Height+10;

        }
        public void ReceiveMessageShow(string str)
        {
 
        }
    }
}
