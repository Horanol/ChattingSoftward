using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace LearnFileTransform
{
    class Client
    {
        private const int BufferSize = 8192;
        private byte[] buffer;
        private TcpClient client;
        private NetworkStream streamToServer;

        public Client()
        {
            try
            {
                client = new TcpClient();
                client.Connect("192.168.10.1", 8500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            buffer = new byte[BufferSize];
            Console.WriteLine("Server Connected! local:{0}  --> Server:{1}", client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
            streamToServer = client.GetStream();
        }

        public void SendMessage(string msg)
        {
            byte[] temp = Encoding.Unicode.GetBytes(msg);
            try
            {
                streamToServer.Write(temp, 0, temp.Length);
                Console.WriteLine("Sent:    {0}", msg);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void BeginSendFile(string filePath)
        {
            //这是一个委托，签名是void(Object)类型
            ParameterizedThreadStart start = new ParameterizedThreadStart(BeginSendFile);
            //开始异步执行方法BeginSendFile
            start.BeginInvoke(filePath, null, null);
        }
        private void BeginSendFile(object obj)
        {
            string filePath = obj as string;
            SendFile(filePath);
        }
        //发送文件
        public void SendFile(string filePath)
        {
            
            IPAddress ip = IPAddress.Parse("192.168.10.1");
            TcpListener listener = new TcpListener(ip, 0);
            listener.Start();

            //IPEndPoint 是EndPoint的子类，内仅含有ip地址和端口号
            //获取本地监听的端口号
            IPEndPoint endPoint = listener.LocalEndpoint as IPEndPoint;
            int listeningPort = endPoint.Port;

            //GetFileName用来获取路径最后的文件名和扩展名
            //获取发送的协议字符串
            string fileName = Path.GetFileName(filePath);
            FileProtocol protocol = new FileProtocol(FileRequestMode.Send, listeningPort, fileName);
            string pro = protocol.ToString();

            //发送协议到服务器
            SendMessage(pro);

            //临时新建一个和服务器的连接，获得连接到服务器的数据流
            TcpClient localClient = listener.AcceptTcpClient();
            Console.WriteLine("Start sending file...");
            NetworkStream stream = localClient.GetStream();

            //创建文件流
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] fileBuffer = new byte[1024];
            int bytesRead;
            int totalBytes = 0;

            SendStatus status = new SendStatus(filePath);
            //将文件流转写入网络流
            try
            {
                do
                {
                    //模拟传送效果，延迟10毫秒
                    Thread.Sleep(10);
                    //返回读取的字节数
                    bytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length);
                    stream.Write(fileBuffer, 0, bytesRead);
                    totalBytes += bytesRead;//总共发送的字节数
                    status.PrintStatus(totalBytes);
                } while (bytesRead > 0);
                Console.WriteLine("Total  {0} bytes sent,Done!", totalBytes);
            }
            catch
            {
                Console.WriteLine("Server has lost...");
            }
            finally
            {
                stream.Dispose();
                fs.Dispose();
                localClient.Close();//引用还在，只是实例被释放了
                listener.Stop();//关闭临时监听器
            }
        }
    }


}
