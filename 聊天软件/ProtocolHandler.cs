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
        private readonly FileRequestMode mode;
        private readonly int port;
        private readonly string fileName;

        /// <summary>
        /// 定义枚举类型表示发送和接收文件模式
        /// </summary>
        public enum FileRequestMode
        {
            Send = 0,
            Receive,
        }

        public FileProtocol(FileRequestMode mode, int port, string fileName)
        {
            this.mode = mode;
            this.port = port;
            this.fileName = fileName;
        }

        public FileRequestMode Mode { get { return mode; } }
        public int Port { get { return port; } }
        public string FileName { get { return fileName; } }

        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" name=\"{1}\" mode=\"{2}\" port=\"{3}\" /></protocol>",
                "file", fileName, mode, port);
        }
    }
    /// <summary>
    /// 消息协议类，这是构造xml格式消息的地方
    /// </summary>
    public class MessageProtocol : Protocol
    {
        public string sourceName { get; set; }
        public string destinationName { get; set; }
        public string message { get; set; }
        public MessageProtocol(string _sourceName, string _destinationName, string _message)
        {
            this.sourceName = _sourceName;
            this.destinationName = _destinationName;
            this.message = _message;
        }
        //构造xml格式消息
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" sourceName=\"{1}\" destinationName=\"{2}\" content=\"{3}\" /></protocol>",
                "conversation", sourceName, destinationName, message);
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
        public Protocol GetProtocol()
        {
            if (messageNode.Attributes["type"].Value == "conversation")
            {
                string sourceName = messageNode.Attributes["sourceName"].Value;
                string destinationName = messageNode.Attributes["destinationName"].Value;
                string message = messageNode.Attributes["message"].Value;
                //返回消息类型
                return new MessageProtocol(sourceName, destinationName, message);
            }
            else if (messageNode.Attributes["type"].Value == "file")
            {
                string fileName = messageNode.Attributes["name"].Value;
                int port = Convert.ToInt32(messageNode.Attributes["port"].Value);

                string mode = messageNode.Attributes["mode"].Value;
                mode = mode.ToLower();
                FileProtocol.FileRequestMode requestMode = (mode == "send" ? FileProtocol.FileRequestMode.Send : FileProtocol.FileRequestMode.Receive);
                //返回文件类型
                return new FileProtocol(requestMode, port, fileName);
            }
            else if (messageNode.Attributes["type"].Value == "signIn")
            {
                string userName = messageNode.Attributes["userName"].Value;
                string password = messageNode.Attributes["password"].Value;

                return new SignInProtocol(userName, password);
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
