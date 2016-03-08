using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class SendFileRespondHandler: IHandlerProtocol
    {
        public void HandlerProtocol(Protocol _pro)
        {
            SendFileRespondProtocol pro = (SendFileRespondProtocol)_pro;
            ServersController.SendFileRespond(pro);
        }
    }
}
