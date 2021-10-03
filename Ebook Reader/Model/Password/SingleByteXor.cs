using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebook_Reader.Model.Password
{
    sealed class SingleByteXor : Hasher
    {
        private readonly byte[] data = new byte[1];

        public void Reinitialize() => data[0] = 0;
        public void AddByte(byte b) => data[0] ^= b;
        public byte[] Result { get => data; }
    }
}
