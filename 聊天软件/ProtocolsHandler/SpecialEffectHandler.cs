using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class SpecialEffectHandler:IHandlerProtocol
    {
        public void HandlerProtocol(Protocol _pro)
        {
            SpecialEffectProtocol pro = (SpecialEffectProtocol)_pro;
            if (pro.effect == "ShakeConversationForm")
            {
                ServersController.SendSpecialEffect(pro);
            }

        }
    }
}
