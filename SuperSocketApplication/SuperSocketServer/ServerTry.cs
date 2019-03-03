using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    //封装对SuperSocket server 的使用
    public class ServerTry
    {
        AppServerTry server;
        public ServerTry()
        {
            server = new AppServerTry();

            var serverConfig = new ServerConfig
            {
                Port = 2012 //set the listening port
            };

            if (!server.Setup(serverConfig))
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }
        }

        public void Start()
        {
            if (!server.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("The server started successfully, press key 'q' to stop it!");
        }

        public void Stop()
        {
            server.Stop();
        }
    }
}
