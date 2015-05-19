using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 聊天软件_客户端
{
    public class SearchFriendsHandler : IHandlerProtocol
    {
        private PublicUserInfo? info;
        public void HandlerProtocol(Protocol _pro)
        {
            SearchFriendsProtocol pro = (SearchFriendsProtocol)_pro;
            info = UserInfo.GetPublicFriendsInfo(pro.searchName);
            if (info != null)
            {
                LogicController.ShowInfoInSearchPanel((PublicUserInfo)info);
             }
        }
    }
}
