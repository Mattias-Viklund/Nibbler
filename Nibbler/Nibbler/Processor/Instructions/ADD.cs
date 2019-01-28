using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;
using Nibbler.Processor.Registers;

namespace Nibbler.Processor.Instructions
{
    class ADD : CPUInstruction
    {
        public ADD() 
            : base(0x02)
        { }

        public override void Execute(Mainboard mainboard)
        {
            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            CPURegister dst = mainboard.GetCPU().GetRegister(mainboard.GetCPU().GetInstruction());

            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            byte src = mainboard.GetCPU().GetInstruction();

            byte result = (byte)(dst.GetByteValue() + src);

            mainboard.GetCPU().SetRegister(dst.GetRegisterID(), result);

        }
    }
}
