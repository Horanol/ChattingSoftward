using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleClientsDemoClient;
namespace MultipleClientsDemoClient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~欢迎使用旺旺聊天软件~~~~~~~~~~~~~~~~~~~~~~");
            Client client = new Client();
            while (true)
            {
                string input = Console.ReadLine();
                client.SendMessage(input);

            }
        }
    }
}
