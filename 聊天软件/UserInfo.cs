using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace 聊天软件
{
    /// <summary>
    /// 此类保存每个用户的详细信息，以及对这些信息的操作
    /// </summary>
    public static class UserInfo
    {
        private static Dictionary<string, UserDetailInfo> infoDictionary;
        /// <summary>
        /// 构造函数中初始化用户信息字典
        /// </summary>
        private UserInfo()
        { 
            //从文件中读取全部注册的用户信息，构造用户信息字典
        }
        public static void SignUp(UserDetailInfo info)
        {
            //保存用户详细信息到硬盘
            SaveUserInfo(info);
            //在当前用户信息字典登记该用户信息
            infoDictionary.Add(info.userName,info);

        }
        public static void SignIn(string name, string password)
        {
            if (infoDictionary.ContainsKey(name))
            {
                //如果用户名存在且密码正确
                if (password == infoDictionary[name].password)
                {
                    //登陆成功
                }
                else
                {
                    //否则输出密码不正确
                }
            }
            else
            {
                //否则输出用户名不存在
            }
        }
        public static void SaveUserInfo(UserDetailInfo info)
        {
           //把用户信息以xml格式文件保存到硬盘上
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
        public UserDetailInfo(string _name, string _password, string _sayings)
        {
            userName = _name;
            password = _password;
            sayings = _sayings;
        }
      
    }
}
