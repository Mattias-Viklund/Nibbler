using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;

namespace Nibbler.Processor.Instructions
{
    class NOP : CPUInstruction
    {
        public NOP() 
            : base(0x00)
        {


        }

        public override void Execute(Mainboard mainboard)
        {
            Console.WriteLine("Nop");

        }
    }
}
