using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件
{
    public class SendFileRequestHandler:IHandlerProtocol
    {
        public void HandlerProtocol(Protocol _pro)
        {
            SendFileRequestProtocol pro = (SendFileRequestProtocol)_pro;
            ServersController.SendFileRequest(pro);
        }
    }
}
