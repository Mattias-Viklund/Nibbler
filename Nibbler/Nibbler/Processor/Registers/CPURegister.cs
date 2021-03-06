﻿using Nibbler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor.Registers
{
    public abstract class CPURegister
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

        public byte[] GetValue()
        {
            return value;

        }

        public int GetIntValue()
        {
            return Maths.ByteArrToInt(value);

        }

        public byte GetByteValue()
        {
            return value[value.Length - 1];

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
