﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace 聊天软件
{
    public class MessageHandler : IHandlerProtocol
    {
        private Server myServer;
        public MessageHandler(Server _myServer)
        {
            myServer = _myServer;
        }
        /// <summary>
        /// 处理转发消息
        /// </summary>
        /// <param name="msgArray"></param>
        public void HandlerProtocol(Protocol _pro)
        {
            MessageProtocol pro = (MessageProtocol)_pro;
            //若是客户端和服务器的沟通消息
            if (pro.sourceName == "client")
            {
                if (pro.content == "ReadyToReceiveOfflineMsg")
                {
                    //把离线时候缓存的消息发送给新连线的server
                    ServersController.SendOfflineMsg(myServer);
                }
            }
            else
            {
                //服务器端显示日志
                Server.serverLogTextBox.Text += "收到信息: " + pro.content + "  来自 " + pro.sourceName + "   [" + myServer.remoteEndPoint.ToString() + "]   发送给: " + pro.destinationName + Environment.NewLine;
                //委托ServersController转发消息
                ServersController.SendMessage(pro);
            }
        }
    }
}
