using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolUlitityTry.Protocol.FixedHeaderTry
{
    /// <summary>
    /// FixedHeader协议的一些常量定义
    /// </summary>
    public class FixedHeaderTryConst
    {
        //定义命令如下：Comm{num}  num占4为，1000~9999，
        //如何实现不限制KEYSIZE？
        public const int KEYSIZE = 8;

        //MAX Body size is 256*256*256 + 256*256 + 256 - 1 = 16777216 ≈ 16M
        public const int BODYSIZE_LEN = 3;

        //内容长度的最大值
        public const int BODYSIZE_MAX = 16777215;

        public const int HEARSIZE = KEYSIZE + BODYSIZE_LEN;
    }
}
