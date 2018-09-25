using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler
{
    class Program
    {
        static Memory mem = new Memory();

        static void Main(string[] args)
        {
            for (byte i = 0; i < 16; i++)
            {
                Console.WriteLine((int)mem.GetNibble(i));

            }

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
            int nibb = nibble & 0b00001111;

            if (nibb % 2 == 0)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nibble"></param>
        /// <returns></returns>
        public byte SetNibble(byte nibble)
        {
            byte data = GetNibble((byte)(nibble & 0b11110000));


        }
    }
}
