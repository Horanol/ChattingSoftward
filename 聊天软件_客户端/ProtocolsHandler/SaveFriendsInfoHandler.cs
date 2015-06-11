using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 聊天软件_客户端
{
    public class SaveFriendsInfoHandler : IHandlerProtocol
    {
        private PublicUserInfo info;

        /// <summary>
        ///若有头像，从头像目录里找到含有该用户名的头像,否则用默认头像
        ///构造一个PublicUserInfo，保存在UserInfo的FriendsInfo里面
        /// </summary>
        /// <param name="_pro"></param>
        public void HandlerProtocol(Protocol _pro)
        {
            UserPublicInfoProtocol pro = (UserPublicInfoProtocol)_pro;

            string iconRootPath = Directory.GetCurrentDirectory() + "\\IconBuffer\\";
            if (Directory.Exists(iconRootPath))
            {
                string searchFilePattern = "Icon_" + pro.userName + ".*";

                string[] filesName = Directory.GetFiles(iconRootPath, searchFilePattern, SearchOption.TopDirectoryOnly);
                if (filesName.Length != 0)
                {
                    info = new PublicUserInfo(pro.userName, filesName[0], pro.saying);
                }
                else
                    info = new PublicUserInfo(pro.userName, "", pro.saying);
            }
            UserInfo.SaveNewFriendsInfo(info);
        }
    }
}
