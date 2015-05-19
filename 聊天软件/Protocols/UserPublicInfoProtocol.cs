using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    /// <summary>
    /// 该协议用于客户端从服务器中获取其他好友信息
    /// </summary>
    public class UserPublicInfoProtocol : Protocol
    {
        public string userName;
        public string saying;
        public UserPublicInfoProtocol(PublicUserInfo info)
        {
            userName = info.name;
            saying = info.saying;
        }
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" userName=\"{1}\" saying=\"{2}\" /></protocol>",
                         "UserPublicInfo", userName, saying);
        }
    }
}
