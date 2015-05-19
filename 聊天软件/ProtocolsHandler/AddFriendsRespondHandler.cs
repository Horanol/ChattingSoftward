using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class AddFriendsRespondHandler : IHandlerProtocol
    {
        /// <summary>
        /// 判断Respond的内容，如果是接受的话，在服务器端UserInfo里建立这两者的好友关系
        /// </summary>
        private Server myServer;
        public AddFriendsRespondHandler(Server _server)
        {
            myServer = _server;
        }
        public void HandlerProtocol(Protocol _pro)
        {
            AddFriendsRespondProtocol pro = (AddFriendsRespondProtocol)_pro;
            bool accepted = (pro.respond == "Accepted" ? true : false);
            Server.serverLogTextBox.Text += "用户[" + pro.respondent + "]   对用户[" + pro.sponsor + "]    的好友请求回应是  " + (accepted ? "接受" : "拒绝") + Environment.NewLine;

            if (accepted)
            {
                //双向的好友关系
                UserInfo.AddFriend(pro.sponsor, pro.respondent);
                UserInfo.AddFriend(pro.respondent, pro.sponsor);
            }
            if (!ServersController.SendAddFriendsRespond(pro))
            {
                Server.serverLogTextBox.Text += "好友请求响应发送失败！" + Environment.NewLine;
            }
        }
    }
}
