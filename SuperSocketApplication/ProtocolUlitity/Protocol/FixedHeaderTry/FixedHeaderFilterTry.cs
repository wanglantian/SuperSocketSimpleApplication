using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.ProtoBase;
using ProtocolUlitity.Package.FixedHeader;

namespace ProtocolUlitityTry.Protocol.FixedHeaderTry
{
    //定义一个解包过滤器，因为服务器和客户端都需要使用(但是因为客户端和服务器的数据结构不相同，在服务端定义自己的)，所以放在类库中
    public class FixedHeaderFilterTry : FixedHeaderReceiveFilter<StringPackageInfo>
    {
        public FixedHeaderFilterTry() : base(FixedHeaderTryConst.HEARSIZE)
        {
        }

        public override StringPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            //throw new NotImplementedException();
            string key = bufferStream.ReadString(FixedHeaderTryConst.KEYSIZE,Encoding.UTF8);
            byte[] buffer = new byte[FixedHeaderTryConst.BODYSIZE_LEN];
            bufferStream.Read(buffer,0, FixedHeaderTryConst.BODYSIZE_LEN);
            int bodySize = PackageBodyOperator.GetBodyLen(buffer);
            string body = bufferStream.ReadString(bodySize,Encoding.UTF8);

            return new StringPackageInfo(key,body,null);
        }

        protected override int GetBodyLengthFromHeader(IBufferStream bufferStream, int length)
        {
            bufferStream.Skip(FixedHeaderTryConst.KEYSIZE);
            byte[] bodySizeBuf = new byte[FixedHeaderTryConst.BODYSIZE_LEN];
            //注意 Read方法的第二个参数，目标数组的偏移
            bufferStream.Read(bodySizeBuf,0, FixedHeaderTryConst.BODYSIZE_LEN);

            return PackageBodyOperator.GetBodyLen(bodySizeBuf);
            //throw new NotImplementedException();
        }
    }
}
