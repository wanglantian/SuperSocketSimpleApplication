using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolUlitityTry
{
    //定义一些常量值，方便修改
    public class ConstValues
    {
        //因为长度是3个字节，所以经常需要计算 256 * 256，那么给他定义个常量
        public const int _16MaxValue = 256 * 256;  //可以直接除以 65536 ，但避免后面修改

        //那么也定义一个字节的最大值吧
        public const int _8MaxValue = 256;
    }
}
