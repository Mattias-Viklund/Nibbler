using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;

namespace Nibbler.Processor.Instructions
{
    class ADD : CPUInstruction
    {
        public ADD() 
            : base(0x01)
        { }

        public override void Execute(Mainboard mainboard)
        {
            mainboard.GetCPU().IncrementPC();
            byte dst = mainboard.GetCPU().GetInstruction();

            mainboard.GetCPU().IncrementPC();
            byte src = mainboard.GetCPU().GetInstruction();

            byte result = (byte)(dst + src);

            mainboard.GetCPU().SetRegister(dst, result);

        }
    }
}
