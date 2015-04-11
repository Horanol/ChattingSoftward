using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MultipleClientsDemoClient
{
    class Client
    {
        private const int BufferSize = 8192;
        private byte[] buffer;
        private NetworkStream streamToServer;
        //这样子写还没有新建client引用，只有要给引用分配对象时才建立引用
        private TcpClient client;
        private RequestHandler handler;

        public Client()
        {
            //做好初始化工作
            buffer = new byte[BufferSize];
            handler = new RequestHandler();

            //尝试连接服务器，若成功连接服务器，则准备接受服务器信息
            if (TryConnectToServer())
                ReceiveMessage();
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
                        client = new TcpClient();
                        client.Connect(IPAddress.Parse("10.170.26.217"), 8500);
                        if (client.Connected)
                        {
                            Console.WriteLine("服务器已连接!    当前客户端:  {0}     --->当前服务器: {1}",
                                client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
                            streamToServer = client.GetStream();
                            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~可以开始聊天了~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                            //成功连接服务器，则准备监听服务器信息
                            ReceiveMessage();
                            return true;
                        }
                    }
                    catch {
                        Console.WriteLine("-------------------------------无法连接到服务器！----------------------------");
                        return false;                        
                    }
                }
                return true;
        }
        public void SendMessage(string msg)
        {
            //尝试连接
            if (TryConnectToServer())
            {
                //给消息加上协议头
                msg = String.Format("[length={0}]{1}", msg.Length, msg);

                //把消息转换成字节数组
                byte[] temp = Encoding.Unicode.GetBytes(msg);

                //尝试给服务器数据流发送消息
                try
                {
                    streamToServer.Write(temp, 0, temp.Length);
                }
                catch
                {
                    Console.WriteLine("\n---------------------------无法发送消息！-----------------------------\n");
                }
            }
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
                    Console.WriteLine("\n-----------------------------接收消息失败！--------------------\n");
                }
        }
        private void ReadComplete(IAsyncResult ar)
        {
            int bytesRead;

            try
            {
                //尝试结束读取，若读取到的字节数为0则说明服务器关闭了数据流
                bytesRead = streamToServer.EndRead(ar);
                if (bytesRead == 0)
                {
                    Console.WriteLine("\n---------------------------服务器关闭了数据流！--------------------------\n");
                    streamToServer.Dispose();
                    client.Close();
                    return;
                }

                //获取带有协议头的字符串，可能是多个消息一起
                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);

                //去掉协议头并截取完整的消息形成消息数组
                string[] strArray = handler.GetActualString(msg);

                //遍历数组输出消息
                foreach (string str in strArray)
                {
                    Console.WriteLine("                                                                                                                                  收到消息: {0}", str);
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
                Console.WriteLine("---------------------------------服务器已关闭----------------------------");
            }
        }
    }
}
