using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Register
{
    /// <summary>
    /// BASE POINTER REGISTER
    /// </summary
    class BP : RegisterBase
    {
        public override byte RegisterAsNibble()
        {
            return 0b0000_1101;

        }

        public override string RegisterName()
        {
            return "BP";

        }
    }
}
