using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MutipleClientsDemoListener
{
    /// <summary>
    /// 这个类负责字符串的处理，使之符合自定义的协议
    /// </summary>
    class RequestHandler
    {
        private string temp = string.Empty;
        public string[] GetActualString(string msg)
        {
            return GetActualString(msg, null);
        }
        private string[] GetActualString(string msg, List<string> outputList)
        {
            if (outputList == null)
                outputList = new List<string>();
            //若缓存里面有上一次的字符串，则和这一次的字符串合并
            if (!String.IsNullOrEmpty(temp))
                msg = temp + msg;

            string output = "";
            string pattern = @"(?<=^\[length=)(\d+)(?=\])";
            int length;

            if (Regex.IsMatch(msg, pattern))//若合并后的字符串出现了[] 号
            {
                //获取匹配的结果
                Match m = Regex.Match(msg, pattern);
                //获取消息字符串实际应有长度
                length = Convert.ToInt32(m.Groups[0].Value);
                //获取需要截断的位置
                int startIndex = msg.IndexOf(']') + 1;
                //从】号一直截取到最后
                output = msg.Substring(startIndex);

                if (output.Length == length)
                {
                     //若output的长度刚好是消息字符串的长度，则说明刚好是完整的信息
                    outputList.Add(output);
                    temp = "";//清空缓存
                }
                else if (output.Length < length)
                {
                    //若output长度小于应有长度，则说明信息没有发完整，
                    //应该把整个信息缓存起来，合并到下一条数据处理
                    temp = msg;
                }
                else if (output.Length > length)
                {
                    //如果大于应有的长度，则说明有多余的数据了，
                    //此时截断这一条信息应有的长度，然后把后面的字符串递归回本函数处理
                    output = output.Substring(0, length);
                    outputList.Add(output);
                    temp = "";
                    //把接收到的字符串从上一个完整信息处截取到最后，递归给本函数处理
                    msg = msg.Substring(startIndex + length);
                    GetActualString(msg, outputList);
                }

            }else//否则说明【】号不完整，则缓存这一次的字符串
            {
                temp = msg;
            }
            //返回消息字符串数组
            return outputList.ToArray();
        }
    }
}
