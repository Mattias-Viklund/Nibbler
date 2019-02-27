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
            int value = Utils.FromHex("0x01020304");
            ParseFile("debug.masm");
            Console.WriteLine(Maths.IntToArrString(value));
            Console.ReadLine();

        }

        static byte[] ParseFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            byte[] arr = new byte[fs.Length];

            int byteRead;

            int value;
            for (int i = 0; (byteRead = fs.ReadByte()) != -1; i++)
            {
                value = Utils.FromHex(string.Format("{0:X2}", byteRead));
                arr[i] = (byte)value;

            }

            return arr;
        }
    }
}
