using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace 聊天软件_客户端
{
    public static class UserInfo
    {
        private static XmlNodeList nodeList;
        static UserInfo()
        {
            string infoXmlPath = @"E:\CPlusProject\LearnTCPProgramming\聊天软件_客户端\UserInfo.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(infoXmlPath);
            nodeList = doc.SelectNodes("/users/user");

        }
        public static UserDetailInfo? GetUserDetailInfo(string userName)
        {
            string name;
            UserDetailInfo info;
            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    name = node.SelectSingleNode("name").InnerText;
                    if (name == userName)
                    {
                        string password = node.SelectSingleNode("password").InnerText;
                        string saying = node.SelectSingleNode("saying").InnerText;
                        string iconPath = node.SelectSingleNode("iconPath").InnerText;
                        info = new UserDetailInfo(name, password, saying,iconPath);
                        return info;
                    }
                }
            }
            return null;
        }
    }
    public struct UserDetailInfo
    {
        public string userName;
        public string password;
        public string sayings;
        public string iconPath;
        public UserDetailInfo(string _name, string _password, string _sayings ,string _iconPath)
        {
            userName = _name;
            password = _password;
            sayings = _sayings;
            iconPath = _iconPath;
        }
    }
}
