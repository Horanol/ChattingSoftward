using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
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
                "Conversation", sourceName, destinationName, content);
        }

    }
}
