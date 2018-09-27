using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Instructions
{
    abstract class InstructionBase
    {
        public static List<InstructionBase> instructions = new List<InstructionBase>();

        public static void InitializeList()
        {
            instructions.Add(new NOP());

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in assemblies)
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (t.IsSubclassOf(typeof(InstructionBase)))
                        Activator.CreateInstance(t);

                }

            }
        }

        public static InstructionBase TryFindCommand(string key)
        {
            foreach (InstructionBase b in instructions)
            {
                if (b.GetKey() == key)
                    return b;

            }

            return null;

        }

        public InstructionBase(bool macro=true)
        {
            if (macro)
                instructions.Add(this);

        }

        public abstract string GetName();
        public abstract string GetKey();
        public abstract int ExpectedArguments();
        public abstract string Parse(string[] args);

    }
}
