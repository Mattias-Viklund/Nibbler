﻿namespace Nibbler
{
    class Memory
    {
        // 12 BIT MEMORY ADDRESSES

        // 0b1011_1110 0b1110_1111

        public byte[] nibbles = {
            // NIBBLE SET 1
            0b1101_1110, // 0_1 DE
            0b1010_1101, // 2_3 AD
            0b1011_1110, // 4_5 BE
            0b1110_1111, // 6_7 EF

            0b1101_1110, // 8_9   DE
            0b1010_1101, // 10_11 AD
            0b1011_1110, // 12_13 BE
            0b1110_1111, // 14_15 EF

            // NIBBLE SET 2
            0b1101_1110, // 0_1 DE
            0b1010_1101, // 2_3 AD
            0b1011_1110, // 4_5 BE
            0b1110_1111, // 6_7 EF

            0b1101_1110, // 8_9   DE
            0b1010_1101, // 10_11 AD
            0b1011_1110, // 12_13 BE
            0b1110_1111, // 14_15 EF

            // NIBBLE SET 3
            0b1101_1110, // 0_1 DE
            0b1010_1101, // 2_3 AD
            0b1011_1110, // 4_5 BE
            0b1110_1111, // 6_7 EF

            0b1101_1110, // 8_9   DE
            0b1010_1101, // 10_11 AD
            0b1011_1110, // 12_13 BE
            0b1110_1111, // 14_15 EF

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
            byte pos = (byte)((nibble & 0b1111_0000) >> 4);
            byte bytePos = (byte)((pos & 0b00001111) >> 1);

            byte data = GetNibblePair(pos);
            byte nibb = (byte)(nibble & 0b00001111);

            if (IsEven(pos))
            {
                data = (byte)(data & 0b00001111);
                data = (byte)(data | (nibb << 4));

            }
            else
            {
                data = (byte)(data & 0b11110000);
                data = (byte)(data | nibb);

            }

            nibbles[bytePos] = data;

        }

        public byte GetNibblePair(byte nibble)
        {
            byte b = (byte)((nibble & 0b00001111) >> 1);
            return nibbles[b];

        }
    }
}