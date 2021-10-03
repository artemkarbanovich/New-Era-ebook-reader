using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Ebook_Reader.Model
{
    public static class HasherBytes
    {
        public static byte[] HashBytes(byte[] hashPassword)
        {
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(hashPassword);

            return byteHash;
        }
    }
}
