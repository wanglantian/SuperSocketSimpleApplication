﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerTry server = new ServerTry();

            server.Start();

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            server.Stop();
        }
    }
}
