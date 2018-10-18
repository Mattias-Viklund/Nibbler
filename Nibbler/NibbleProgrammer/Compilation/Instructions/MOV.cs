using NibblerProgrammer.Compilation.Register;
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

            string message = "MOV ";

            bool regA = false;
            bool regB = false;

            for (int i = 1; i < 3; i++)
            {
                RegisterBase rb = RegisterBase.TryFindRegister(args[1]);
                if (rb != null)
                {
                    message += rb.RegisterName() + " ";

                    if (i == 1)
                        regA = true;
                    else
                        regB = true;

                }
            }

            if (regA == false)
            {

            }


            return message;

        }
    }
}
