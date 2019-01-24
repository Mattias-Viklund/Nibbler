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

        public static int ByteArrToInt(byte[] location)
        {
            int memoryLocation = location[0];

            for (int i = 1; i < location.Length; i++)
            {
                memoryLocation = memoryLocation << 8;
                memoryLocation = memoryLocation | location[i];

            }

            return memoryLocation;

        }

        public static void SetArrayFromBack(ref byte[] array, byte[] array2)
        {
            int difference = array2.Length - array.Length;

            if (difference == 0)
                array = array2;

        }

        public static void IncrementArray(ref byte[] array, int arraySize)
        {
            bool carry = false;

            byte b = array[arraySize - 1];
            b++;

            array[arraySize - 1] = b;

            if (b == 0x00)
                carry = true;

            if (carry)
            {
                // If carry is true, propagate carry backwards in memory
                int i = arraySize - 2;
                while (carry && i >= 0)
                {
                    b = array[i];
                    b++;

                    // Do we need to carry again?
                    if (b != 0x00)
                        carry = false;

                    // If we also need to carry the last byte in array, reset it all
                    if (i == 0 && carry)
                    {
                        for (int j = 0; j < arraySize; j++)
                        {
                            array[j] = 0;

                        }
                        break;

                    }

                    array[i] = b;
                    i--;

                }
            }

        }
    }
}
