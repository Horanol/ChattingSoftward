using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace 聊天软件
{
    public class SaveInfoHandler:IHandlerProtocol
    {
        public void HandlerProtocol(Protocol _pro)
        {
            UserDetailInfoProtocol pro = (UserDetailInfoProtocol)_pro;
            UserDetailInfo info;
            //若没有头像，直接保存
            if (pro.iconPath == "")
                info = new UserDetailInfo(pro.userName, pro.password, pro.sayings, pro.iconPath, null);
            //若有头像,重新设置头像路径名为服务器端的路径名
            else
            {
                string iconPath = Directory.GetCurrentDirectory() + "\\IconBuffer\\" + Path.GetFileName(pro.iconPath);
                info = new UserDetailInfo(pro.userName, pro.password, pro.sayings, iconPath, null);
            }
            UserInfo.SignUp(info);
        }
    }
}
