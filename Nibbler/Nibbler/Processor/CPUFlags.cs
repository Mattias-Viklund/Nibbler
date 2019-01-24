using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor
{
    static class CPUFlags
    {
        public static byte CPU_WAITING = 1 << 0;
        public static byte CPU_CARRY = 1 << 1;

    }
}
