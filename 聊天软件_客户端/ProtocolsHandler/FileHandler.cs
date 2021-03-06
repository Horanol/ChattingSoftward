﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace 聊天软件_客户端
{
    public class FileHandler:IHandlerProtocol
    {
        private Client myClient;
        private byte[] buffer;
        private const int BufferSize = 8192;
        public static string saveFilePath = "";
        public FileHandler(Client _client)
        {
            myClient = _client;
            //做好初始化工作
            buffer = new byte[BufferSize];
        }

        public void HandlerProtocol(Protocol _pro)
        {
            FileProtocol pro = (FileProtocol)_pro;
            //若是服务器发送给客户端的文件
            if (pro.sourceName == "server")
            {
                if (pro.destinationName == myClient.clientName)
                {
                    //因为服务器给客户端发送的是头像，所以把头像缓存地址写入pro.fileName，再调用ReceiveFile方法
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\IconBuffer"))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\IconBuffer");
                    }
                    //设置保存目录到fileName里
                    pro.fileName = Directory.GetCurrentDirectory() + "\\IconBuffer\\" + pro.fileName;
                    ReceiveFile(pro);
                }
            }
            //若是用户给用户发送的文件
            else
            {
                pro.fileName = saveFilePath;
                ReceiveFile(pro);
            }
        }
        /// <summary>
        /// 客户端接收文件,
        /// pro.fileName里面保存了文件保存的目录,
        /// pro.sourceName 为要接受的文件源ip地址，或者是"server"表示从服务器接受的文件
        /// </summary>
        /// <param name="pro"></param>
        private void ReceiveFile(FileProtocol pro)
        {
            IPEndPoint newFileEndPoint;
            if (pro.sourceName == "server")
            {
                 newFileEndPoint = new IPEndPoint(myClient.serverIPAddress, pro.port);
            }
            else
            {
                newFileEndPoint = new IPEndPoint(IPAddress.Parse(pro.sourceName), pro.port);
            }
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
        /// 客户端发送文件，
        /// sourceName保存发送方的ip地址，
        /// destinationName 为对方的昵称，
        /// filePath里为要发送的文件的位置
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="destinationName"></param>
        /// <returns></returns>
        public bool SendFile(string sourceName,string destinationName,string filePath)
        {
            //发送协议到服务器
            string fileName = Path.GetFileName(filePath);
            FileProtocol pro = new FileProtocol(FileProtocol.FileRequestMode.Send, 8600, sourceName, destinationName, fileName);
            if (myClient.TryConnectToServer())
                myClient.SendMessage(pro.ToString());

            //在客户端监听8600端口，用于传送文件
            TcpListener fileListener = new TcpListener(myClient.clientIPAddress, 8600);
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
                return true;
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

        }
    }
}
