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
            SetValue(0x00);

            location = Maths.IntToByteArray(0x01, size);
            SetValue(0x01);

            location = Maths.IntToByteArray(0x02, size);
            SetValue(0x00);

            location = Maths.IntToByteArray(0x03, size);
            SetValue(0x0F);

            location = Maths.IntToByteArray(0x04, size);
            SetValue(0x00);

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
