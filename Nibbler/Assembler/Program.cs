using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Nibbler;
using Nibbler.Core;
using Nibbler.Motherboard;
using Nibbler.Processor;
using Nibbler.Util;
using Assembler.Util;

namespace Assembler
{
    class Program
    {
        static void Main(string[] args)
        {
            string numba = "0xFFFF";
            int numba2 = Utils.FromHex(numba);
            Console.WriteLine(numba2);
            Console.ReadLine();

        }

        static void ParseFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            int hexIn;
            string hex;

            for (int i = 0; (hexIn = fs.ReadByte()) != -1; i++)
            {
                hex = string.Format("{0:X2}", hexIn);

            }
        }
    }
}
