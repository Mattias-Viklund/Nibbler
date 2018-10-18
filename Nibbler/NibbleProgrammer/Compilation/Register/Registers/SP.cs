using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Register
{
    class SP : RegisterBase
    {
        public override byte RegisterAsNibble()
        {
            return 0b0000_1110;
        }

        public override string RegisterName()
        {
            return "SP";
        }
    }
}
