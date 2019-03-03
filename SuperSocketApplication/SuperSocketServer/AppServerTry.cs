using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocketServer.RecvFilter;
namespace SuperSocketServer
{
    class AppServerTry:AppServer<AppSessionTry, StringRequestInfo>
    {
        public AppServerTry()
            :base(new DefaultReceiveFilterFactory<FixedHeaderFilterTry, StringRequestInfo>())
        {

        }
    }
}
