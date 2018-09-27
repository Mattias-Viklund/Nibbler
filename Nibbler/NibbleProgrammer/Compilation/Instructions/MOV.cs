using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Instructions
{
    class MOV : InstructionBase
    {
        private int arguments = 3;

        public override int ExpectedArguments()
        {
            return arguments;

        }

        public override string GetKey()
        {
            return "MOV";
        }

        public override string GetName()
        {
            return "MOV";
        }

        public override string Parse(string[] args)
        {
            if (args.Length != arguments)
                return null;

            return "MOV REG REG";

        }
    }
}
