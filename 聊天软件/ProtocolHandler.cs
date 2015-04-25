using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;

namespace 聊天软件
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
    /// 文件协议类，这是构造xml格式消息的地方
    /// </summary>    
    public class FileProtocol : Protocol
    {
        public FileRequestMode mode { get; set; }
        public int port { get; set; }
        public string sourceName { get; set; }
        public string destinationName { get; set; }
        public string fileName { get; set; }

        /// <summary>
        /// 定义枚举类型表示发送和接收文件模式
        /// </summary>
        public enum FileRequestMode
        {
            Send = 0,
            Receive,
        }

        public FileProtocol(FileRequestMode _mode, int _port, string _sourceName,string _destinationName,string _fileName)
        {
            this.mode = _mode;
            this.port = _port;
            this.sourceName = _sourceName;
            this.destinationName = _destinationName;
            this.fileName = _fileName;
        }


        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" sourceName=\"{1}\" destinationName=\"{2}\" fileName=\"{3}\" mode=\"{4}\" port=\"{5}\" /></protocol>",
                "file", sourceName,destinationName,fileName, mode, port);
        }
    }
    /// <summary>
    /// 消息协议类，这是构造xml格式消息的地方
    /// </summary>
    public class MessageProtocol : Protocol
    {
        public string sourceName { get; set; }
        public string destinationName { get; set; }
        public string content { get; set; }
        public MessageProtocol(string _sourceName, string _destinationName, string _message)
        {
            this.sourceName = _sourceName;
            this.destinationName = _destinationName;
            this.content = _message;
        }
        //构造xml格式消息
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" sourceName=\"{1}\" destinationName=\"{2}\" content=\"{3}\" /></protocol>",
                "conversation", sourceName, destinationName, content);
        }

    }
    public class SignInProtocol : Protocol
    {
        public string userName { get; set; }
        public string password { get; set; }
        public SignInProtocol(string _userName, string _password)
        {
            userName = _userName;
            password = _password;
        }
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" userName=\"{1}\" password=\"{2}\" /></protocol>",
                "signIn", userName, password);
        }
    }
    public class UserDetailInfoProtocol : Protocol
    {
        public string userName;
        public string password;
        public string sayings;
        public string iconPath;
        public UserDetailInfoProtocol(UserDetailInfo info)
        {
            userName = info.userName;
            password = info.password;
            sayings = info.sayings;
            iconPath = info.iconPath;
        }
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" userName=\"{1}\" password=\"{2}\" saying=\"{3}\" iconPath=\"{4}\" /></protocol>",
                         "UserDetailInfo", userName, password, sayings, iconPath);
        }
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
        /// 返回强类型协议，失败返回null
        /// </summary>
        /// <returns>Protocol 或 null</returns>
        public Protocol GetProtocol()
        {
            if (messageNode.Attributes["type"].Value == "conversation")
            {
                string sourceName = messageNode.Attributes["sourceName"].Value;
                string destinationName = messageNode.Attributes["destinationName"].Value;
                string content = messageNode.Attributes["content"].Value;
                //返回消息类型
                return new MessageProtocol(sourceName, destinationName, content);
            }
            else if (messageNode.Attributes["type"].Value == "file")
            {
                string fileName = messageNode.Attributes["fileName"].Value;
                int port = Convert.ToInt32(messageNode.Attributes["port"].Value);
                string sourceName = messageNode.Attributes["sourceName"].Value;
                string destinationName = messageNode.Attributes["destinationName"].Value;
                string mode = messageNode.Attributes["mode"].Value.ToLower();

                FileProtocol.FileRequestMode requestMode = (mode == "send" ? FileProtocol.FileRequestMode.Send : FileProtocol.FileRequestMode.Receive);
                //返回文件类型
                return new FileProtocol(requestMode,port,sourceName,destinationName,fileName);
            }
            else if (messageNode.Attributes["type"].Value == "signIn")
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
                UserDetailInfo info = new UserDetailInfo(userName, password, saying, iconPath);
                return new UserDetailInfoProtocol(info);
            }
            else
                return null;
        }
    }

}
