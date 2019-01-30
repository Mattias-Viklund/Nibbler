using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor.Registers
{
    class _32BitRegister : CPURegister
    {
        public _32BitRegister(byte register)
            : base(register, 0x04)
        { }
    }
}
