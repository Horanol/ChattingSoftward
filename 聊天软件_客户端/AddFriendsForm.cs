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
        private Panel[] singleFriendPanels;
        private PictureBox[] friendsIconBoxs;
        private Label[] friendsNameLabels;
        private Label[] friendsSayingLabels;

        public AddFriendsForm()
        {
            InitializeComponent();
        }
        private void AddFriendsForm_Load(object sender, EventArgs e)
        {
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string[] test = new string[] { "hello","我擦","这不是真的","再来","haha我擦","什么鬼" };
            GenerateSingleFriendPanel(test);
        }
        private void GenerateSingleFriendPanel(string[] friendsNames)
        {
            int length = friendsNames.Length;
            //暂停布局绘画功能，等控件属性设置好后再一次性绘画
            //this.selectFriendsPanel.SuspendLayout();
            this.SuspendLayout();
            //清理之前的控件
            if (singleFriendPanels != null)
            {
                foreach (var item in singleFriendPanels)
                {
                    item.Dispose();
                }
            }
            //新建控件布局数组，头像数组，昵称标签数组，说说标签数组
            //这里新建的只是引用数组，并没有在堆上新建对象，所以要在下面的循环中新建对象
            singleFriendPanels = new Panel[length];
            friendsIconBoxs = new PictureBox[length];
            friendsNameLabels = new Label[length];
            friendsSayingLabels = new Label[length];

            //初始化头像数组
            //不能用foreach迭代器循环遍历，这样是不能new一个对象的
            for (int i = 0; i < length; i++)
            {
                //要给头像数组的每一个引用的new一个对象才行
                friendsIconBoxs[i] = new PictureBox();
                //开始初始化pictureBox，需要加上这句
                ((System.ComponentModel.ISupportInitialize)(friendsIconBoxs[i])).BeginInit();
                friendsIconBoxs[i].Location = new System.Drawing.Point(0, 0);
                friendsIconBoxs[i].Name = "friendsIconBox" + (i + 1).ToString();
                friendsIconBoxs[i].Size = new System.Drawing.Size(120, 100);
                friendsIconBoxs[i].TabIndex = 0;
                friendsIconBoxs[i].TabStop = false;
                friendsIconBoxs[i].ImageLocation = @"C:\Users\q\Pictures\icon2.jpg";
                friendsIconBoxs[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ((System.ComponentModel.ISupportInitialize)(friendsIconBoxs[i])).EndInit();
            }

            //初始化昵称标签数组
            for (int i = 0; i < length; i++)
            {
                friendsNameLabels[i] = new Label();
                friendsNameLabels[i].Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                friendsNameLabels[i].Location = new System.Drawing.Point(120, 0);
                friendsNameLabels[i].Name = "friendsNameLabel" + (i + 1).ToString();
                friendsNameLabels[i].Size = new System.Drawing.Size(120, 25);
                friendsNameLabels[i].TabIndex = 1;
                friendsNameLabels[i].Text = friendsNames[i];
            }

            //初始化说说标签数组
            for (int i = 0; i < length; i++)
            {
                friendsSayingLabels[i] = new Label();
                friendsSayingLabels[i].Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                friendsSayingLabels[i].Location = new System.Drawing.Point(120, 25);
                friendsSayingLabels[i].Name = "friendsSayingLabel" + (i + 1).ToString();
                friendsSayingLabels[i].Size = new System.Drawing.Size(120, 75);
                friendsSayingLabels[i].TabIndex = 2;
                friendsSayingLabels[i].Text = "胜多负少发生发送到发送到是";
            }

            for (int i = 0; i < length; i++)
            {
                singleFriendPanels[i] = new Panel();
                //暂停小布局绘画功能，等控件属性设置好后再一次性绘画
                singleFriendPanels[i].SuspendLayout();
                //往每个小布局里分别挂上头像，昵称，说说控件
                singleFriendPanels[i].Controls.Add(friendsIconBoxs[i]);
                singleFriendPanels[i].Controls.Add(friendsNameLabels[i]);
                singleFriendPanels[i].Controls.Add(friendsSayingLabels[i]);
                //初始化每个小布局
                //小布局x的坐标要不是0，要不是280，取决于i的值
                int xPosition = (i % 2 == 0) ? 0 : 280;
                //小布局y的坐标总是120的倍数，取决于i的值
                int yPosition = (i % 2 == 0) ? i * 60 : (i - 1) * 60;
                //设置小布局的坐标
                singleFriendPanels[i].Location = new System.Drawing.Point(xPosition, yPosition);
                singleFriendPanels[i].Name = "singleFriendPanel" + (i + 1).ToString();
                singleFriendPanels[i].Size = new System.Drawing.Size(250, 120);
                singleFriendPanels[i].TabIndex = 3;

                //把初始化好的小布局挂在大布局上
                this.selectFriendsPanel.Controls.Add(singleFriendPanels[i]);
                //恢复小布局的绘画功能
                singleFriendPanels[i].ResumeLayout(false);
            }
            //注意！！！panel布局不能挂起，否则不出现滚动条
            //this.selectFriendsPanel.ResumeLayout(false);

            //取消挂起的布局
            this.ResumeLayout(false);
            //立刻刷新布局
            this.PerformLayout();
        }




    }
}
