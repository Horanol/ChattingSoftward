using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Windows.Forms;
using System.IO;
namespace 聊天软件
{
    /// <summary>
    /// 此类保存每个用户的详细信息，以及对这些信息的操作
    /// </summary>
    public static class UserInfo
    {
        private static Dictionary<string, UserDetailInfo> infoDictionary;
        private static string infoXmlPath;
        private static XmlDocument doc;
        /// <summary>
        /// 可以有静态构造函数，从中初始化用户信息字典
        /// 在创建第一个类实例或任何静态成员被引用时，.NET将自动调用静态构造函数来初始化类。
        /// </summary>
        static UserInfo()
        {
            //从文件中读取全部注册的用户信息，构造用户信息字典
            infoDictionary = new Dictionary<string, UserDetailInfo>();//记得new一个对象再使用！！！
            infoXmlPath = AppDomain.CurrentDomain.BaseDirectory + "UserInfo.xml";
            //判断文件是否存在，而不是判断目录是否存在
            if (!File.Exists(infoXmlPath))
            {
                CreateEmptyXmlDocument(); 
            }
            doc = new XmlDocument();
            doc.Load(infoXmlPath);

            InitialInfoDictionary();

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
        private static void InitialInfoDictionary()
        {
            XmlNodeList userNodeList = doc.SelectNodes("/users/user");
            if (userNodeList != null)
            {
                //遍历xml文件并把用户详细信息写入字典
                foreach (XmlNode userNode in userNodeList)
                {
                    string name = userNode.SelectSingleNode("name").InnerText;
                    string password = userNode.SelectSingleNode("password").InnerText;
                    string saying = userNode.SelectSingleNode("saying").InnerText;
                    string iconPath = userNode.SelectSingleNode("iconPath").InnerText;
                    UserDetailInfo info = new UserDetailInfo(name, password, saying, iconPath);
                    infoDictionary.Add(name, info);
                }
            }
        }
        public static void SignUp(UserDetailInfo info)
        {
            //保存用户详细信息到硬盘
            SaveUserInfo(info);
            //在字典中把新用户信息收集
            infoDictionary.Add(info.userName, info);
        }
        public static bool CheckUserNameAvailable(string userName)
        {
            if (infoDictionary.ContainsKey(userName))
                return false;
            else
                return true;
        }
        public static bool SignIn(string name, string password)
        {
            if (infoDictionary.ContainsKey(name))
            {
                //如果用户名存在且密码正确
                if (password == infoDictionary[name].password)
                {
                    //登陆成功
                    return true;
                }
                else
                {
                    //否则输出密码不正确
                    return false;
                }
            }
            else
            {
                //否则输出用户名不存在
                return false;
            }
        }
        public static void SignOut()
        {
 
        }
        /// <summary>
        /// 把用户信息以xml格式文件保存到硬盘上
        /// </summary>
        /// <param name="info"></param>
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
        /// <summary>
        /// 返回值加？表示可以为空，用的时候也要加？如UserDetailInfo? a = GetUserDetailInfo(name);
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static UserDetailInfo? GetUserDetailInfo(string name)
        {
            if (infoDictionary.ContainsKey(name))
            {
                return infoDictionary[name];
            }
            else
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
