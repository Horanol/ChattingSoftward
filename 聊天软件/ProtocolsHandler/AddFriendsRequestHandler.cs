using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class AddFriendsRequestHandler:IHandlerProtocol
    {
        private Server myServer;
        public AddFriendsRequestHandler(Server _server)
        {
            myServer = _server;
        }
        public void HandlerProtocol(Protocol _pro)
        {
            AddFriendsRequestProtocol pro = (AddFriendsRequestProtocol)_pro;
            Server.serverLogTextBox.Text += "用户[" + pro.sponsor + "]   向用户[" + pro.respondent + "]    发送好友请求" + Environment.NewLine;
            if (!ServersController.SendAddFriendsRequest(pro))
            {
                Server.serverLogTextBox.Text += "用户[" + pro.respondent + "]    未上线，好友请求失败" + Environment.NewLine;
            }
        }
    }
}
