using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace 聊天软件_客户端
{
    public partial class FileRequestForm : Form
    {
        private SendFileRequestProtocol pro;

        public FileRequestForm()
        {
            InitializeComponent();
        }
        public FileRequestForm(SendFileRequestProtocol _pro)
        {
            InitializeComponent();
            pro = _pro;
            //弹出接受文件对话框时也弹出消息对话框
            ConversationForm conForm = new ConversationForm(pro.destinationName, pro.sourceName);
            conForm.Show();
        }
        private void FileRequestForm_Load(object sender, EventArgs e)
        {
            this.nameLabel.Text = pro.sourceName;
            this.fileNameLabel.Text = Path.GetFileName(pro.fileName);
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            string saveFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "所有文件(*.*)|*.*";//  |  号前面是注释，后面是过滤的扩展名，用逗号隔开
            sfd.RestoreDirectory = false;//关闭对话框前还原原来路径
            sfd.Title = "请选择要保存的位置";
            sfd.AddExtension = true;
            sfd.DefaultExt = Path.GetExtension(pro.fileName);
            sfd.FileName = Path.GetFileName(pro.fileName);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveFilePath = sfd.FileName;
            }
            //设置接受路径
            FileHandler.saveFilePath = saveFilePath;
            //发送回应消息
            SendFileRespondProtocol respondPro = new SendFileRespondProtocol(pro.sourceName, pro.destinationName, pro.fileName, Names.ProtocolMembers.ACCEPT);
            Client.OnSendMessage(respondPro.ToString());

            this.Close();
        }
    }
}
