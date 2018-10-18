using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NibblerProgrammer.Compilation.Register
{
    abstract class RegisterBase
    {
        public static List<RegisterBase> registers = new List<RegisterBase>();

        public RegisterBase(bool macro=true)
        {
            if (macro)
                registers.Add(this);

        }
        
        public static void InitializeList()
        {
            registers.Add(new NoRegister());

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in assemblies)
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (t.IsSubclassOf(typeof(RegisterBase)))
                        Activator.CreateInstance(t);

                }

            }
        }

        public static RegisterBase TryFindRegister(string key)
        {
            foreach (RegisterBase r in registers)
            {
                if (r.RegisterName() == key)
                    return r;

            }

            return null;

        }

        public abstract string RegisterName();
        public abstract byte RegisterAsNibble();
    }
}
