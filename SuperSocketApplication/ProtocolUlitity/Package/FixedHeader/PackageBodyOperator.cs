using ProtocolUlitityTry;
using ProtocolUlitityTry.Protocol.FixedHeaderTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolUlitity.Package.FixedHeader
{
    public class PackageBodyOperator
    {
        public static bool FillBodyLen(byte[] buffer, int offset, int bodyLen)
        {
            if (bodyLen > FixedHeaderTryConst.BODYSIZE_MAX)
            {
                return false;
            }

            //让我们来填充字节
            int leftDiv = bodyLen;
            if (FixedHeaderTryConst.BODYSIZE_LEN > 0)
            {

                for (int i = FixedHeaderTryConst.BODYSIZE_LEN - 1; i >= 0; i--)
                {
                    int remaindNum = leftDiv % ConstValues._8MaxValue;
                    buffer[offset + i] = (byte)(remaindNum);
                    leftDiv /= ConstValues._8MaxValue;
                    if (leftDiv == 0)
                        break;
                }
            }

            return true;
        }

        //从一个数组中获取内容长度
        public static int GetBodyLen(byte[] buffer, int offset = 0)
        {
            int bodyLen = 0;
            if (FixedHeaderTryConst.BODYSIZE_LEN > 0)
            {
                for (int i = 0; i < FixedHeaderTryConst.BODYSIZE_LEN; i++)
                {
                    bodyLen *= ConstValues._8MaxValue;
                    bodyLen += buffer[offset + i];
                }
            }
            return bodyLen;
        }
    }
}
