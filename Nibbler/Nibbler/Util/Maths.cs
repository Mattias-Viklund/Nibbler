using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Util
{
    static class Maths
    {
        public static byte Pow(byte data, byte exponent)
        {
            if (exponent == 0)
                return 1;

            byte result = data;

            for (int i = 0; i < exponent - 1; i++)
            {
                result *= data;

            }

            if (result > 0xF)
                return 0xF;

            return result;

        }

    }
}
