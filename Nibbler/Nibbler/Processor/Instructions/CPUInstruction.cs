using Nibbler.Motherboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor.Instructions
{
    abstract class CPUInstruction
    {
        private byte opcode;

        public CPUInstruction(byte opcode)
        {
            this.opcode = opcode;

        }

        public abstract void Execute(Mainboard mainboard);

    }
}
