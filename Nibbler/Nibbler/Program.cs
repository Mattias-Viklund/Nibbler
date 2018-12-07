using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Nibbler.Core;
using Nibbler.Util;

namespace Nibbler
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 0xF1;
            byte b = 0xF3;

            Console.WriteLine((int)Nibble.AddNibble(a, b));
            Console.ReadLine();

        }
    }
}