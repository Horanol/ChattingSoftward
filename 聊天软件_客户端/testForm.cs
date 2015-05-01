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
    public partial class testForm : Form
    {
        public int h = 0;
        public testForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label testLabel = new Label();
            testLabel.AutoSize = true;
            testLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            testLabel.Text = testBox.Text;
            testLabel.Location = new Point(5, 1);
            testLabel.BackColor = Color.Green;
            PictureBox p = new PictureBox();
            p.Location = new Point(100, 100);
            p.Controls.Add(testLabel);
            p.Image = global::聊天软件_客户端.Properties.Resources.rightBubble;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Size = new Size(testLabel.Size.Width + 20, testLabel.Size.Height + 10);
            this.Controls.Add(p);
            this.PerformLayout();
        }

        private void testForm_Load(object sender, EventArgs e)
        {

        }

    }
}
