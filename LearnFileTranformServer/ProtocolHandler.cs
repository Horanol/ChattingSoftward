using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;

namespace LearnFileTransformServer
{
    /// <summary>
    /// 协议类，用来判断是否匹配文件协议
    /// </summary>
    class ProtocolHandler
    {
        private string partialProtocal;
        string pattern = "(^<protocol>.*?</protocol>)";

        public ProtocolHandler()
        {
            partialProtocal = "";
        }
        public string[] GetProtocol(string input)
        {
            return GetProtocol(input, null);
        }
        private string[] GetProtocol(string input, List<string> outputList)
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
                GetProtocol(input, outputList);
            }
            else//若不匹配，则说明消息不完整，存入缓存等待下一次处理
            {
                partialProtocal = input;
            }
            return outputList.ToArray();
        }
    }
    
    /// <summary>
    /// 定义枚举类型表示发送和接收文件模式
    /// </summary>
    public enum FileRequestMode
    {
        Send = 0,
        Receive,
    }

    /// <summary>
    /// 结构体，用来定义文件协议头
    /// </summary>    
    public struct FileProtocol 
    {
        private readonly FileRequestMode mode;
        private readonly int port;
        private readonly string fileName;

        public FileProtocol(FileRequestMode mode ,int port,string fileName)
        {
            this.mode = mode;
            this.port = port;
            this.fileName = fileName;
        }

        public FileRequestMode Mode
        { 
            get { return mode; } 
        }
        public int Port
        {
            get { return port; }
        }
        public string FileName
        {
            get { return fileName; }
        }

        public override string ToString()
        {
            return String.Format("<protocol><file name=\"{0}\" mode=\"{1}\" port=\"{2}\" /></protocol>", 
                fileName, mode, port);
        }
    }

    /// <summary>
    /// 这个类专门用来把xml格式协议映射成上面定义的强类型对象结构体
    /// </summary>
    public class ProtocolHelper
    {
        private XmlNode fileNode;
        private XmlNode root;

        public ProtocolHelper(string protocol)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(protocol);//从指定字符串中加载xml文档
            root = doc.DocumentElement;//获取xml文档的根
            fileNode = root.SelectSingleNode("file");
        }

        //读取xml文件中的FileRequestMode并转换成结构体的send和receive（私有）
        private FileRequestMode GetFileMode()
        {
            string mode = fileNode.Attributes["mode"].Value;
            mode = mode.ToLower();
            if (mode == "send")
                return FileRequestMode.Send;
            else
                return FileRequestMode.Receive;
        }

        /// 读取xml文件的fileName和port属性，返回一个构造好的协议头
        public FileProtocol GetProtocol()
        {
            FileRequestMode mode = GetFileMode();
            string fileName = "";
            int port = 0;

            fileName = fileNode.Attributes["name"].Value;
            port = Convert.ToInt32(fileNode.Attributes["port"].Value);

            return new FileProtocol(mode, port, fileName);

        }



    }
}
