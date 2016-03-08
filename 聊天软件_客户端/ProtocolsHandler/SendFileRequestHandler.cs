using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聊天软件_客户端
{
    //收到一个好友发来的发送文件请求时
    //调用主面板方法，创建一个文件请求确认窗口
    public class SendFileRequestHandler:IHandlerProtocol
    {
        public void HandlerProtocol(Protocol _pro)
        {
            SendFileRequestProtocol pro = (SendFileRequestProtocol)_pro;
            ClientMainForm.OnShowFileRequestForm(pro);
        }
    }
}
