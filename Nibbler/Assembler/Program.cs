using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assembler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            string path = args[0];

            if (File.Exists(path))
            {


            }
            else
                return;

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
