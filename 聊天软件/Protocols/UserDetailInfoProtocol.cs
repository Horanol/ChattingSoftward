using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    /// <summary>
    ///  该协议用于用户注册时登记用户详细信息，不含好友信息
    /// </summary>
    public class UserDetailInfoProtocol : Protocol
    {
        public string userName;
        public string password;
        public string sayings;
        public string iconPath;
        public UserDetailInfoProtocol(UserDetailInfo info)
        {
            userName = info.userName;
            password = info.password;
            sayings = info.sayings;
            iconPath = info.iconPath;
        }
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" userName=\"{1}\" password=\"{2}\" saying=\"{3}\" iconPath=\"{4}\" /></protocol>",
                         "UserDetailInfo", userName, password, sayings, iconPath);
        }
    }
}
