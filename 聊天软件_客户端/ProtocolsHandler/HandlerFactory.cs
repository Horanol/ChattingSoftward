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
            //收到好友信息请求回应时,可以在主面板上刷新好友列表信息
            else if (pro.GetType() == typeof(GetFriendsInfoProtocol))
            {
                return new GetFriendsInfoHandler();
            }
            //收到查找好友请求回应时，在查找好友面板上显示好友信息
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
            else if (pro.GetType() == typeof(SpecialEffectProtocol))
            {
                return new SpecialEffectHandler();
            }
            else if (pro.GetType() == typeof(SendFileRequestProtocol))
            {
                return new SendFileRequestHandler();
            }
            else if (pro.GetType() == typeof(SendFileRespondProtocol))
            {
                return new SendFileRespondHandler(myClient);
            }
            else
                return null;
        }
    }
}
