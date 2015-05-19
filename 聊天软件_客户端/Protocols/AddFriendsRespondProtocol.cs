﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    /// <summary>
    /// 该协议用于用户对好友请求的回应
    /// </summary>
    public class AddFriendsRespondProtocol : Protocol
    {
        public string sponsor;
        public string respondent;
        public string respond;
        public AddFriendsRespondProtocol(string _sponsor, string _respondent, string _respond)
        {
            sponsor = _sponsor;
            respondent = _respondent;
            respond = _respond;
        }
        public override string ToString()
        {
            return string.Format("<protocol><message type=\"{0}\" sponsor=\"{1}\" respondent=\"{2}\" respond=\"{3}\" /></protocol>", "AddFriendsRespond",
                sponsor, respondent, respond);
        }
    }
}
