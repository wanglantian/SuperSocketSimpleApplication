using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientTry client = new ClientTry();
            client.Connect("127.0.0.1",2012);

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }
        }
    }
}
