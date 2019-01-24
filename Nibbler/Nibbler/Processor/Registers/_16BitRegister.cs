using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor.Registers
{
    class _16BitRegister : CPURegister
    {
        public _16BitRegister(byte register)
            : base(register, 0x02)
        { }
    }
}
