using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace SuperSocketClient
{
    public class CommandProcesser
    {
        public static void Comm1000Process(string body)
        {
            if (JObject.Parse(body)["result"].ToString().Equals("success",StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("登录成功！");
            }
        }
    }
}
