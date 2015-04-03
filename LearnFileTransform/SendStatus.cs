using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LearnFileTransform 
{
    /// <summary>
    /// 用来记录和打印发送完成的状态
    /// </summary>
    class SendStatus
    {
        //info是文件帮助类的实例，用来处理文件
        private FileInfo info;
        private long fileBytes;//64位有符号整数
        private string filePath;
        public SendStatus(string filePath)
        {
            info = new FileInfo(filePath);
            fileBytes = info.Length;//获取当前文件大小
        }

        //输出文件即时发送状态
        public void PrintStatus(int sent)
        {
            string percent = GetPercent(sent);
            Console.WriteLine("Sending  {0} bytes,  {1}% ...", sent, percent);
        }

        private string GetPercent(int sent)
        {
            //把二进制64位的长度转换成十进制的数字
            decimal allBytes = Convert.ToDecimal(fileBytes);
            decimal currentSent = Convert.ToDecimal(sent);

            decimal percent = (currentSent / allBytes) * 100;
            percent = Math.Round(percent, 1);//保留一位小数

            if (percent.ToString() == "100.0")
                return "100";
            else
                return percent.ToString();
        }
    }
}
