using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace 聊天软件_客户端
{
    public class AddFriendsRequestHandler:IHandlerProtocol
    {
        private Client myClient;
        public AddFriendsRequestHandler(Client _client)
        {
            myClient = _client;
        }
        /// <summary>
        /// 当前线程是监听线程，不能在这上面创建窗体，否则该线程会被阻塞，窗体绘制不出来
        /// 解决办法是在主UI线程中创建窗体方法，该线程调用
        /// </summary>
        /// <param name="_pro"></param>
        public void HandlerProtocol(Protocol _pro)
        {
            AddFriendsRequestProtocol pro = (AddFriendsRequestProtocol)_pro;
            ClientMainForm.OnShowRespondRequestForm(myClient,pro);
        }
    }
}
