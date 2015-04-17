using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 聊天软件
{
    public static class ServersController
    {
        //以用户名为索引，每个用户对应 的server类为键值
        private static Dictionary<string, Server> servers;

        static ServersController()
        {
            servers = new Dictionary<string, Server>();
        }
        /// <summary>
        /// 负责把消息从用户一方转发给另一方
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="message"></param>
        /// <param name="destinationName"></param>
        public static void SendMessage(string sourceName, string destinationName, string message)
        {
            //若字典里有对应的server类
            if (servers.ContainsKey(destinationName))
            {
                //构造源消息协议头，让对应的server转发
                MessageProtocol pro = new MessageProtocol(sourceName, destinationName, message);
                servers[destinationName].SendMessage(pro.ToString());
            }
        }
        public static void SignOut(string name)
        {
            //退出登录，删除字典的有关内容
            if (servers.ContainsKey(name))
            {
                servers.Remove(name);
            }


        }
        public static void SignIn(string name, Server server)
        {
            //若还没注册键名，则注册键名
            if (!servers.ContainsKey(name))
            {
                servers.Add(name, server);
            }
        }
    }
}
