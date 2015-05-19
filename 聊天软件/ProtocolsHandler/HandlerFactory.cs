using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class HandlerFactory
    {
        private Server myServer;
        public HandlerFactory(Server _myServer)
        {
            myServer = _myServer;
        }
        public IHandlerProtocol CreateHandler(Protocol pro)
        {
            if (pro.GetType() == typeof(MessageProtocol))
            {
                return new MessageHandler(myServer);
            }
            else if (pro.GetType() == typeof(FileProtocol))
            {
                return new FileHandler(myServer);
            }
            else if (pro.GetType() == typeof(SignInProtocol))
            {
                return new SignInOrUpHandler(myServer);
            }
            else if (pro.GetType() == typeof(UserDetailInfoProtocol))
            {
                return new SaveInfoHandler();
            }
            else if (pro.GetType() == typeof(SearchFriendsProtocol))
            {
                return new SearchFriendsHandler(myServer);
            }
            else if (pro.GetType() == typeof(AddFriendsRequestProtocol))
            {
                return new AddFriendsRequestHandler(myServer);
            }
            else if (pro.GetType() == typeof(AddFriendsRespondProtocol))
            {
                return new AddFriendsRespondHandler(myServer);
            }
            else
                return null;
        }
    }
}
