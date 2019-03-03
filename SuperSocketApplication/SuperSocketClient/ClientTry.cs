using ProtocolUlitityTry.Protocol.FixedHeaderTry;
using SuperSocket.ClientEngine;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ProtocolUlitityTry.FixedHeader.FixedHeaderTry;

namespace SuperSocketClient
{
    class ClientTry
    {
        EasyClient client;

        public ClientTry()
        {
            client = new EasyClient();

            client.Initialize(new FixedHeaderFilterTry(), ProcessPackage);
        }

        public async void Connect(string ip,int port)
        {
            var connected = await client.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip),port));

            if (!connected)
            {
                Console.WriteLine("连接失败");
                return;
            }
            Login();
        }

        public void Login()
        {
            client.Send(PackageCreator.CreatePackage("Comm1000",
                "{\"username\":\"xin\",\"password\":\"7654321\"}"));
        }

        public void ProcessPackage(StringPackageInfo package)
        {
            switch (package.Key)
            {
                case "Comm1000":
                    CommandProcesser.Comm1000Process(package.Body);
                    break;
            }
        }
    }
}
