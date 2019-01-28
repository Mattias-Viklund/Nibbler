using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;

namespace Nibbler.Processor.Instructions
{
    class MOV : CPUInstruction
    {
        public MOV()
            : base(0x01)
        { }

        public override void Execute(Mainboard mainboard)
        {


        }
    }
}
