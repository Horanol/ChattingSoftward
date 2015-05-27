using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class GetFriendsInfoHandler:IHandlerProtocol
    {
        public void HandlerProtocol(Protocol _pro)
        {
            GetFriendsInfoProtocol pro = (GetFriendsInfoProtocol)_pro;
            //更新主面板
            ClientMainForm.OnUpdateFriendsList();
        }
    }
}
