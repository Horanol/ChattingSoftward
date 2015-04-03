using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace LearnFileTransformServer
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is running ...");
            IPAddress ip = IPAddress.Parse("192.168.10.1");
            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start();
            Console.WriteLine("Start Listening ...");

            while (true)
            {
                //获取一个连接
                TcpClient client = listener.AcceptTcpClient();
                Server ser = new Server(client);
                ser.BeginRead();//开始异步读取文件
            }
        }
    }
}
