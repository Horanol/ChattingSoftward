using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 聊天软件_客户端
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //把登录窗口作为模式对话框，先于主窗口打开
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                ClientMainForm cf = new ClientMainForm(loginForm.client);
                Application.Run(cf);

                loginForm.Dispose();
            }
         }
    }
}
