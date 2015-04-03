using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace LearnFileTransformServer
{
    class Server
    {
        private TcpClient client;
        private NetworkStream streamToServer;
        private const int BufferSize = 8192;
        private byte[] buffer;
        private ProtocolHandler handler;

        public Server(TcpClient client)
        {
            this.client = client;

            Console.WriteLine("\nClient connected!  Local:  {0}     Client: {1}", client.Client.LocalEndPoint, client.Client.RemoteEndPoint);

            streamToServer = client.GetStream();
            buffer = new byte[BufferSize];
            handler = new ProtocolHandler();
        }

        public void BeginRead()
        {
            AsyncCallback callBack = new AsyncCallback(OnReadComplete);
            streamToServer.BeginRead(buffer, 0, BufferSize, callBack, null);

        }
        private void OnReadComplete(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                bytesRead = streamToServer.EndRead(ar);
                Console.WriteLine("Reading data,    {0} bytes...", bytesRead);
                if (bytesRead == 0)
                {
                    Console.WriteLine("Client offline!");
                    return;
                }
                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Array.Clear(buffer, 0, buffer.Length);//清理缓存

                //获取protocol数组
                string[] protocolArray = handler.GetProtocol(msg);
                //异步调用处理协议方法，不然会比较耗时
                foreach (string pro in protocolArray)
                {
                    ParameterizedThreadStart start = new ParameterizedThreadStart(handleProtocol);
                    start.BeginInvoke(pro, null, null);
                }
                //再次调用BeginRead()，完成时调用自身，形成无限循环
                BeginRead();

            }
            catch (Exception ex)
            {
                if (streamToServer != null)
                    streamToServer.Dispose();
                client.Close();
                Console.WriteLine(ex.Message);
            }
        }
        private void handleProtocol(object obj)
        {
            string pro = obj as string;
            ProtocolHelper helper = new ProtocolHelper(pro);
            FileProtocol protocol = helper.GetProtocol();

            if (protocol.Mode == FileRequestMode.Send)
            {
                //客户端发送文件，服务器接收文件
                receiveFile(protocol);
            }
            else if (protocol.Mode == FileRequestMode.Receive)
            {
                //客户端接收文件，服务器发送文件
              //  sendFile(protocol);
            }
        }

        private void receiveFile(FileProtocol protocol)
        {
            //获取客户端ip地址
            IPEndPoint endpoint = client.Client.RemoteEndPoint as IPEndPoint;
            IPAddress ip = endpoint.Address;
            //获取远程用于接收文件的端口号，使用新的端口号传送文件
            endpoint = new IPEndPoint(ip, protocol.Port);

            TcpClient localClient;
            try
            {
                localClient = new TcpClient();
                localClient.Connect(endpoint);
            }
            catch
            {
                Console.WriteLine("无法连接客户端");
                return;
            }
            //获取发送文件的流
            NetworkStream streamToClient = localClient.GetStream();
            //随机生成一个在当前目录下的文件名字
            string path = Environment.CurrentDirectory + "/" + generateFileName(protocol.FileName);
            byte[] fileBuffer = new byte[1024];
            FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);

            //从缓存Buffer中读入到文件流
            int bytesRead;
            int totalBytes = 0;
            do
            {
                bytesRead = streamToClient.Read(buffer, 0, BufferSize);
                fs.Write(buffer, 0, bytesRead);
                totalBytes += bytesRead;
                Console.WriteLine("Receiving {0} bytes ...", totalBytes);
            } while (bytesRead > 0);
            Console.WriteLine("Total {0} bytes received,Done!", totalBytes);

            streamToClient.Dispose();
            fs.Dispose();
            localClient.Close();

        }
        //随机用时间生成文件名
        private string generateFileName(string fileName)
        {
            DateTime now = DateTime.Now;
            return string.Format("{0}_{1}_{2}_{3}", now.Minute, now.Second, now.Millisecond, fileName);
        }
    }
       
}
