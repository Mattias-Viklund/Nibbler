using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;

namespace Nibbler.Processor
{
    class CPU : Component
    {
        public CPU()
            : base(true, 0x00)
        {

        }

        public void Think(Mainboard mainboard)
        {


        }

        public override void RecieveData(byte data)
        {

        }
    }
}
