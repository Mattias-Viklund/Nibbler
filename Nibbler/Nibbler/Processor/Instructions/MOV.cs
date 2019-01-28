using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;
using Nibbler.Processor.Registers;

namespace Nibbler.Processor.Instructions
{
    class MOV : CPUInstruction
    {
        public MOV()
            : base(0x01)
        { }


        // -= Move =-
        // MOV DST VALUE
        // Gets next memory address for DST
        // Moves value in next memory address to DST
        public override void Execute(Mainboard mainboard)
        {
            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            CPURegister dst = mainboard.GetCPU().GetRegister(mainboard.GetCPU().GetInstruction());

            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            byte src = mainboard.GetCPU().GetInstruction();

            mainboard.GetCPU().SetRegister(dst.GetRegisterID(), src);

        }
    }
}
