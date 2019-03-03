using ProtocolUlitityTry.Protocol.FixedHeaderTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.Facility.Protocol;
using ProtocolUlitity.Package.FixedHeader;

namespace SuperSocketServer.RecvFilter
{
    public class FixedHeaderFilterTry:FixedHeaderReceiveFilter<StringRequestInfo>
    {
        public FixedHeaderFilterTry() : base(FixedHeaderTryConst.HEARSIZE)
        {
        }

        //offset = 0
        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            return PackageBodyOperator.GetBodyLen(header,offset + FixedHeaderTryConst.KEYSIZE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header">头部的数组段</param>
        /// <param name="bodyBuffer">整个缓冲buffer</param>
        /// <param name="offset">内容在bodyBuffer中的偏移量</param>
        /// <param name="length">内容长度</param>
        /// <returns></returns>
        protected override StringRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            string key = Encoding.UTF8.GetString(header.Array, header.Offset, FixedHeaderTryConst.KEYSIZE);

            string body = Encoding.UTF8.GetString(bodyBuffer, offset,length);

            return new StringRequestInfo(key, body, null);
        }
    }
}
