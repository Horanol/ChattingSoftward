using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
namespace 聊天软件
{
    public class Server
    {
        private TcpClient client;
        private NetworkStream streamToClient;
        private const int BufferSize = 8192;
        private byte[] buffer;
        private string msg;
        public EndPoint remoteEndPoint;
        public IPAddress remoteIPAddress;
        public static TextBox serverLogTextBox;
        public string clientName = "";


        public Server(TcpClient client)
        {
            this.client = client;
            //把连接到的客户端信息保存下来
            remoteEndPoint = client.Client.RemoteEndPoint;

            //设置ipAddress
            IPEndPoint myIPEndPoint = (IPEndPoint)remoteEndPoint;
            remoteIPAddress = myIPEndPoint.Address;

            //获取当前主窗口的TextBox组件
            serverLogTextBox = Application.OpenForms["ServerMainForm"].Controls.Find("serverLogBox", true)[0] as TextBox;
            serverLogTextBox.Text += "--已连接到客户端:    [" + remoteEndPoint.ToString() + "]" + System.Environment.NewLine;
            //最后一个是换行字符串，根据操作系统不同而改变，windows下可用"\r\n"换行

            //获取和客户端的数据流
            streamToClient = client.GetStream();
            buffer = new byte[BufferSize];

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
                //if (bytesRead == 0)
                //{
                //    serverLogTextBox.Text += "错误一" + "\n";
                //    ServersController.SignOut(clientName);
                //}
                msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);

                //每次读取完清理缓存，避免脏读
                Array.Clear(buffer, 0, buffer.Length);

                //获取带有协议头的完整消息数组
                ProtocolSpliter spliter = new ProtocolSpliter();
                string[] msgArray = spliter.GetCompleteProtocols(msg);

                //获取消息或文件强类型
                foreach (string str in msgArray)
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

                //再次调用BeginRead()，形成无限循环
                AsyncCallback newCallBack = new AsyncCallback(ReadComplete);
                streamToClient.BeginRead(buffer, 0, BufferSize, newCallBack, null);
            }
            catch
            {
                //若抛出异常
                //若数据流还存在，则释放数据流
                if (streamToClient != null)
                    streamToClient.Dispose();
                //关闭客户端连接并输出异常信息
                client.Close();

                //在ServerController中注销登记
                ServersController.SignOut(clientName);

                serverLogTextBox.Text += "客户端" + clientName + "已断开连接" + System.Environment.NewLine;
                
            }

        }

        //从ServersController收到的消息，然后转发给自己连接的客户端，这个消息里面含有协议头
        public bool SendMessage(string pro)
        {
            byte[] temp = Encoding.Unicode.GetBytes(pro);
            try
            {
                streamToClient.Write(temp, 0, temp.Length);
            }
            catch
            {
                serverLogTextBox.Text += "无法发送消息!" + Environment.NewLine;
                return false;
            }
            return true;
        }
    }
}
