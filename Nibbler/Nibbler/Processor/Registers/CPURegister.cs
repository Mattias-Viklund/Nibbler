using Nibbler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor.Registers
{
    abstract class CPURegister
    {
        private byte register;
        private byte[] value;

        public CPURegister(byte register, int size)
        {
            this.register = register;
            this.value = new byte[size];

        }

        public byte GetRegisterID()
        {
            return register;

        }

        public void SetValue(byte value)
        {
            this.value[this.value.Length - 1] = value;

        }

        public void SetValue(byte[] value)
        {
            Maths.SetArrayFromBack(ref this.value, value);

        }
    }
}
