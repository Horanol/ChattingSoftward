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
        private static Dictionary<string, List<MessageProtocol>> offlineMsgBufferDictionary;

        static ServersController()
        {
            servers = new Dictionary<string, Server>();
            offlineMsgBufferDictionary = new Dictionary<string, List<MessageProtocol>>();
        }
        /// <summary>
        /// 负责把消息从用户一方转发给另一方
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="message"></param>
        /// <param name="destinationName"></param>
        public static bool SendMessage(MessageProtocol pro)
        {
            //若字典里有对应的server类
            if (servers.ContainsKey(pro.destinationName))
            {
                //构造源消息协议头，让对应的server转发
                if (servers[pro.destinationName].SendMessage(pro.ToString()))
                {
                    return true;
                }
            }
            else
            {
                if (offlineMsgBufferDictionary.ContainsKey(pro.destinationName))
                {
                    offlineMsgBufferDictionary[pro.destinationName].Add(pro);
                }
                else
                {
                    List<MessageProtocol> proList = new List<MessageProtocol>();
                    proList.Add(pro);
                    offlineMsgBufferDictionary.Add(pro.destinationName, proList);
                }
            }
            return false;
        }
        /// <summary>
        /// 负责把离线消息发给新连接的server
        /// </summary>
        /// <param name="targetServer"></param>
        public static void SendOfflineMsg(Server targetServer)
        {
            if (offlineMsgBufferDictionary.ContainsKey(targetServer.clientName))
            {
                foreach (MessageProtocol msgPro in offlineMsgBufferDictionary[targetServer.clientName])
                {
                    targetServer.SendMessage(msgPro.ToString());
                }
                //记得清空缓存!!
                offlineMsgBufferDictionary.Remove(targetServer.clientName);
            }
        }

        public static bool SendFileRequest(SendFileRequestProtocol pro)
        {
            if (servers.ContainsKey(pro.destinationName))
            {
                if (servers[pro.destinationName].SendMessage(pro.ToString()))
                    return true;
            }
            return false;
        }
        public static bool SendFileRespond(SendFileRespondProtocol pro)
        {
            if (servers.ContainsKey(pro.sourceName))
            {
                if (servers[pro.sourceName].SendMessage(pro.ToString()))
                    return true;
            }
            return false;
        }
        public static bool SendFileTransformInfo(FileProtocol pro)
        {
            if (servers.ContainsKey(pro.destinationName))
            {
                if (servers[pro.destinationName].SendMessage(pro.ToString()))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 转发好友请求
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static bool SendAddFriendsRequest(AddFriendsRequestProtocol pro)
        {
            if (servers.ContainsKey(pro.respondent))
            {
                if (servers[pro.respondent].SendMessage(pro.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 转发好友请求响应
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public static bool SendAddFriendsRespond(AddFriendsRespondProtocol pro)
        {
            if (servers.ContainsKey(pro.sponsor))
            {
                if (servers[pro.sponsor].SendMessage(pro.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        public static void SendSpecialEffect(SpecialEffectProtocol pro)
        {
            //若字典里有对应的server类
            if (servers.ContainsKey(pro.destinationName))
            {
                //构造源消息协议头，让对应的server转发
                servers[pro.destinationName].SendMessage(pro.ToString());
            }
        }
        /// <summary>
        ///退出登录，删除字典的有关内容
        /// </summary>
        /// <param name="name"></param>
        public static void SignOut(string name)
        {
            
            if (servers != null)
            {
                if (servers.ContainsKey(name))
                {
                    servers.Remove(name);
                }
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
        public static bool CheckClientIsExist(string name)
        {
            if (servers.ContainsKey(name))
            {
                return true;
            }
            else
                return false;
        }
    }
}
