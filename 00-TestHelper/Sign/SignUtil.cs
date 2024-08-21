using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sign
{
    public class SignUtil
    {
        /// <summary>    
        /// RSA私钥格式转换，java->.net    
        /// </summary>    
        /// <param name="privateKey">java生成的RSA私钥</param>    
        /// <returns></returns>   
        public static string RSAPrivateKeyJava2DotNet(string privateKey)
        {
            var privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));
            return
                string.Format(
                    "<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                    Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
                    Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
        }
    }
}
