using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
namespace MutipleClientsDemoListener
{
    public class Server
    {
        private TcpClient client;
        private NetworkStream streamToClient;
        private const int BufferSize = 8192;
        private byte[] buffer;
        private RequestHandler handler;
        public string msg;
        public EndPoint RemoteEndPoint;

        public Server(TcpClient client)
        {
            this.client = client;
            //把连接到的客户端信息保存下来
            RemoteEndPoint = client.Client.RemoteEndPoint;

            Console.WriteLine("--已连接到客户端！    本机:{0}     客户端:{1}--", 
                client.Client.LocalEndPoint, RemoteEndPoint);

            //获取和客户端的数据流
            streamToClient = client.GetStream();
            buffer = new byte[BufferSize];

            //设置RequestHandler
            handler = new RequestHandler();

            //在主程序中的servers列表中添加当前server
            ListenerProgram.servers.Add(this);

            //在构造函数中开始准备从客户端中读取数据
            AsyncCallback callBack = new AsyncCallback(ReadComplete);
            streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
        }
        private void ReadComplete(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                bytesRead = streamToClient.EndRead(ar);
                if (bytesRead == 0)
                {
                    Console.WriteLine("----------------------------------客户端已离线！--------------------------------------");
                    return;
                }
                msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);

                //每次读取完清理缓存，避免脏读
                Array.Clear(buffer, 0, buffer.Length);

                //去掉协议头并截取完整的消息形成消息数组
                string[] msgArray = handler.GetActualString(msg);

                //遍历数组输出消息
                foreach (string m in msgArray)
                {
                    Console.WriteLine("收到信息: {0}    来自{1}", m,RemoteEndPoint);
                    ListenerProgram.BroadcastMessage(msg,this);
                    Console.WriteLine("广播信息: {0}", m);
                    
                }

                //再次调用BeginRead()，形成无限循环
                AsyncCallback newCallBack = new AsyncCallback(ReadComplete);
                streamToClient.BeginRead(buffer, 0, BufferSize, newCallBack, null);
            }catch {//若抛出异常
                //若数据流还存在，则释放数据流
                if (streamToClient != null)
                    streamToClient.Dispose();
                //关闭客户端连接并输出异常信息
                client.Close();
                //从server列表里面去除该server
                ListenerProgram.servers.Remove(this);

                Console.WriteLine("--------------------客户端{0}断开连接--------------------",RemoteEndPoint);
            }

        }
        //从主程序里获取别的服务器线程收到的消息，然后转发给自己连接的客户端
        public void SendMessage(string msg)
        {
            try
            {
                byte[] temp = Encoding.Unicode.GetBytes(msg);
                streamToClient. Write(temp, 0, temp.Length);
            }
            catch
            {
                Console.WriteLine("\n---------------------------无法发送消息！-----------------------------\n");
            }
        }
        public string ReturnMessage()
        {
            return msg;
        }
    }
}
