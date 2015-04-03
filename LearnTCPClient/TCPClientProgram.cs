using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LearnTCPClient
{
    class TCPClientProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client is running");
            //新建一个客户端套接字
            TcpClient client = new TcpClient();
            try
            {
                //连接到远程服务器的地址和端口号
                client.Connect(IPAddress.Parse("192.168.10.1"), 8500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            //client的Client属性返回一个Socket对象，它的LocalEndPoint和RemoteEndPoint属性分别包含了本地和远程主机的地址信息
            Console.WriteLine("Server Connected!! Local:{0} -->Server:{1}", client.Client.LocalEndPoint, client.Client.RemoteEndPoint);


            ////建立三个套接字，连接到服务器
            //for (int i = 0; i <= 2; i++)
            //{
            //    try
            //    {
            //        client = new TcpClient();
            //        client.Connect(IPAddress.Parse("192.168.10.1"), 8500);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        Console.ReadKey();
            //        return;
            //    }
            //    //打印连接信息
            //    Console.WriteLine("Server Connected!! Local:{0} -->Server:{1}", 
            //        client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
            //}
            //获取客户端到服务器的数据流
            NetworkStream streamToServer = client.GetStream();
            do
            {
                try//若服务器关闭，则抛出异常
                {
                    string message = Console.ReadLine();
                    //把string文本转成字节数组写入缓存
                    byte[] buffer = Encoding.Unicode.GetBytes(message);
                    //把字节数组写入数据流
                    try//若服务器关闭数据流，则跳出循环
                    {
                        streamToServer.Write(buffer, 0, buffer.Length);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    Console.WriteLine("Sent:    {0}", message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            } while (true);
            //这是一个枚举类型的键盘按键
            ConsoleKey key;
            do
            {
                //读入一个键盘按键，true设置不显示在窗口中，把该值返回给key变量
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);//若按下Q键退出循环
        }
    }
}
