/* =======================================================================
* create by kikao
* 2016/6/3 23:48:58
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mspend.Framework.Helper
{
    public class Md5
    {
        public static string Encrypt32(string source)
        {
            var bufs = Encoding.Unicode.GetBytes(source);
            var md5 = new MD5CryptoServiceProvider();
            var enBufs = md5.ComputeHash(bufs);
            return BitConverter.ToString(enBufs).Replace("-", "");
        }
        public static string Encrypt16(string source)
        {
            var bufs = Encoding.Unicode.GetBytes(source);
            var md5 = new MD5CryptoServiceProvider();
            var enBufs = md5.ComputeHash(bufs);
            return BitConverter.ToString(enBufs,4,8).Replace("-", "");
        }
    }
}
