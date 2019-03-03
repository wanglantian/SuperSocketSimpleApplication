using ProtocolUlitity.Package.FixedHeader;
using ProtocolUlitityTry.Protocol.FixedHeaderTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolUlitityTry.FixedHeader.FixedHeaderTry
{
    public class PackageCreator
    {
        public static ArraySegment<byte> CreatePackage(string key, string body)
        {
            byte[] buffer = new byte[FixedHeaderTryConst.HEARSIZE + body.Length];

            Buffer.BlockCopy(Encoding.UTF8.GetBytes(key), 0, buffer, 0, key.Length);
            /*
            buffer[FixedHeaderTryConst.KEYSIZE] = (byte)(body.Length / ConstValues._16MaxValue);
            buffer[FixedHeaderTryConst.KEYSIZE + 1] = (byte)((body.Length % ConstValues._16MaxValue) / ConstValues._8MaxValue);
            buffer[FixedHeaderTryConst.KEYSIZE + 2] = (byte)(body.Length % ConstValues._8MaxValue);
            */
            PackageBodyOperator.FillBodyLen(buffer, FixedHeaderTryConst.KEYSIZE, body.Length);

            Buffer.BlockCopy(Encoding.UTF8.GetBytes(body), 0, buffer, FixedHeaderTryConst.HEARSIZE, body.Length);

            return new ArraySegment<byte>(buffer);
        }
    }
}
