﻿using System;
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
        private string clientName;
        private Client myClient;
        public ClientMainForm()
        {
            InitializeComponent();
        }
        public ClientMainForm(string name,Client client)
        {
            myClient = client;
            clientName = name;
            InitializeComponent();
        }
        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            UserDetailInfo? info = UserInfo.GetUserDetailInfo(clientName);
            if (info != null)//或写成info.hasValue
            {
                this.nameLabel.Text = info.Value.userName;//注意要通过Value获取值
                this.sayingLabel.Text = info.Value.sayings;
                this.iconBox.ImageLocation = info.Value.iconPath;
            }
        }




    }
}
