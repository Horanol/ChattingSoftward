using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;

namespace 聊天软件_客户端
{
    /// <summary>
    /// 用来分离出单条消息
    /// </summary>
    public class ProtocolSpliter
    {
        private string partialProtocal;
        string pattern = "(^<protocol>.*?</protocol>)";

        public ProtocolSpliter()
        {
            partialProtocal = "";
        }
        public string[] GetCompleteProtocols(string input)
        {
            return GetCompleteProtocols(input, null);
        }
        private string[] GetCompleteProtocols(string input, List<string> outputList)
        {
            if (outputList == null)
                outputList = new List<string>();

            //当传入字符串为空，即递归处理完后，提交消息数组
            if (String.IsNullOrEmpty(input))
                return outputList.ToArray();

            //若缓存不为空，则合并输入消息
            if (!String.IsNullOrEmpty(partialProtocal))
                input = partialProtocal + input;

            //若匹配协议头，则提取协议头以及包含的文件信息，把剩下的部分递归调用该函数
            if (Regex.IsMatch(input, pattern))
            {
                //获取匹配的值
                string match = Regex.Match(input, pattern).Groups[0].Value;
                outputList.Add(match);

                //记得在添加消息的时候清理缓存
                partialProtocal = "";

                //分离出未处理的字符串
                input = input.Substring(match.Length);

                //递归调用函数，传入未处理的字符串和已经处理完的消息数组
                GetCompleteProtocols(input, outputList);
            }
            else//若不匹配，则说明消息不完整，存入缓存等待下一次处理
            {
                partialProtocal = input;
            }
            return outputList.ToArray();
        }
    }
    public class Protocol
    {
    }

    /// <summary>
    /// 该帮助类把xml格式的协议消息转换成强类型协议
    /// </summary>
    public class MessageHelper
    {
        private XmlNode messageNode;
        private XmlNode root;
        public MessageHelper(string protocol)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(protocol);//从指定字符串中加载xml文档
            root = doc.DocumentElement;//获取xml文档的根
            messageNode = root.SelectSingleNode("message");
        }
        /// <summary>
        /// 解析xml格式消息，返回强类型协议，失败返回null
        /// </summary>
        /// <returns>Protocol 或 null</returns>
        public Protocol GetProtocol()
        {
            if (messageNode.Attributes["type"].Value == "Conversation")
            {
                string sourceName = messageNode.Attributes["sourceName"].Value;
                string destinationName = messageNode.Attributes["destinationName"].Value;
                string content = messageNode.Attributes["content"].Value;
                //返回消息类型
                return new MessageProtocol(sourceName, destinationName, content);
            }
            else if (messageNode.Attributes["type"].Value == "File")
            {
                string fileName = messageNode.Attributes["fileName"].Value;
                int port = Convert.ToInt32(messageNode.Attributes["port"].Value);
                string sourceName = messageNode.Attributes["sourceName"].Value;
                string destinationName = messageNode.Attributes["destinationName"].Value;
                string mode = messageNode.Attributes["mode"].Value.ToLower();

                FileProtocol.FileRequestMode requestMode = (mode == "send" ? FileProtocol.FileRequestMode.Send : FileProtocol.FileRequestMode.Receive);
                //返回文件类型
                return new FileProtocol(requestMode, port, sourceName, destinationName, fileName);
            }
            else if (messageNode.Attributes["type"].Value == "SignIn")
            {
                string userName = messageNode.Attributes["userName"].Value;
                string password = messageNode.Attributes["password"].Value;

                return new SignInProtocol(userName, password);
            }
            else if (messageNode.Attributes["type"].Value == "UserDetailInfo")
            {
                string userName = messageNode.Attributes["userName"].Value;
                string password = messageNode.Attributes["password"].Value;
                string saying = messageNode.Attributes["saying"].Value;
                string iconPath = messageNode.Attributes["iconPath"].Value;
                UserDetailInfo info = new UserDetailInfo(userName, password, saying, iconPath, null);
                return new UserDetailInfoProtocol(info);
            }
            else if (messageNode.Attributes["type"].Value == "UserPublicInfo")
            {
                string userName = messageNode.Attributes["userName"].Value;
                string saying = messageNode.Attributes["saying"].Value;
                PublicUserInfo info = new PublicUserInfo(userName, "", saying);
                return new UserPublicInfoProtocol(info);
            }
            else if (messageNode.Attributes["type"].Value == "AddFriendsRequest")
            {
                string sponsor = messageNode.Attributes["sponsor"].Value;
                string respondent = messageNode.Attributes["respondent"].Value;
                return new AddFriendsRequestProtocol(sponsor, respondent);
            }
            else if (messageNode.Attributes["type"].Value == "AddFriendsRespond")
            {
                string sponsor = messageNode.Attributes["sponsor"].Value;
                string respondent = messageNode.Attributes["respondent"].Value;
                string respond = messageNode.Attributes["respond"].Value;
                return new AddFriendsRespondProtocol(sponsor, respondent,respond);
            }
            else if (messageNode.Attributes["type"].Value == "SearchFriends")
            {
                string searchName = messageNode.Attributes["searchName"].Value;
                string searchAge = messageNode.Attributes["searchAge"].Value;
                string searchSex = messageNode.Attributes["searchSex"].Value;
                return new SearchFriendsProtocol(searchName, searchSex , searchAge);
            }
            else
                return null;
        }
    }

}
