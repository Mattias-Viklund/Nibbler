using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;

namespace Nibbler.Processor
{
    class Memory : Component
    {
        private bool waiting = false;
        private byte size;

        private int iteration = 0;
        private byte[] location;
        private byte[] data;

        public Memory(byte size)
            : base(true, 0x01)
        {
            this.size = size;
            this.location = new byte[size];
            this.data = new byte[(int)Math.Pow(size, size)];

        }

        public override void RecieveData(byte data)
        {
            for (byte b = 0; b < size + 1; b++)
            {
                if (b == size)
                {
                    int memoryLocation = location[0];

                    for (int i = 1; i < size; i++)
                    {
                        memoryLocation = memoryLocation << 8;
                        memoryLocation = memoryLocation | location[i];

                    }

                    this.data[memoryLocation] = data;
                    waiting = false;
                    iteration = 0;

                }
                else
                {
                    location[iteration] = data;

                    iteration++;
                    waiting = true;

                }
            }
        }
    }
}
