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

        static char ToHex(byte nibble)
        {
            string s = Convert.ToInt32(nibble).ToString("X");
            return s[0];

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Dumping memory");
            Console.WriteLine("0x000 - 0xFFF\n");

            for (byte o = 0; o < 3; o++)
            {
                for (byte b = 0; b <= Nibble.MaxValue; b++)
                {
                    Console.Write(ToHex(mem.GetNibble(b)));

                }
                Console.Write("\n");

            }
            Console.Write("\n");


            mem.SetNibble(0b0111_0010);
            mem.SetNibble(0b1000_0101);

            Console.WriteLine(mem.GetNibble(0b0000_0111));
            Console.WriteLine(mem.GetNibble(0b0000_1000));

            Console.ReadLine();

        }
    }
}