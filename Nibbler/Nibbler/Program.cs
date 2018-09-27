using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Nibbler
{
    class Program
    {
        static Memory mem = new Memory();
        static bool running = true;

        static void Main(string[] args)
        {
            for (byte b = 0; b < Nibble.MaxValue; b++)
            {
                Console.WriteLine((int)mem.GetNibble(b));

            }

            for (byte b = 0; b <= Nibble.MaxValue; b++)
            {
                Console.WriteLine(b+": "+(int)mem.GetNibblePair(b));

            }


            mem.SetNibble(0b0111_0010);
            mem.SetNibble(0b1000_0101);

            Console.WriteLine(mem.GetNibble(0b0000_0111));
            Console.WriteLine(mem.GetNibble(0b0000_1000));

            Console.ReadLine();

        }
    }
}