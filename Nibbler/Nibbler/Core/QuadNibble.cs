using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Core
{
    /// <summary>
    /// Basically just 2 bytes (16 bit char).
    /// Max value: 65535, 0xFFFF
    /// Usage: Memory
    /// </summary>
    class QuadNibble
    {
        char quadNibble;

        public QuadNibble(char quadNibble)
        {
            this.quadNibble = quadNibble;

        }

        public void Set(bool left, byte dualNibbleData)
        {
            byte data = (byte)(dualNibbleData & 0xFF);

            if (left)
            {
                data = (byte)(data << 8);

                this.quadNibble = (char)(quadNibble & 0xFF);
                this.quadNibble = (char)(quadNibble | data);

            }
            else
            {
                this.quadNibble = (char)(quadNibble & 0xFF00);
                this.quadNibble = (char)(quadNibble | data);

            }
        }

        public void SetWhole(char quadNibble)
        {
            this.quadNibble = quadNibble;

        }

        public DualNibble GetDualNibble(bool left)
        {
            if (left)
            {
                byte nibble = (byte)(quadNibble >> 8);
                return new DualNibble(nibble);

            }
            else
            {
                byte nibble = (byte)(quadNibble & 0xFF);
                return new DualNibble(nibble);

            }
        }
    }
}
