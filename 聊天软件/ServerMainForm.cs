using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace 聊天软件
{
    public partial class ServerMainForm : Form
    {
        IPAddress serverAddress ;
        TcpListener serverListener;
        int serverPoint;
        public ServerMainForm()
        {
            InitializeComponent();
        }

        private void ServerMainForm_Load(object sender, EventArgs e)
        {
            //初始化端口号和本机地址
            serverPoint = 8500;
            serverAddress = Dns.GetHostAddresses(Dns.GetHostName())//这个函数返回一堆ip地址，包括ipv6，ipv4等待，所以需要筛选
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).First() ;
                                                                //InterNetwork 表示ipv4，InterNetworkv6表示ipv6，First()表示第一个匹配的
            //构建TcpListener
            serverListener = new TcpListener(serverAddress,serverPoint);
            //在UI层显示本机ip地址和监听的端口号

            ipAddressBox.Text = serverAddress.ToString();
            portBox.Text = serverPoint.ToString();
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            //点击开始监听按钮时，开始监听
            serverListener.Start();

            //输出开始监听信息
            serverLogBox.Text = "开始监听....."+System.Environment.NewLine;

            //新建线程处理客户端连接
            Thread newThread = new Thread(new ThreadStart(HandlerClients));

            //默认是前台线程，要设置成后台线程，在主窗口关闭后结束线程
            newThread.IsBackground = true;

            newThread.Start();

            //使其他线程能操作主窗口的控件
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public void HandlerClients()
        {
            //循环获取客户端连接
            while (true)
            {
                TcpClient newClient = serverListener.AcceptTcpClient();
                Server newServer = new Server(newClient);
            }   
         
        }
    }
}
