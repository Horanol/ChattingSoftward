using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 聊天软件_客户端
{
    public class Customized_FriendsItemPanel:CustomizedControl
    {
        public PictureBox friendsIconBox;
        public Label friendsNameLabel;
        public Label friendsSayingLabel;
        public Panel singleFriendsPanel;
        public PublicUserInfo friendsInfo;
        public int index { get; set; }
        public Customized_FriendsItemPanel(int  _index)
        {
             this.index= _index;
             friendsIconBox = new PictureBox();
             friendsNameLabel = new Label();
             friendsSayingLabel = new Label();
             singleFriendsPanel = new Panel();

        }
        public void SetInitialzation(PublicUserInfo _friendsInfo)
        {
            friendsInfo = _friendsInfo;
            InitializeFriendsIconBox(friendsInfo.iconPath);
            InitializeFriendsNameLabel(friendsInfo.name);
            InitializeFriendsSayingLabel(friendsInfo.saying);
            InitializeSingleFriendsPanel();
        }
        private void InitializeFriendsIconBox(string iconPath)
        {
            friendsIconBox.Location = new System.Drawing.Point(0, 10);
            friendsIconBox.Name = "friendsIconBox" + index.ToString();
            friendsIconBox.Size = new System.Drawing.Size(60, 60);
            friendsIconBox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (iconPath == "")
                friendsIconBox.Image = global::聊天软件_客户端.Properties.Resources.cantFindPicture;
            else
                friendsIconBox.ImageLocation = iconPath;

            friendsIconBox.MouseDoubleClick += new MouseEventHandler(this.friendsIconBox_MouseDoubleClick);
        }
        private void InitializeFriendsNameLabel(string friendsName)
        {
            friendsNameLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            friendsNameLabel.Location = new System.Drawing.Point(66, 15);
            friendsNameLabel.Name = "friendsNameLabel" + index.ToString();
            friendsNameLabel.Size = new System.Drawing.Size(210, 23);
            friendsNameLabel.Text = friendsName;
        }
        private void InitializeFriendsSayingLabel(string friendsSaying)
        {
            friendsSayingLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            friendsSayingLabel.Location = new System.Drawing.Point(66, 42);
            friendsSayingLabel.Name = "friendsSayingLabel" + index.ToString();
            friendsSayingLabel.Size = new System.Drawing.Size(210, 25);
            friendsSayingLabel.Text = friendsSaying;
        }
        private void InitializeSingleFriendsPanel()
        {
            singleFriendsPanel.Controls.Add(friendsSayingLabel);
            singleFriendsPanel.Controls.Add(friendsNameLabel);
            singleFriendsPanel.Controls.Add(friendsIconBox);
            singleFriendsPanel.Location = new System.Drawing.Point(0, index * 80);
            singleFriendsPanel.Name = "singleFriendsPanel" + index.ToString();
            singleFriendsPanel.Size = new System.Drawing.Size(280, 80);
        }
        public void friendsIconBox_MouseDoubleClick(object sender, EventArgs args)
        {
            ClientMainForm.OnShowConversationForm(friendsInfo.name);
        }
    }
}
