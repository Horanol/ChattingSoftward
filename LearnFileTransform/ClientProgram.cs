using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LearnFileTransform
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            Client c = new Client();
            string filePath = Environment.CurrentDirectory + "/" + "Client01.jpg";
            if (File.Exists(filePath))
                c.BeginSendFile(filePath);

            Console.WriteLine("\n\n输入Q键退出\n");
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
