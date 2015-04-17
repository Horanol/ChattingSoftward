using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
namespace 聊天软件_客户端
{
    public class Client
    {
        private const int BufferSize = 8192;
        private byte[] buffer;
        private NetworkStream streamToServer;
        //这样子写还没有新建client引用，只有要给引用分配对象时才建立引用
        private TcpClient client;
        private LoginForm loginForm;
        public Client(LoginForm _loginForm)
        {
            //做好初始化工作
            buffer = new byte[BufferSize];
            loginForm = _loginForm;
            
        }
        public bool TryConnectToServer()
        {
            if (client == null)
                client = new TcpClient();
            //若已经有引用但没连接，则尝试连接，否则不做任何事
            if (client.Connected == false)
            {
                try
                {
                    //client = new TcpClient();
                    client.Connect(IPAddress.Parse("10.170.69.113"), 8500);
                    if (client.Connected)
                    {
                        streamToServer = client.GetStream();
                        ReceiveMessage();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 传入构造好协议头的消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMessage(string msg)
        {
            //把消息转换成字节数组
            byte[] temp = Encoding.Unicode.GetBytes(msg);

            //尝试给服务器数据流发送消息
            try
            {
                streamToServer.Write(temp, 0, temp.Length);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public void ReceiveMessage()
        {
            try
            {
                //开始异步读取服务器传来的消息,读入缓存buffer,读完后调用回调函数ReadComplete()
                AsyncCallback callBack = new AsyncCallback(ReadComplete);
                streamToServer.BeginRead(buffer, 0, BufferSize, callBack, null);
            }
            catch
            {
                throw new Exception("无法读取");
            }
        }
        private void ReadComplete(IAsyncResult ar)
        {
            int bytesRead;

            try
            {
                //尝试结束读取，若读取到的字节数为0则说明服务器关闭了数据流
                bytesRead = streamToServer.EndRead(ar);
                //if (bytesRead == 0)
                //{
                //    streamToServer.Dispose();
                //    client.Close();
                //    return;
                //}

                //获取带有协议头的字符串，可能是多个消息一起
                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);

                //截取完整的消息形成消息数组
                ProtocolSpliter spliter = new ProtocolSpliter();
                string[] strArray = spliter.GetCompleteProtocols(msg);

                //获取消息或文件强类型
                foreach (string str in strArray)
                {
                    MessageHelper helper = new MessageHelper(str);
                    Protocol pro = helper.GetProtocol();

                    if (pro.GetType() == typeof(MessageProtocol))
                    {
                        HandleMessage((MessageProtocol)pro);
                    }
                    else
                    {
                        HandleFileRequest((FileProtocol)pro);
                    }
                }

                Array.Clear(buffer, 0, buffer.Length);//每次读取完清理缓存，避免脏读
                //循环读取服务器数据
                ReceiveMessage();

            }
            catch
            {
                if (streamToServer != null)
                    streamToServer.Dispose();
                //close()使得client.Connected == false
                client.Close();
            }
        }

        /// <summary>
        /// 处理显示消息
        /// </summary>
        /// <param name="msgArray"></param>
        private void HandleMessage(MessageProtocol pro)
        {
            //客户端显示消息
            //messageBox.Text += pro.message + "\n";

            //若是服务器单独给客户端发的消息
            if (pro.sourceName.ToLower() == "server")
            {
                if (pro.message.ToLower() == "accepted")
                {
                    loginForm.AcceptLogin();
                }
                else if (pro.message.ToLower() == "refused")
                {
                    loginForm.RefuseLogin();
                }
            }
             //若是客户端转发别人的消息
            else
            {
                
            }

        }
        private void HandleFileRequest(FileProtocol pro)
        {

        }
    }
}
