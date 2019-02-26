using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Util
{
    public static class Maths
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
            int offset = array2.Length - array.Length;

            // if the array2 length is 0
            //if (offset == -array2.Length)
            //    return;

            if (offset == 0)
                array = array2;

            if (offset > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array2[offset + i - 1];

                }
            }

            if (offset < 0)
            {
                offset = Math.Abs(offset);

                for (int i = 0; i < array.Length; i++)
                {
                    if (i >= offset)
                    {
                        array[i] = array2[i - offset];
                    }
                    else
                    {
                        array[i] = 0;

                    }
                }
            }
        }

        public static byte[] IntToByteArray(int value, byte bytes)
        {
            byte[] array = new byte[bytes];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = (byte)value;
                value = value >> 8;

            }

            return array;

        }

        public static void AddArray(ref byte[] array, int arraySize, byte add)
        {
            bool carry = false;

            byte b = array[arraySize - 1];
            b += add;

            array[arraySize - 1] = b;

            if (b < add)
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
                    if (b == 0x00)
                        carry = true;
                    else
                        carry = false;

                    // If we also need to carry the last byte in array, reset it all
                    if (i == 0 && carry)
                    {
                        for (int j = 0; j < arraySize-1; j++)
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
