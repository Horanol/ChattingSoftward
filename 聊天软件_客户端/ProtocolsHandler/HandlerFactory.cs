using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class HandlerFactory
    {
        private Client myClient;
        public HandlerFactory(Client _myClient)
        {
            myClient = _myClient;
        }
        public IHandlerProtocol CreateHandler(Protocol pro)
        {
            if (pro.GetType() == typeof(MessageProtocol))
            {
                return new MessageHandler();
            }
            else if (pro.GetType() == typeof(FileProtocol))
            {
                return new FileHandler(myClient);
            }
            //接受到服务器发来的查找好友结果
            else if (pro.GetType() == typeof(SearchFriendsProtocol))
            {
                return new SearchFriendsHandler();
            }
            //接收到单个用户的公开信息，缓存到本地
            else if (pro.GetType() == typeof(UserPublicInfoProtocol))
            {
                return new SaveFriendsInfoHandler();
            }
            else if (pro.GetType() == typeof(AddFriendsRequestProtocol))
            {
                return new AddFriendsRequestHandler(myClient);
            }
            else if (pro.GetType() == typeof(AddFriendsRespondProtocol))
            {
                return new AddFriendsRespondHandler();
            }
            else
                return null;
        }
    }
}
