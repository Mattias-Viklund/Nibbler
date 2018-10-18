using NibblerProgrammer.Compilation.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Instructions
{
    class SUB : InstructionBase
    {
        private int arguments = 3;

        public override int ExpectedArguments()
        {
            return arguments;

        }

        public override string GetKey()
        {
            return "SUB";

        }

        public override byte GetOpCode()
        {
            return 0b0000_1001;

        }

        public override string Parse(string[] args)
        {
            if (args.Length != arguments)
                return null;

            string message = "SUB ";

            bool regA = false;
            bool regB = false;

            for (int i = 1; i < 3; i++)
            {
                RegisterBase rb = RegisterBase.TryFindRegister(args[i]);
                if (rb != null)
                {
                    message += rb.RegisterName() + " ";

                    if (i == 1)
                        regA = true;
                    else
                        regB = true;

                }
            }

            if (!regA && !regB)
            {
                int a = 0;
                int b = 0;
                try
                {
                    a = Convert.ToInt32(args[1]);
                    b = Convert.ToInt32(args[2]);

                }
                catch
                {
                    return "Error in input";

                }

                return "Can not sub number with number";

            }
            else
            {
                if (regA == false)
                {
                    int b = 0;
                    try
                    {
                        b = Convert.ToInt32(args[1]);

                    }
                    catch
                    {
                        return "Arg 1 incorrect";

                    }

                    if (!regB)
                        message += b + " ";
                    else
                        return "Can't sub number from register";
                }

                if (regB == false)
                {
                    int i = 0;
                    try
                    {
                        i = Convert.ToInt32(args[2]);

                    }
                    catch
                    {
                        return "Arg 2 incorrect";

                    }

                    message += i + "";

                }
            }


            return message;

        }
    }
}
