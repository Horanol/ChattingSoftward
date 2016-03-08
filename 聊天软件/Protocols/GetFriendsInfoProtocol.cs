using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class GetFriendsInfoProtocol:Protocol
    {
        public string friendsName;
        public GetFriendsInfoProtocol(string _friendsName)
        {
            friendsName = _friendsName;
        }
        public override string ToString()
        {
            return string.Format("<protocol><message type=\"{0}\" friendsName=\"{1}\" /></protocol>", "GetFriendsInfo",
                                    friendsName);
        }
    }
}
