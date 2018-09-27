using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Instructions
{
    class NOP : InstructionBase
    {
        private int arguments = 0;

        public NOP()
            : base(true)
        {

        }

        public override int ExpectedArguments()
        {
            return arguments;

        }

        public override string GetKey()
        {
            return "NOP";
        }

        public override string GetName()
        {
            return "NOP";
        }

        public override string Parse(string[] args)
        {
            return "NOP";

        }
    }
}
