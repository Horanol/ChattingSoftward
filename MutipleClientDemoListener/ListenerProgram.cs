using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MutipleClientsDemoListener
{
    class ListenerProgram
    {
        public static List<Server> servers;
        static void Main(string[] args)
        {
            //初始化服务器
            Console.WriteLine("--------------------------------服务器已开启---------------------------------");
            IPAddress ip = IPAddress.Parse("192.168.10.1");
            TcpListener listener = new TcpListener(ip, 8500);
            servers = new List<Server>();


            //服务器开始监听
            listener.Start();
            Console.WriteLine("--------------------------------服务器正在监听-------------------------------");
            while (true)
            {
                //循环获取客户端连接
                TcpClient newClient = listener.AcceptTcpClient();
                Server newServer = new Server(newClient);
            }
        }
        public static void BroadcastMessage(string msg,Server exception)
        {
            //除自身外，广播消息
            foreach (Server server in servers)
            {
                if(server != exception)
                    server.SendMessage(msg);
            }
        }
    }
}
