using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class SignInProtocol : Protocol
    {
        public string userName { get; set; }
        public string password { get; set; }
        public SignInProtocol(string _userName, string _password)
        {
            userName = _userName;
            password = _password;
        }
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" userName=\"{1}\" password=\"{2}\" /></protocol>",
                "SignIn", userName, password);
        }
    }
}
