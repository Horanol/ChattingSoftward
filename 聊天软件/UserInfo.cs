using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
namespace 聊天软件
{
    /// <summary>
    /// 此类保存每个用户的详细信息，以及对这些信息的操作
    /// </summary>
    public static class UserInfo
    {
        private static Dictionary<string, UserDetailInfo> infoDictionary;
        private static List<string> names;

        private static string infoXmlPath;
        private static XmlDocument doc;
        /// <summary>
        /// 可以有静态构造函数，从中初始化用户信息字典
        /// 在创建第一个类实例或任何静态成员被引用时，.NET将自动调用静态构造函数来初始化类。
        /// </summary>
        static UserInfo()
        {
            names = new List<string>();
            //从文件中读取全部注册的用户信息，构造用户信息字典
            infoDictionary = new Dictionary<string, UserDetailInfo>();//记得new一个对象再使用！！！
            infoXmlPath = Directory.GetCurrentDirectory() + "\\UserInfo.xml";
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
            XmlElement usersElement = doc.CreateElement("Users");
            doc.AppendChild(usersElement);
            doc.Save(infoXmlPath);
        }
        /// <summary>
        /// 从硬盘的xml文件中读取用户信息，写入字典
        /// </summary>
        private static void InitialInfoDictionary()
        {
            XmlNode usersNode = doc.SelectSingleNode("/Users");
            XmlNodeList userNodeList = usersNode.SelectNodes("User");
            if (userNodeList != null)
            {
                //遍历xml文件并把用户详细信息写入字典
                foreach (XmlNode userNode in userNodeList)
                {
                    string name = userNode.SelectSingleNode("name").InnerText;
                    string password = userNode.SelectSingleNode("password").InnerText;
                    string saying = userNode.SelectSingleNode("saying").InnerText;
                    string iconPath = userNode.SelectSingleNode("iconPath").InnerText;

                    XmlNode friendsNode = userNode.SelectSingleNode("Friends");
                    XmlNodeList friendsList = friendsNode.SelectNodes("friend");
                    string[] friendsNames = new string[friendsList.Count];
                    //获取好友数组
                    int i = 0;
                    foreach (XmlNode friend in friendsList)
                    {
                        friendsNames[i] = friend.InnerText;
                        i++;
                    }
                    //写入字典
                    UserDetailInfo info = new UserDetailInfo(name, password, saying, iconPath, friendsNames);
                    infoDictionary.Add(name, info);

                    //保存名字到names里，以便以后查找
                    names.Add(name);
                }
            }
        }
        public static void SignUp(UserDetailInfo info)
        {
            //保存用户详细信息到硬盘
            SaveNewUserInfo(info);
            //在字典中把新用户信息收集
            if (!infoDictionary.ContainsKey(info.userName))
                infoDictionary.Add(info.userName, info);
            //在名字索引中加入新用户
            if (!names.Contains(info.userName))
            {
                names.Add(info.userName);
            }
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
        public static void SaveNewUserInfo(UserDetailInfo info)
        {
            XmlNode usersNode = doc.SelectSingleNode("Users");
            XmlNode newUser = doc.CreateElement("User");
            XmlNode newFriendsNode = doc.CreateElement("Friends");

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
            newUser.AppendChild(newFriendsNode);

            usersNode.AppendChild(newUser);

            doc.Save(infoXmlPath);
            infoDictionary[info.userName] = info;
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
        public static PublicUserInfo? GetPublicUserInfo(string name)
        {
            if (infoDictionary.ContainsKey(name))
            {
                PublicUserInfo info;
                info = new PublicUserInfo(infoDictionary[name].userName, infoDictionary[name].iconPath, infoDictionary[name].sayings);
                return info;
            }
            else
                return null;
        }
        public static string[] GetMatchedSearchFriendsName(SearchFriendsProtocol pro)
        {
            List<string> matchedNames = new List<string>();
            foreach (string name in names)
            {
                if (Regex.IsMatch(name, pro.searchName))
                    matchedNames.Add(name);
            }
            return matchedNames.ToArray();
        }
        public static PrivateUserInfo? GetPrivateUserInfo(string name)
        {
            if (infoDictionary.ContainsKey(name))
            {
                PrivateUserInfo info;
                info = new PrivateUserInfo(infoDictionary[name].userName, infoDictionary[name].password, infoDictionary[name].friendsName);
                return info;
            }
            else
                return null;
        }
        /// <summary>
        /// 往硬盘的xml文件中加入一条好友信息
        /// 确保无重复的好友信息
        /// </summary>
        /// <param name="myName"></param>
        /// <param name="friendsName"></param>
        public static void AddFriend(string myName, string friendsName)
        {
            //构造新的好友条目
            XmlElement newFriend = doc.CreateElement("friend");
            newFriend.InnerText = friendsName;

            //找到当前用户信息
            XmlNodeList userNodeList = doc.SelectNodes("/Users/User");
            if (userNodeList != null)
            {
                foreach (XmlNode userNode in userNodeList)
                {
                    string name = userNode.SelectSingleNode("name").InnerText;
                    //找到当前用户名
                    if (name == myName)
                    {
                        //定位到当前用户名的Friends条目
                        XmlNode friendsNode = userNode.SelectSingleNode("Friends");
                        //查找Friends条目下是否已有该好友信息
                        //有的话先移除
                        XmlNodeList friendsList = friendsNode.SelectNodes("friend");
                        foreach (XmlNode singleFriend in friendsList)
                        {
                            if (singleFriend.InnerText == friendsName)
                            {
                                friendsNode.RemoveChild(singleFriend);
                                break;
                            }
                        }
                        //往Friends条目中加入一条新的好友信息
                        friendsNode.AppendChild(newFriend);

                        doc.Save(infoXmlPath);
                        UpdateUserInfoDictionary(myName);
                        break;
                    }
                }
            }


        }
        public static void DeleteFriend(string myName, string friendsName)
        {
            //找到当前用户信息
            XmlNodeList userNodeList = doc.SelectNodes("/Users/User");
            if (userNodeList != null)
            {
                //遍历xml文件,找到指定的用户
                foreach (XmlNode userNode in userNodeList)
                {
                    string name = userNode.SelectSingleNode("name").InnerText;
                    if (name == myName)
                    {
                        XmlNode friendsNode = userNode.SelectSingleNode("Friends");
                        XmlNodeList friendsList = friendsNode.SelectNodes("friend");
                        foreach (XmlNode friend in friendsList)
                        {
                            if (friend.InnerText == friendsName)
                                friendsNode.RemoveChild(friend);
                            break;
                        }
                        doc.Save(infoXmlPath);
                        UpdateUserInfoDictionary(myName);
                        break;
                    }

                }
            }
        }
        /// <summary>
        /// 从硬盘的xml文件中读取指定用户名信息，更新字典内容
        /// </summary>
        /// <param name="userName"></param>
        public static void UpdateUserInfoDictionary(string userName)
        {
            XmlNodeList userNodeList = doc.SelectNodes("/Users/User");
            if (userNodeList != null)
            {
                //遍历xml文件,找到指定的用户
                foreach (XmlNode userNode in userNodeList)
                {
                    string name = userNode.SelectSingleNode("name").InnerText;
                    if (name == userName)
                    {
                        string password = userNode.SelectSingleNode("password").InnerText;
                        string saying = userNode.SelectSingleNode("saying").InnerText;
                        string iconPath = userNode.SelectSingleNode("iconPath").InnerText;

                        XmlNode friendsNode = userNode.SelectSingleNode("Friends");
                        XmlNodeList friendsList = friendsNode.SelectNodes("friend");
                        string[] friendsNames = new string[friendsList.Count];
                        //获取好友数组
                        int i = 0;
                        foreach (XmlNode friend in friendsList)
                        {
                            friendsNames[i] = friend.InnerText;
                            i++;
                        }
                        //修改字典中该用户的信息
                        UserDetailInfo info = new UserDetailInfo(name, password, saying, iconPath, friendsNames);
                        infoDictionary[userName] = info;
                        break;
                    }
                }
            }


        }

    }
    public struct UserDetailInfo
    {
        public string userName;
        public string password;
        public string sayings;
        public string iconPath;
        public string[] friendsName;
        public UserDetailInfo(string _name, string _password, string _sayings, string _iconPath, string[] _friendsNames)
        {
            userName = _name;
            password = _password;
            sayings = _sayings;
            iconPath = _iconPath;
            friendsName = _friendsNames;
        }

    }
    public struct PublicUserInfo
    {
        public string name;
        public string iconPath;
        public string saying;
        public PublicUserInfo(string _name, string _iconPath, string _saying)
        {
            name = _name;
            iconPath = _iconPath;
            saying = _saying;
        }
    }
    public struct PrivateUserInfo
    {
        public string name;
        public string password;
        public string[] friendsName;
        public PrivateUserInfo(string _name, string _password, string[] _friendsName)
        {
            name = _name;
            password = _password;
            friendsName = _friendsName;
        }
    }
}
