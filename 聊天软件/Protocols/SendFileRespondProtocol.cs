using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class SendFileRespondProtocol : Protocol
    {
        public string sourceName { get; set; }
        public string destinationName { get; set; }
        public string fileName { get; set; }
        public string respond { get; set; }

        public SendFileRespondProtocol(string _sourceName, string _destinationName, string _fileName,string _respond)
        {
            sourceName = _sourceName;
            destinationName = _destinationName;
            fileName = _fileName;
            respond = _respond;
        }
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" sourceName=\"{1}\" destinationName=\"{2}\" fileName=\"{3}\" respond=\"{4}\" /></protocol>",
                "SendFileRespond", sourceName, destinationName, fileName,respond);
        }
    }
}
