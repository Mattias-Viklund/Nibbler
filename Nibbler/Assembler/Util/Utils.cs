using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler.Util
{
    static class Utils
    {
        public static int FromHex(string str)
        {
            if (str.Length < 2)
                return -1;

            try
            {
                int result = Convert.ToInt32(str, 16);
                return result;

            }
            catch
            {
                return -1;

            }
        }

    }
}
