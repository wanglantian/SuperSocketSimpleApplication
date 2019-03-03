using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
namespace SuperSocketServer
{
    //会话
    public class AppSessionTry:AppSession<AppSessionTry,StringRequestInfo>
    {
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
            Console.WriteLine("one client online!");
        }

        protected override void HandleException(Exception e)
        {
            base.HandleException(e);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
            Console.WriteLine("one client offline!");
        }
    }
}
