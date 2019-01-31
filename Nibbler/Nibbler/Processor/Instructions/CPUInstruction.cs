using Nibbler.Motherboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor.Instructions
{
    public abstract class CPUInstruction
    {
        private static CPUInstruction[] CPUInstructions = new CPUInstruction[0x10];

        private byte opcode;

        public CPUInstruction(byte opcode)
        {
            this.opcode = opcode;

            CPUInstructions[opcode] = this;

        }

        public abstract void Execute(Mainboard mainboard);

        public static CPUInstruction GetInstruction(byte opcode)
        {
            CPUInstruction result = CPUInstructions[opcode];

            if (result != null)
                return result;

            return CPUInstructions[0x00]; // Default return NOP

        }
    }
}
