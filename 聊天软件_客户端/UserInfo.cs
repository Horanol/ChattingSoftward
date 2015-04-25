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
        private static XmlDocument doc;
        private static string infoXmlPath;
        static UserInfo()
        {
            //debug文件夹下的bin 文件夹，这种方法表示的路径名后面有"\"符号
            
            infoXmlPath = AppDomain.CurrentDomain.BaseDirectory+"UserInfo.xml";
            if (!File.Exists(infoXmlPath))
            {
                CreateEmptyXmlDocument();
            }
            doc = new XmlDocument();
          
            doc.Load(infoXmlPath);
        }
        private static void CreateEmptyXmlDocument()
        {
            doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "", "yes");
            doc.PrependChild(dec);//把声明节点放到开头
            XmlElement usersElement = doc.CreateElement("users");
            doc.AppendChild(usersElement);
            doc.Save(infoXmlPath);
        }
        /// <summary>
        /// 返回字符串形式的用户名，密码，说说，以及对应的头像在本地的地址
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>UserDetailInfo 或 null</returns>
        public static UserDetailInfo? GetUserDetailInfo(string userName)
        {
            string name;
            UserDetailInfo info;
            nodeList = doc.SelectNodes("/users/user");
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
        public static void SaveUserInfo(UserDetailInfo info)
        {
            XmlNode usersNode = doc.SelectSingleNode("users");
            XmlNode newUser = doc.CreateElement("user");

            XmlElement newUserName = doc.CreateElement("name");
            newUserName.InnerText = info.userName;

            XmlElement newUserPassword = doc.CreateElement("password");
            newUserPassword.InnerText = info.password;

            XmlElement newUserSaying = doc.CreateElement("saying");
            newUserSaying.InnerText = info.sayings;

            XmlElement newUserIconPath = doc.CreateElement("iconPath");
            newUserIconPath.InnerText = info.iconPath;

            newUser.AppendChild(newUserName);
            newUser.AppendChild(newUserPassword);
            newUser.AppendChild(newUserSaying);
            newUser.AppendChild(newUserIconPath);
            usersNode.AppendChild(newUser);

            doc.Save(infoXmlPath);
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
