using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class SpecialEffectProtocol:Protocol
    {
        public string sourceName { get; set; }
        public string destinationName { get; set; }
        public string effect { get; set; }

        public SpecialEffectProtocol(string _sourceName, string _destinationName, string _effect)
        {
            this.sourceName = _sourceName;
            this.destinationName = _destinationName;
            this.effect = _effect;
        }
        //构造xml格式消息
        public override string ToString()
        {
            return String.Format("<protocol><message type=\"{0}\" sourceName=\"{1}\" destinationName=\"{2}\" effect=\"{3}\" /></protocol>",
                "SpecialEffect", sourceName, destinationName, effect);
        }
    }
}
