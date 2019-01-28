using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;
using Nibbler.Util;

namespace Nibbler.Processor
{
    class Memory : Component
    {
        private byte size;

        private int iteration = 0;
        private byte[] location;
        private byte[] data;

        public Memory(byte size)
            : base(true, 0x01)
        {
            this.size = size;
            this.location = new byte[size];
            this.data = new byte[(int)Math.Pow(2, 8 * size)];

        }

        /// <summary>
        /// DEVTEST
        /// </summary>
        public void FillData()
        {
            location = Maths.IntToByteArray(0x00, size);
            SetValue(0x01); // MOV

            location = Maths.IntToByteArray(0x01, size);
            SetValue(0x00); // REG(0x00)

            location = Maths.IntToByteArray(0x02, size);
            SetValue(0x0F); // , 0x0F


            location = Maths.IntToByteArray(0x03, size);
            SetValue(0x02); // ADD

            location = Maths.IntToByteArray(0x04, size);
            SetValue(0x10); // REG(0x10)

            location = Maths.IntToByteArray(0x05, size);
            SetValue(0x0F); // REG(0x00)


            location = Maths.IntToByteArray(0x06, size);
            SetValue(0x0F); // INT

            location = Maths.IntToByteArray(0x07, size);
            SetValue(0x0A); // PRINT

            location = Maths.IntToByteArray(0x08, size);
            SetValue(0x10); // REG(0x00)


            location = Maths.IntToByteArray(0x06, size);
            SetValue(0x0F); // INT

            location = Maths.IntToByteArray(0x07, size);
            SetValue(0xFF); // HALT


            location = Maths.IntToByteArray(0xFE, size);
            SetValue(0x0F); // INT

            location = Maths.IntToByteArray(0xFF, size);
            SetValue(0xFF); // HALT

        }

        public byte ReadData(byte[] location)
        {
            int memoryLocation = Maths.ByteArrToInt(location);
            return data[memoryLocation];

        }

        public void SetValue(byte value)
        {
            int memoryLocation = Maths.ByteArrToInt(location);
            this.data[memoryLocation] = value;

        }

        public override void RecieveData(byte value)
        {
            if (iteration == size - 1)
            {
                SetValue(value);

                iteration = 0;

            }
            else
            {
                location[iteration] = value;
                iteration++;

            }
        }
    }
}
