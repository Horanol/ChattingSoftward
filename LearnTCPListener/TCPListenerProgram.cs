using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
//引入套接字和网络连接的命名空间
namespace LearnTCPListener
{
    class TCPListenerProgram
    {
        static void Main(string[] args)
        {
            const int BufferSize = 8192;//设置缓存大小为8192字节
            /*
             * 服务器监听端口8500
             */
            
            //构建本地ip地址
            IPAddress ip = IPAddress.Parse("192.168.10.1");
            //在本地ip地址的8500端口监听是否有连接尝试
            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start();
            Console.WriteLine("Server is running。。。");

            /*
             * 有客户端连接时候，
             * 获取连接并打印信息，
             * 获取客户端的数据流
             */
            Console.WriteLine("Start Listening。。。");
            //获取到一个客户端连接，这是一个中断方法，没有客户端连接的时候不会执行下面的语句
            TcpClient remoteClient = listener.AcceptTcpClient();
            //打印连接到的客户端信息
            Console.WriteLine("Client Connected!  Local: {0}    <-----  Client: {1}",
                remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);
            //获取客户端的数据流
            NetworkStream streamToClient = remoteClient.GetStream();

            /*
             * 循环接收一个客户端传来的信息并显示出来，
             * 这时候不能处理其他客户端的信息
             */
            do
            {
                try//若客户端关闭，则抛出异常
                {
                    byte[] buffer = new byte[BufferSize];
                    //从流中读取数据到字节数组中，一次读取BufferSize个字节，返回值为实际一次读取到的字节数
                    int bytesRead = streamToClient.Read(buffer, 0, BufferSize);
                    //若读取到的字节为0，即客户端关闭了数据流，则跳出循环
                    if (bytesRead == 0)
                    {
                        Console.WriteLine("Client offline");
                        break;
                    }
                    //把缓存中的字节解码为字符串，第三个参数是要解码的字节数
                    string message = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: {0}    {1} bytes", message, bytesRead);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

            } while (true);
            Console.ReadKey();
        }
    }
}
