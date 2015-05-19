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

        public string clientName;
        public IPAddress serverIPAddress;
        public IPAddress clientIPAddress;
        public Client()
        {
            //做好初始化工作
            buffer = new byte[BufferSize];
            serverIPAddress = Dns.GetHostAddresses(Dns.GetHostName())//这个函数返回一堆ip地址，包括ipv6，ipv4等待，所以需要筛选
                                                                             .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).First();
            clientIPAddress = Dns.GetHostAddresses(Dns.GetHostName())//这个函数返回一堆ip地址，包括ipv6，ipv4等待，所以需要筛选
                                                                                  .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).First();
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
                    client.Connect(serverIPAddress, 8500);
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
                    if (pro != null)
                    {
                        HandlerFactory fac = new HandlerFactory(this);
                        IHandlerProtocol handler = fac.CreateHandler(pro);
                        handler.HandlerProtocol(pro);
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

    }
}
