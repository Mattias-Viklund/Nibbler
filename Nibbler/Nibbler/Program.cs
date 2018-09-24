﻿using System;
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

        public byte GetNibble(byte nibble)
        {
            if (nibble > 15)
                throw new Exception("You've overstepped. No christmas for you.");

            int nibb = nibble & 0b00001111;

            if (nibb == 0)
                return (byte)(nibbles[0] >> 4);
            if (nibb == 1)
                return (byte)(nibbles[0] & 0b00001111);

            if (nibb > 0b00001111)
                return (byte)(nibbles[nibb / 2] >> 4);
            else
                return (byte)(nibbles[nibb / 2] & 0b00001111);

            throw new Exception("Rawr, I goofed it.");

        }
    }
}
