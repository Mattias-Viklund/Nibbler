using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Register
{
    abstract class RegisterBase
    {
        public abstract string RegisterName();
        public abstract byte RegisterAsNibble();
    }
}
