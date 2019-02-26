using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Nibbler.Util;
using Nibbler.Motherboard;
using Nibbler.Processor;

namespace Nibbler
{
    class Program
    {
        static Mainboard mainboard = new Mainboard(new CPU(0x02));
        static bool running = true;

        static void Main(string[] args)
        {
            mainboard.GetRAM().FillData();

            while (running)
            {
                mainboard.Cycle();

            }


        }
    }
}