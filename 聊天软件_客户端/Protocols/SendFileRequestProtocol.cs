using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    /// <summary>
    /// sourceName 为发送方的昵称，
    /// destinationName 为接收方的昵称，
    /// fileName为发送方发送文件的位置，用Path.GetFileName()获取文件名，
    /// </summary>
    public class SendFileRequestProtocol:Protocol
    {
        public string sourceName { get; set; }
        public string destinationName { get; set; }
        public string fileName { get; set; }

        public SendFileRequestProtocol(string _sourceName, string _destinationName, string _fileName)
        {
            sourceName = _sourceName;
            destinationName = _destinationName;
            fileName = _fileName;
        }
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" sourceName=\"{1}\" destinationName=\"{2}\" fileName=\"{3}\" /></protocol>",
                "SendFileRequest", sourceName, destinationName, fileName);
        }
    }
}
