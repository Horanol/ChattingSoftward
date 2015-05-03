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
        public string clientName;
        private NetworkStream streamToServer;
        //这样子写还没有新建client引用，只有要给引用分配对象时才建立引用
        private TcpClient client;
        private IPAddress serverIPAddress;
        private IPAddress clientIPAddress;
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

            //若是服务器单独给客户端发的消息
            if (pro.sourceName.ToLower() == "server")
            {
                if (pro.content == "LoginAccepted")
                {
                    LogicController.CanLogin();
                }
                else if (pro.content == "LoginRefused")
                {
                    LogicController.CanNotLogin();
                }
                else if (pro.content == "UserNameAccepted")
                {
                    LogicController.CanUseTheUserName();
                }
                else if (pro.content == "UserNameRefused")
                {
                    LogicController.CanNotUseTheUserName();
                }
            }
            //若是别的好友的消息
            else
            {
                //pro.sourceName表示好友的名字,转发好友的消息
                LogicController.PassMessage(pro.sourceName, pro.content);
            }

        }
        private void HandleFileRequest(FileProtocol pro)
        {

        }
        public bool SendFile(string filePath)
        {
            //发送协议到服务器
            string fileName = Path.GetFileName(filePath);
            FileProtocol pro = new FileProtocol(FileProtocol.FileRequestMode.Send, 8600, clientName, "server", fileName);
            if(this.TryConnectToServer())
                SendMessage(pro.ToString());

            //在客户端监听8600端口，用于传送文件
            TcpListener fileListener = new TcpListener(clientIPAddress, 8600);
            fileListener.Start();
            //中断，等待远程连接
            TcpClient localClient = fileListener.AcceptTcpClient();

            NetworkStream fileStream = localClient .GetStream();
            //创建文件流
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] fileBuffer = new byte[1024];
            int bytesRead;
            //将文件流写入网络流
            try
            {
                do
                {
                    bytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length);
                    fileStream.Write(fileBuffer, 0, bytesRead);
                } while (bytesRead > 0);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //把文件流，网络流，监听端和客户端都回收
                fileStream.Dispose();
                fs.Dispose();
                localClient.Close();
                fileListener.Stop();
            }

        }
    }
}
