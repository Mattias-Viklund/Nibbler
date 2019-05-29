using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;
using Nibbler.Processor.Registers;
using Nibbler.Util;

namespace Nibbler.Processor.Instructions
{
    public class ADD : CPUInstruction
    {
        public ADD() 
            : base(0x02)
        { }

        // -= Addition =-
        // ADD DST SRC
        // Gets next memory address for DST
        // Gets next memory address for SRC
        // Adds SRC to DST
        public override void Execute(Mainboard mainboard)
        {
            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            CPURegister dst = mainboard.GetCPU().GetRegister(mainboard.GetCPU().GetInstruction());

            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            byte src = mainboard.GetCPU().GetInstruction();

            byte[] dstValue = dst.GetValue();

            Maths.AddArray(ref dstValue, dstValue.Length, src);

            mainboard.GetCPU().SetRegister(dst.GetRegisterID(), dstValue);

        }
    }

    public class ADDR : CPUInstruction
    {
        public ADDR()
            : base(0x02)
        { }

        // -= Addition =-
        // ADD DST SRC
        // Gets next memory address for DST
        // Gets next memory address for SRC
        // Adds SRC to DST
        public override void Execute(Mainboard mainboard)
        {
            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            CPURegister dst = mainboard.GetCPU().GetRegister(mainboard.GetCPU().GetInstruction());

            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            CPURegister src = mainboard.GetCPU().GetRegister(mainboard.GetCPU().GetInstruction());

            byte[] dstValue = dst.GetValue();

            Maths.AddArray(ref dstValue, dstValue.Length, src.GetValue()[0]);

            mainboard.GetCPU().SetRegister(dst.GetRegisterID(), dstValue);

        }
    }
}
