using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class SearchFriendsHandler:IHandlerProtocol
    {
        public void HandlerProtocol(Protocol _pro)
        {
            SearchFriendsProtocol pro = (SearchFriendsProtocol)_pro;
            PublicUserInfo? info = UserInfo.GetPublicFriendsInfo(pro.searchName);
            if (info != null)
            {
                AddFriendsForm.OnShowFriendsInfo((PublicUserInfo)info);
            }
        }
    }
}
