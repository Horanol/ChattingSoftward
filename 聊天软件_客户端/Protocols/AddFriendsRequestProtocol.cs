using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    /// <summary>
    /// 该协议用于用户发送添加好友请求
    /// </summary>
    public class AddFriendsRequestProtocol : Protocol
    {
        public string sponsor;
        public string respondent;
        public AddFriendsRequestProtocol(string _sponsor, string _respondent)
        {
            sponsor = _sponsor;
            respondent = _respondent;
        }
        public override string ToString()
        {
            return string.Format("<protocol><message type=\"{0}\" sponsor=\"{1}\" respondent=\"{2}\" /></protocol>", "AddFriendsRequest", sponsor, respondent);
        }
    }
}
