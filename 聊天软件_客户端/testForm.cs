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
        public static Action Ontest;
        public testForm()
        {
            InitializeComponent();
        }

        private void testForm_Load(object sender, EventArgs e)
        {
            Ontest += testLabel;
        }
        private void testLabel()
        {
            label1.Visible = true;
        }
    }
}
