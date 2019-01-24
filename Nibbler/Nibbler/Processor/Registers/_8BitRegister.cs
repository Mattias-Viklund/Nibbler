using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor.Registers
{
    class _8BitRegister : CPURegister
    {
        public _8BitRegister(byte register)
            : base(register, 0x01)
        { }
    }
}
