using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
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

        public FileProtocol(FileRequestMode _mode, int _port, string _sourceName, string _destinationName, string _fileName)
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
                "File", sourceName, destinationName, fileName, mode, port);
        }
    }
}
