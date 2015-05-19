using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace 聊天软件
{
    public class FileHandler:IHandlerProtocol
    {
        private const int BufferSize = 8192;
        private byte[] buffer;
        private Server myServer;
        public FileHandler(Server _myServer)
        {
            buffer = new byte[BufferSize];
            myServer = _myServer;
        }
        public void HandlerProtocol(Protocol _pro)
        {
            FileProtocol pro = (FileProtocol)_pro;
            if (pro.sourceName == myServer.clientName)
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
        /// <summary>
        /// 服务器接收来自客户端的文件
        /// </summary>
        /// <param name="pro"></param>
        private void ReceiveFile(FileProtocol pro)
        {
            IPEndPoint clientIPEndPoint = myServer . remoteEndPoint as IPEndPoint;
            IPEndPoint newFileEndPoint = new IPEndPoint(clientIPEndPoint.Address, pro.port);
            TcpClient newFileClient;
            //尝试连接客户端的文件传输端口
            try
            {
                newFileClient = new TcpClient();
                newFileClient.Connect(newFileEndPoint);
            }
            catch
            {
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
                do
                {
                    bytesRead = fileStream.Read(buffer, 0, BufferSize);
                    fs.Write(buffer, 0, bytesRead);
                } while (bytesRead > 0);
            }
            catch
            {
            }
            finally
            {
                fileStream.Dispose();
                fs.Dispose();
                newFileClient.Close();
            }
        }
        /// <summary>
        /// 服务器发送文件给客户端
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool SendFile(string filePath)
        {
            //发送协议到客户端
            string fileName = Path.GetFileName(filePath);
            FileProtocol pro = new FileProtocol(FileProtocol.FileRequestMode.Send, 8601, "server", myServer.clientName, fileName);
            myServer.SendMessage(pro.ToString());

            //在服务器监听8601端口，用于传送文件
            TcpListener fileListener = new TcpListener(myServer.remoteIPAddress, 8601);
            fileListener.Start();
            //中断，等待远程连接
            TcpClient localClient = fileListener.AcceptTcpClient();

            NetworkStream fileStream = localClient.GetStream();
            //创建文件流
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] fileBuffer = new byte[1024];
            int bytesRead;
            //将文件流写入网络流
            try
            {
                do
                {
                    bytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length);
                    fileStream.Write(fileBuffer, 0, bytesRead);
                } while (bytesRead > 0);
            }
            catch
            {
                return false;
            }
            finally
            {
                //把文件流，网络流，监听端和客户端都回收
                fileStream.Dispose();
                fs.Dispose();
                localClient.Close();
                fileListener.Stop();
            }
            return true;
        }
    }
}
