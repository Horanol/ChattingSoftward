using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class GetFriendsInfoHandler : IHandlerProtocol
    {
        private Server myServer;
        public GetFriendsInfoHandler(Server _myServer)
        {
            myServer = _myServer;
        }
        public void HandlerProtocol(Protocol _pro)
        {
            GetFriendsInfoProtocol pro = (GetFriendsInfoProtocol)_pro;
            PublicUserInfo? info = UserInfo.GetPublicUserInfo(pro.friendsName);
            if (info != null)
            {
                //info.iconPath里面要么是自定义头像，要么为空
                //先发头像过去
                if (info.Value.iconPath != "")
                {
                    FileHandler handler = new FileHandler(myServer);
                    if (handler.SendFile(info.Value.iconPath))
                    {
                        //若头像发送成功，则继续发送用户其他信息
                        Server.serverLogTextBox.Text += "用户头像发送成功！" + Environment.NewLine;
                        goto SendOtherMessage;
                    }
                }
                else
                {
                    goto SendOtherMessage;
                }
            SendOtherMessage:
                UserPublicInfoProtocol infoPro = new UserPublicInfoProtocol((PublicUserInfo)info);
                //直接通过server发送消息，不经过ServerController
                if (myServer.SendMessage(infoPro.ToString()))
                {
                    Server.serverLogTextBox.Text += "用户信息发送成功！" + Environment.NewLine;

                    //发送完用户信息后，发送一个GetFriendsInfoProtocol用来提醒客户端已发送
                    GetFriendsInfoProtocol getFriendsInfoPro = new GetFriendsInfoProtocol(info.Value.name);
                    myServer.SendMessage(getFriendsInfoPro.ToString());

                }
            }

        }
    }
}
