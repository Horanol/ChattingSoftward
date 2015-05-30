using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    public class SendFileRespondHandler: IHandlerProtocol
    {
        private Client myClient;
        public SendFileRespondHandler(Client _myClient)
        {
            myClient = _myClient;
        }
        public void HandlerProtocol(Protocol _pro)
        {
            SendFileRespondProtocol pro = (SendFileRespondProtocol)_pro;
            FileHandler handler = new FileHandler(myClient);
            handler.SendFile(myClient.clientIPAddress.ToString(), pro.destinationName, pro.fileName);
        }

    }
}
