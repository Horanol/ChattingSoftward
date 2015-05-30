using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{

    public class SignInOrUpHandler : IHandlerProtocol
    {
        private Server myServer;
        public SignInOrUpHandler(Server _myServer)
        {
            myServer = _myServer;
        }
        public void HandlerProtocol(Protocol _pro)
        {
            SignInProtocol pro = (SignInProtocol)_pro;
            //若用户名和密码正确，则在ServerController中登记这个用户名和对应的server，以便可以接受其他人的消息
            //给客户端返回登录成功信息
            if (pro.password == "")
            {
                //当处理SignUp请求时，判断用户名是否可用
                if (UserInfo.CheckUserNameAvailable(pro.userName))
                {
                    MessageProtocol acceptUserNamePro = new MessageProtocol("server", "", "UserNameAccepted");
                    myServer.SendMessage(acceptUserNamePro.ToString());
                }
                else
                {
                    MessageProtocol refuseUserNamePro = new MessageProtocol("server", "", "UserNameRefused");
                    myServer.SendMessage(refuseUserNamePro.ToString());
                }
            }
            else
            {
                //当处理SignIn请求时，判断用户名和密码是否正确
                if (UserInfo.SignIn(pro.userName, pro.password))
                {
                    //若用户已经登录了，返回登录失败
                    if (ServersController.CheckClientIsExist(pro.userName))
                    {
                        MessageProtocol refusePro = new MessageProtocol("server", "", "AlreadyLogin");
                        myServer.SendMessage(refusePro.ToString());
                    }
                    else
                    {
                        myServer.clientName = pro.userName;
                        ServersController.SignIn(myServer.clientName, myServer);

                        MessageProtocol acceptPro = new MessageProtocol("server", "", "LoginAccepted");
                        myServer.SendMessage(acceptPro.ToString());
                    }
                }
                else//登录失败返回失败信息
                {
                    MessageProtocol refusePro = new MessageProtocol("server", "", "LoginRefused");
                    myServer.SendMessage(refusePro.ToString());
                }
            }
        }
    }
}
