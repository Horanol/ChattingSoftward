using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace 聊天软件_客户端
{
    public class MessageHandler : IHandlerProtocol
    {

        /// <summary>
        /// 处理转发消息
        /// </summary>
        /// <param name="msgArray"></param>
        public void HandlerProtocol(Protocol _pro)
        {
            MessageProtocol pro = (MessageProtocol)_pro;
            //若是服务器单独给客户端发的消息
            if (pro.sourceName.ToLower() == "server")
            {
                if (pro.content == "LoginAccepted")
                {
                    LogicController.CanLogin();
                }
                else if (pro.content == "LoginRefused")
                {
                    LogicController.CanNotLogin();
                }
                else if (pro.content == "AlreadyLogin")
                {
                    LogicController.AlreadyLogin();
                }
                else if (pro.content == "UserNameAccepted")
                {
                    LogicController.CanUseTheUserName();
                }
                else if (pro.content == "UserNameRefused")
                {
                    LogicController.CanNotUseTheUserName();
                }
            }
            //若是别的好友的消息
            else
            {
                //pro.sourceName表示好友的名字,转发好友的消息
                LogicController.PassMessage(pro.sourceName, pro.content);
            }

        }
    }
}
