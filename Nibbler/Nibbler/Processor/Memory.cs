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

        public byte ReadData(byte[] location)
        {
            int memoryLocation = Maths.ByteArrToInt(location);
            return data[memoryLocation];

        }

        public override void RecieveData(byte data)
        {
            if (iteration == size - 1)
            {
                int memoryLocation = Maths.ByteArrToInt(location);
                this.data[memoryLocation] = data;

                iteration = 0;

            }
            else
            {
                location[iteration] = data;

                iteration++;

            }
        }
    }
}
