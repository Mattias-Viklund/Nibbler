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

            for (byte b = 0; b < Nibble.MaxValue / 2; b++)
            {
                Console.WriteLine(b+": "+(int)mem.GetNibblePair(b));

            }


            mem.SetNibble(0b0111_1111);

            Console.ReadLine();

        }
    }

    class Memory
    {
        private byte[] nibbles = {
            0b0000_0001, // 0_1
            0b0010_0011, // 2_3
            0b0100_0101, // 4_5
            0b0110_0111, // 6_7

            0b1000_1001, // 8_9
            0b1000_1011, // 10_11
            0b1100_1101, // 12_13
            0b1110_1111  // 14_15

        };

        public byte GetNibble(byte nibble, bool withPosition = false)
        {
            byte nibb = (byte)(nibble & 0b00001111);

            if (IsEven(nibb))
            {
                if (withPosition)
                    return (byte)((nibbles[nibb / 2] >> 4) | (nibb << 4));
                else
                    return (byte)(nibbles[nibb / 2] >> 4);
            }
            else
            {
                if (withPosition)
                    return (byte)((nibbles[nibb / 2] & 0b00001111) | (nibb << 4));
                else
                    return (byte)(nibbles[nibb / 2] & 0b00001111);

            }
        }

        private bool IsEven(byte b)
        {
            if ((b & 0b0000_0001) == 0b0000_0001)
                return false;

            return true;

        }

        /// <summary>
        /// 0b POSITION DATA (0000 0000)
        /// </summary>
        /// <param name="nibble"></param>
        /// <returns></returns>
        public void SetNibble(byte nibble)
        {
            byte pos = (byte)(nibble & 0b0111_0000);
            bool second = false;

            if (((byte)(nibble & 0b1000_0000) == 0b1000_0000))
                second = true;

            byte data = GetNibble((byte)(pos >> 4));


            byte nibb = (byte)(nibble & 0b00001111);

            if (nibb % 2 == 0)
                nibbles[nibb / 2] = data;
            else
                nibbles[nibb / 2] = data;

        }

        public byte GetNibblePair(byte nibble)
        {
            byte nibb = (byte)(nibble & 0b00001111);
            byte nibb3 = (byte)(nibb / 2);

            if (!IsEven(nibb))
                nibb3 = (byte)((nibb / 2) + 1);
            return nibbles[nibb3];

        }
    }
}