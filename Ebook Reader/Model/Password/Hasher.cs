using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebook_Reader.Model.Password
{
    public interface Hasher
    {
        void Reinitialize();
        void AddByte(byte b);
        byte[] Result { get; }
    }
}
