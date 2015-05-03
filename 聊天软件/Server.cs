using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
namespace 聊天软件
{
    public class Server
    {
        private TcpClient client;
        private NetworkStream streamToClient;
        private const int BufferSize = 8192;
        private byte[] buffer;
        public string msg;
        public EndPoint RemoteEndPoint;
        public TextBox serverLogTextBox;
        public string clientName = "";


        public Server(TcpClient client)
        {
            this.client = client;
            //把连接到的客户端信息保存下来
            RemoteEndPoint = client.Client.RemoteEndPoint;

            //获取当前主窗口的TextBox组件
            serverLogTextBox = Application.OpenForms["ServerMainForm"].Controls.Find("serverLogBox", true)[0] as TextBox;
            serverLogTextBox.Text += "--已连接到客户端:" + RemoteEndPoint.ToString() + System.Environment.NewLine;
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
                        if (pro.GetType() == typeof(MessageProtocol))
                        {
                            HandleMessage((MessageProtocol)pro);
                        }
                        else if (pro.GetType() == typeof(FileProtocol))
                        {
                            HandleFileRequest((FileProtocol)pro);
                        }
                        else if (pro.GetType() == typeof(SignInProtocol))
                        {
                            HandleSignInOrUpRequest((SignInProtocol)pro);
                        }
                        else if (pro.GetType() == typeof(UserDetailInfoProtocol))
                        {
                            HandleSaveUserDetailInfoRequest((UserDetailInfoProtocol)pro);
                        }
                    }
                }

                //再次调用BeginRead()，形成无限循环
                AsyncCallback newCallBack = new AsyncCallback(ReadComplete);
                streamToClient.BeginRead(buffer, 0, BufferSize, newCallBack, null);
            }
            catch
            {//若抛出异常
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
        /// <summary>
        /// 处理转发消息
        /// </summary>
        /// <param name="msgArray"></param>
        private void HandleMessage(MessageProtocol pro)
        {

            //服务器端显示日志
            serverLogTextBox.Text += "收到信息: " + pro.content + "  来自 " + pro.sourceName + RemoteEndPoint.ToString() + "   发送给: " + pro.destinationName + Environment.NewLine;
            //委托ServersController转发消息
            ServersController.SendMessage(pro);

        }
        private void HandleFileRequest(FileProtocol pro)
        {
            if (pro.sourceName == clientName)
            {
                if (pro.destinationName == "server")//若是当前客户端发给服务器的文件
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + "\\IconBuffer"))
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + "\\IconBuffer");
                    }
                    //设置保存目录到fileName里
                    pro.fileName = Environment.CurrentDirectory + "\\IconBuffer\\" + pro.fileName;
                    ReceiveFile(pro);
                }
            }
        }
        private void HandleSignInOrUpRequest(SignInProtocol pro)
        {
            //若用户名和密码正确，则在ServerController中登记这个用户名和对应的server，以便可以接受其他人的消息
            //给客户端返回登录成功信息
            if (pro.password == "")
            {
                //当处理SignUp请求时，判断用户名是否可用
                if (UserInfo.CheckUserNameAvailable(pro.userName))
                {
                    MessageProtocol acceptUserNamePro = new MessageProtocol("server", "", "UserNameAccepted");
                    SendMessage(acceptUserNamePro.ToString());
                }
                else
                {
                    MessageProtocol refuseUserNamePro = new MessageProtocol("server", "", "UserNameRefused");
                    SendMessage(refuseUserNamePro.ToString());
                }
            }
            else
            {
                //当处理SignIn请求时，判断用户名和密码是否正确
                if (UserInfo.SignIn(pro.userName, pro.password))
                {
                    clientName = pro.userName;
                    ServersController.SignIn(clientName, this);
                    MessageProtocol acceptPro = new MessageProtocol("server", "", "LoginAccepted");
                    SendMessage(acceptPro.ToString());
                }
                else//登录失败返回失败信息
                {
                    MessageProtocol refusePro = new MessageProtocol("server", "", "LoginRefused");
                    SendMessage(refusePro.ToString());
                }
            }
        }
        private void HandleSaveUserDetailInfoRequest(UserDetailInfoProtocol pro)
        {
            UserDetailInfo info;
            //若没有头像，直接保存
            if (pro.iconPath == "")
                info = new UserDetailInfo(pro.userName, pro.password, pro.sayings, pro.iconPath);
            //若有头像,重新设置头像路径名为服务器端的路径名
            else
            {
                string iconPath = Environment.CurrentDirectory + "\\IconBuffer\\" + Path.GetFileName(pro.iconPath);
                info = new UserDetailInfo(pro.userName, pro.password, pro.sayings, iconPath);
            }
            UserInfo.SignUp(info);
        }
        /// <summary>
        /// 服务器接收来自客户端的文件
        /// </summary>
        /// <param name="pro"></param>
        private void ReceiveFile(FileProtocol pro)
        {
            IPEndPoint clientIPEndPoint = RemoteEndPoint as IPEndPoint;
            IPEndPoint newFileEndPoint = new IPEndPoint(clientIPEndPoint.Address, pro.port);
            TcpClient newFileClient;
            //尝试连接客户端的文件传输端口
            try
            {
                newFileClient = new TcpClient();
                newFileClient.Connect(newFileEndPoint);
            }
            catch {
                return;
            }
            //获取发送文件的流
            NetworkStream fileStream = newFileClient.GetStream();
            //设置文件流

            byte[] fileBuffer = new byte[1024];
            FileStream fs = new FileStream(pro.fileName, FileMode.Create, FileAccess.Write);
            //把网络流读入缓存并写入文件流
            int bytesRead;
            try
            {
                do{
                    bytesRead = fileStream.Read(buffer,0,BufferSize);
                    fs.Write(buffer,0,bytesRead);
                }while(bytesRead>0);
            }catch
            {
            }
            finally
            {
                fileStream.Dispose();
                fs.Dispose();
                newFileClient.Close();
            }
        }
        //从ServersController收到的消息，然后转发给自己连接的客户端，这个消息里面含有协议头
        public void SendMessage(string pro)
        {
            byte[] temp = Encoding.Unicode.GetBytes(pro);
            try
            {
                streamToClient.Write(temp, 0, temp.Length);
            }
            catch
            {
                serverLogTextBox.Text += "无法发送消息!" +Environment.NewLine;
            }
        }
    }
}
