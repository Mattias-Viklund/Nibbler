using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Register
{
    class E : RegisterBase
    {
        public override byte RegisterAsNibble()
        {
            return 0b00001010;

        }

        public override string RegisterName()
        {
            return "E";
        }
    }
}
