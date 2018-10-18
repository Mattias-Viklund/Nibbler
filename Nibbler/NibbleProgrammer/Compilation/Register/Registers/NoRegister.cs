using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Register
{
    class NoRegister : RegisterBase
    {
        public NoRegister()
            : base(false)
        {

        }

        public override byte RegisterAsNibble()
        {
            return 0b0000_1000;

        }

        public override string RegisterName()
        {
            return "DefReg";   

        }
    }
}
