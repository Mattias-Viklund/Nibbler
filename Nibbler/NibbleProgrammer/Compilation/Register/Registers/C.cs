using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Register.Registers
{
    class C : RegisterBase
    {
        public override byte RegisterAsNibble()
        {
            return 0b0000_1011;
        }

        public override string RegisterName()
        {
            return "C";

        }
    }
}
