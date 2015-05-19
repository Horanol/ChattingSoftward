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
    public partial class AddFriendsForm : Form
    {

        private int index = 0;
        private Client client;

        private string searchName;
        private Dictionary<string, PublicUserInfo> infoDictionary;
        public static Action<PublicUserInfo> OnShowInfoInSearchPanel;

        public AddFriendsForm()
        {
            InitializeComponent();
        }
        public AddFriendsForm(Client _client)
        {
            IntPtr handler = this.Handle;
            InitializeComponent();
            client = _client;          
        }
        private void AddFriendsForm_Load(object sender, EventArgs e)
        {
            //绑定方法
            OnShowInfoInSearchPanel += ShowInfo;
            //初始化infoList
            infoDictionary = new Dictionary<string, PublicUserInfo>();
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchName != "")
            {
                BeforeShowInfo();
                SearchFriendsProtocol pro = new SearchFriendsProtocol(searchName, "", "");
                string msg = pro.ToString();
                if (client.TryConnectToServer())
                {
                    if (!client.SendMessage(msg))
                        MessageBox.Show("无法发送！");
                }
                else
                    MessageBox.Show("无法连接服务器！");
            }
            else
                MessageBox.Show("请输入查找条件！");

        }
        private void BeforeShowInfo()
        {
            this.infoDictionary.Clear();
            this.showInfosPanel.Controls.Clear();
            this.PerformLayout();
            index = 0;
        }
        public void ShowInfo(PublicUserInfo info)
        {
            if (!infoDictionary.ContainsKey(info.name))
            {
                infoDictionary.Add(info.name, info);
            }
            try
            {
                if(this.InvokeRequired)
                    this.Invoke(new Action<PublicUserInfo>(GenerateSingleFriendPanel), info);
            }
            catch
            { 
                
            }
          }
        private void GenerateSingleFriendPanel(PublicUserInfo info)
        {
            this.SuspendLayout();
            // 
            // iconBox
            // 
            PictureBox iconBox = new PictureBox();
            iconBox.Location = new System.Drawing.Point(0, 0);
            iconBox.Name = info.name + "_iconBox";
            iconBox.Size = new System.Drawing.Size(120, 120);
            if(info.iconPath != "")
                iconBox.ImageLocation = info.iconPath;
            else
                iconBox.Image = global::聊天软件_客户端.Properties.Resources.cantFindPicture;
            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconBox.TabIndex = 0;
            iconBox.TabStop = false;
            iconBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iconBox_MouseDoubleClick);
            // 
            // nameLabel
            // 
            Label nameLabel = new Label();
            nameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            nameLabel.Location = new System.Drawing.Point(122, 3);
            nameLabel.Name = "label"+index.ToString();
            nameLabel.Size = new System.Drawing.Size(175, 25);
            nameLabel.TabIndex = 1;
            nameLabel.Text = info.name;
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sayingLabel
            // 
            Label sayingLabel = new Label();
            sayingLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            sayingLabel.Location = new System.Drawing.Point(126, 28);
            sayingLabel.Name = "label"+index.ToString();
            sayingLabel.Size = new System.Drawing.Size(170, 90);
            sayingLabel.TabIndex = 2;
            sayingLabel.Text = info.saying;
            // 
            // infoPanel
            // 
            Panel infoPanel = new Panel();
            infoPanel.Controls.Add(iconBox);
            infoPanel.Controls.Add(nameLabel);
            infoPanel.Controls.Add(sayingLabel);
            infoPanel.Location = new System.Drawing.Point(index%2==0?0:310,125*(index/2));
            infoPanel.Name = "panel"+index.ToString();
            infoPanel.Size = new System.Drawing.Size(300, 120);
            infoPanel.TabIndex = 1;

            this.ResumeLayout();
            this.showInfosPanel.Controls.Add(infoPanel);
            this.PerformLayout();
            index++;
        }

        private void inputNameBox_TextChanged(object sender, EventArgs e)
        {
            searchName = inputNameBox.Text;
        }

        private void iconBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox iconBox = (PictureBox)sender;
            string searchName = iconBox.Name.Split('_')[0];
            PublicUserInfo searchInfo;
            if (infoDictionary.TryGetValue(searchName, out searchInfo))
            {
                ShowDetailInfoForm infoForm = new ShowDetailInfoForm(searchInfo,client);
                infoForm.Show();
            }

        }


    }
}
