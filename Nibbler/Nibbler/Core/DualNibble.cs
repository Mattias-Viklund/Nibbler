using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Core
{
    /// <summary>
    /// Basically just a byte (8 bit byte).
    /// Max value: 255, 0xFF
    /// Usage: Computational, Instructions, Operations
    /// </summary>
    class DualNibble
    {
        byte dualNibble;

        public DualNibble(byte dualNibble)
        {
            this.dualNibble = dualNibble;

        }

        public byte GetNibble(bool left)
        {
            if (left)
                return (byte)(dualNibble >> 4);

            return (byte)(dualNibble & 0xF);

        }

        public void Set(bool left, byte nibbleData)
        {
            byte data = (byte)(nibbleData & 0xF);

            if (left)
            {
                data = (byte)(data << 4);

                this.dualNibble = (byte)(dualNibble & 0xF);
                this.dualNibble = (byte)(dualNibble | data);

            }
            else
            {
                this.dualNibble = (byte)(dualNibble & 0xF0);
                this.dualNibble = (byte)(dualNibble | data);

            }
        }

        public void SetWhole(byte dualNibble)
        {
            this.dualNibble = dualNibble;

        }

        public static byte AddNibbles(byte left, byte right)
        {
            return (byte)(left + right);

        }

        public static byte AppendNibbles(byte left, byte right)
        {
            byte tempA = (byte)(left << 4);

            return (byte)(tempA | right);

        }
    }
}
