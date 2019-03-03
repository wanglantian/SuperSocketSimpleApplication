using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json.Linq;
using ProtocolUlitityTry.FixedHeader.FixedHeaderTry;

namespace SuperSocketServer.Command
{
    //Login 
    /*
     * request : {"username":"xin","password":"7654321"}
     * response : {"result":"success"/"failure"}
     */
    public class Comm1000 : CommandBase<AppSessionTry, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSessionTry session, StringRequestInfo requestInfo)
        {
            //判断是否可以登录成功，如果登录失败，断开连接
            if (IsLogin(requestInfo.Body))
            {
                session.Send(PackageCreator.CreatePackage("Comm1000","{\"result\":\"success\"}"));
            }
            else
            {
                session.Close( CloseReason.ServerShutdown );
            }

            //throw new NotImplementedException();
        }

        //判断是否登录成功
        private bool IsLogin(string body)
        {
            try
            {
                JObject obj = JObject.Parse(body);
                var name = obj["username"].ToString();
                var password = obj["password"].ToString();

                if (name.Equals("xin", StringComparison.CurrentCultureIgnoreCase)
                    && password.Equals("7654321", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return false;
        }
    }
}
