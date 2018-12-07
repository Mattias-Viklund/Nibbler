using Nibbler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Core
{
    /// <summary>
    /// Half a byte (4 bit nibble).
    /// Max value: 15, 0xF
    /// Usage: CPU
    /// </summary>
    class Nibble
    {
        public static byte AddNibble(byte left, byte right)
        {
            byte tempA = (byte)(left & 0xF);
            byte tempB = (byte)(right & 0xF);

            byte result = (byte)(tempA + tempB);

            if (result > 0xF)
                return 0xF;

            return result;

        }

        public static byte SubNibble(byte left, byte right)
        {
            byte tempA = (byte)(left & 0xF);
            byte tempB = (byte)(right & 0xF);

            byte result = (byte)(tempA + tempB);

            if (result > 0xF)
                return 0xF;

            return result;

        }

        public static byte ToNibble(byte data, bool first)
        {
            if (first)
            {
                return (byte)(data >> 4);

            }
            else
            {
                return (byte)(data & 0xF);

            }
        }
    }
}
