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
namespace 聊天软件_客户端
{
    /// <summary>
    /// 此类保存每个用户的详细信息，以及对这些信息的操作
    /// </summary>
    public static class UserInfo
    {
        /// <summary>
        /// 客户端的infoDictionary把当前机子的所有保存的用户信息缓存到内存中
        /// </summary>
        private static Dictionary<string, UserDetailInfo> userInfoDictionary;
        private static Dictionary<string, PublicUserInfo> friendsInfoDictionary;

        private static string infoXmlPath;
        private static XmlDocument doc;
        /// <summary>
        /// 可以有静态构造函数，从中初始化用户信息字典
        /// 在创建第一个类实例或任何静态成员被引用时，.NET将自动调用静态构造函数来初始化类。
        /// </summary>
        static UserInfo()
        {

            userInfoDictionary = new Dictionary<string, UserDetailInfo>();//记得new一个对象再使用！！！
            friendsInfoDictionary = new Dictionary<string, PublicUserInfo>();
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

            XmlElement infoElement = doc.CreateElement("Info");
            XmlElement usersInfoElement = doc.CreateElement("UsersInfo");
            XmlElement friendsInfoElement = doc.CreateElement("FriendsInfo");

            doc.AppendChild(infoElement);
            infoElement.AppendChild(usersInfoElement);
            infoElement.AppendChild(friendsInfoElement);

            doc.Save(infoXmlPath);
        }
        /// <summary>
        /// 从硬盘的xml文件中读取用户信息，写入字典
        /// </summary>
        private static void InitialInfoDictionary()
        {
            //写入用户信息
            XmlNode userInfoNode = doc.SelectSingleNode("/Info/UsersInfo");
            XmlNodeList userInfoList = userInfoNode.SelectNodes("User");
            if (userInfoList != null)
            {
                //遍历xml文件并把用户详细信息写入字典
                foreach (XmlNode userNode in userInfoList)
                {
                    string name = userNode.SelectSingleNode("name").InnerText;
                    string password = userNode.SelectSingleNode("password").InnerText;
                    string saying = userNode.SelectSingleNode("saying").InnerText;
                    string iconPath = userNode.SelectSingleNode("iconPath").InnerText;

                    //获取好友数组
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
                    userInfoDictionary.Add(name, info);
                }
            }

            //写入好友信息
            XmlNode friendsInfoNode = doc.SelectSingleNode("/Info/FriendsInfo");
            XmlNodeList friendsNodeList = friendsInfoNode.SelectNodes("Friend");
            if (friendsNodeList != null)
            {
                //遍历xml文件并把用户详细信息写入字典
                foreach (XmlNode friendsNode in friendsNodeList)
                {
                    string name = friendsNode.SelectSingleNode("name").InnerText;
                    string saying = friendsNode.SelectSingleNode("saying").InnerText;
                    string iconPath = friendsNode.SelectSingleNode("iconPath").InnerText;
                    //写入字典
                    PublicUserInfo info = new PublicUserInfo(name, iconPath, saying);
                    friendsInfoDictionary.Add(name, info);
                }
            }
        }
        /// <summary>
        /// 把用户信息以xml格式文件保存到硬盘上
        /// </summary>
        /// <param name="info"></param>
        public static void SaveNewUserInfo(UserDetailInfo info)
        {
            XmlNode usersInfo = doc.SelectSingleNode("/Info/UsersInfo");
            XmlNode newUser = doc.CreateElement("User");

            XmlElement newUserName = doc.CreateElement("name");
            newUserName.InnerText = info.userName;

            XmlElement newUserPassword = doc.CreateElement("password");
            newUserPassword.InnerText = info.password;

            XmlElement newUserSaying = doc.CreateElement("saying");
            newUserSaying.InnerText = info.sayings;

            XmlElement newUserIconPath = doc.CreateElement("iconPath");
            newUserIconPath.InnerText = info.iconPath;

            XmlElement newFriendsNode = doc.CreateElement("Friends");
            newFriendsNode.InnerText = "";

            newUser.AppendChild(newUserName);
            newUser.AppendChild(newUserPassword);
            newUser.AppendChild(newUserSaying);
            newUser.AppendChild(newUserIconPath);
            newUser.AppendChild(newFriendsNode);

            usersInfo.AppendChild(newUser);

            doc.Save(infoXmlPath);
            userInfoDictionary[info.userName] = info;
        }
        /// <summary>
        /// 保存好友信息，这是覆盖性的保存
        /// </summary>
        /// <param name="info"></param>
        public static void SaveNewFriendsInfo(PublicUserInfo info)
        {
            XmlNode friendsInfoNode = doc.SelectSingleNode("/Info/FriendsInfo");

            //检测是否已经存在，若存在则跳过
            int flag = 0;
            XmlNodeList friendsList = friendsInfoNode.SelectNodes("Friend");
            foreach (XmlNode singleFriend in friendsList)
            {
                if (singleFriend.SelectSingleNode("name").InnerText == info.name)
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                XmlNode newFriendsInfo = doc.CreateElement("Friend");

                XmlNode newFriendsName = doc.CreateElement("name");
                newFriendsName.InnerText = info.name;

                XmlNode newFriendsSaying = doc.CreateElement("saying");
                newFriendsSaying.InnerText = info.saying;

                XmlNode newFriendsIconPath = doc.CreateElement("iconPath");
                newFriendsIconPath.InnerText = info.iconPath;

                newFriendsInfo.AppendChild(newFriendsName);
                newFriendsInfo.AppendChild(newFriendsSaying);
                newFriendsInfo.AppendChild(newFriendsIconPath);

                friendsInfoNode.AppendChild(newFriendsInfo);
                doc.Save(infoXmlPath);
                //若字典里没有该好友信息，则新增，否则更新信息
                friendsInfoDictionary[info.name] = info;
            }
        }
        /// <summary>
        /// 返回值加？表示可以为空，用的时候也要加？如UserDetailInfo? a = GetUserDetailInfo(name);
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static UserDetailInfo? GetUserDetailInfo(string name)
        {
            if (userInfoDictionary.ContainsKey(name))
            {
                return userInfoDictionary[name];
            }
            else
                return null;
        }
        public static PublicUserInfo? GetPublicUserInfo(string name)
        {
            if (userInfoDictionary.ContainsKey(name))
            {
                PublicUserInfo info;
                info = new PublicUserInfo(userInfoDictionary[name].userName, userInfoDictionary[name].iconPath, userInfoDictionary[name].sayings);
                return info;
            }
            else
                return null;
        }
        public static PrivateUserInfo? GetPrivateUserInfo(string name)
        {
            if (userInfoDictionary.ContainsKey(name))
            {
                PrivateUserInfo info;
                info = new PrivateUserInfo(userInfoDictionary[name].userName, userInfoDictionary[name].password, userInfoDictionary[name].friendsName);
                return info;
            }
            else
                return null;
        }
        public static PublicUserInfo? GetPublicFriendsInfo(string name)
        {
            if (friendsInfoDictionary.ContainsKey(name))
            {
                PublicUserInfo info;
                info = new PublicUserInfo(friendsInfoDictionary[name].name, friendsInfoDictionary[name].iconPath, friendsInfoDictionary[name].saying);
                return info;
            }
            else
                return null;

        }
        /// <summary>
        /// 往硬盘的xml文件中userInfo中加入一条好友信息
        /// 确保不会有重复好友信息
        /// </summary>
        /// <param name="myName"></param>
        /// <param name="friendsName"></param>
        public static void AddFriend(string myName, string friendsName)
        {
            doc.Load(infoXmlPath);
            XmlNode userInfoNode = doc.SelectSingleNode("/Info/UsersInfo");
            //找到当前用户信息
            XmlNodeList userNodeList = userInfoNode.SelectNodes("User");
            if (userNodeList != null)
            {
                //遍历xml文件,找到指定的用户
                foreach (XmlNode userNode in userNodeList)
                {
                    string name = userNode.SelectSingleNode("name").InnerText;
                    if (name == myName)
                    {
                        XmlNode friendsNode = userNode.SelectSingleNode("Friends");

                        //检测是否已经有该好友信息，没有的话就添加
                        XmlNodeList friendsList = friendsNode.SelectNodes("friend");
                        int flag = 0;
                        foreach (XmlNode singleFriend in friendsList)
                        {
                            if (singleFriend.InnerText  == friendsName)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            //构造新的好友条目
                            XmlElement newFriend = doc.CreateElement("friend");
                            newFriend.InnerText = friendsName;
                            friendsNode.AppendChild(newFriend);

                            doc.Save(infoXmlPath);
                            UpdateUserInfoDictionary(myName);
                        }
                        break;
                    }
                }
            }


        }
        public static void DeleteFriend(string myName, string friendsName)
        {

            XmlNode userInfoNode = doc.SelectSingleNode("/Info/UsersInfo");
            //找到当前用户信息
            XmlNodeList userNodeList = userInfoNode.SelectNodes("User");
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
            //重新从硬盘载入xml文档到DOM中，因为xmlDocument会缓存到内存
            doc.Load(infoXmlPath);
            XmlNode userInfoNode = doc.SelectSingleNode("/Info/UsersInfo");
            //找到当前用户信息
            XmlNodeList userNodeList = userInfoNode.SelectNodes("User");
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

                        //获取好友数组
                        XmlNode friendsNode = userNode.SelectSingleNode("Friends");
                        XmlNodeList friendsList = friendsNode.SelectNodes("friend");
                        string[] friendsNames = new string[friendsList.Count];

                        int i = 0;
                        foreach (XmlNode friend in friendsList)
                        {
                            friendsNames[i] = friend.InnerText;
                            i++;
                        }
                        //修改字典中该用户的信息，没有friends的话friendsNames为null
                        UserDetailInfo info = new UserDetailInfo(name, password, saying, iconPath, friendsNames);
                        userInfoDictionary[userName] = info;
                        break;
                    }
                }
            }
        }
        private static void UpdateFriendsInfoDictionary(string friendsName)
        {
            //重新从硬盘载入xml文档到DOM中，因为xmlDocument会缓存到内存
            doc.Load(infoXmlPath);
            XmlNode friendsNode = doc.SelectSingleNode("/Info/FriendsInfo");
            XmlNodeList friendsList = friendsNode.SelectNodes("Friend");
            foreach (XmlNode friend in friendsList)
            {
                string name = friend.SelectSingleNode("name").InnerText;
                if (name == friendsName)
                {
                    string newSaying = friend.SelectSingleNode("saying").InnerText;
                    string newIconPath = friend.SelectSingleNode("iconPath").InnerText;
                    PublicUserInfo newUserInfo = new PublicUserInfo(name, newIconPath, newSaying);
                    friendsInfoDictionary[name] = newUserInfo;
                    break;
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
        public UserDetailInfo(string _name, string _password, string _sayings, string _iconPath, string[] _friendsName)
        {
            userName = _name;
            password = _password;
            sayings = _sayings;
            iconPath = _iconPath;
            friendsName = _friendsName;
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
