using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public static class ServersController
    {
        //以用户名为索引，每个用户对应 的server类为键值
        public static Dictionary<string, Server> servers;

        /// <summary>
        /// 负责把消息从用户一方转发给另一方
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="message"></param>
        /// <param name="destinationName"></param>
        public static void SendMessage(string sourceName,string message,string destinationName)
        {
            //若字典里有对应的server类
            if (servers.ContainsKey(destinationName))
            {
                //调用其上的SendMessage方法，把发送方名字和发送内容传入
                servers[destinationName].SendMessage(message, sourceName);
            }
        }
    }
}
