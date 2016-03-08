using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
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
