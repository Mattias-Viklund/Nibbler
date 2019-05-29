using Assembler.Util;
using Nibbler;
using Nibbler.Core;
using Nibbler.Motherboard;
using Nibbler.Processor;
using Nibbler.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void ParseFile(string path)
        {
            if (!File.Exists(path))
                return;

            using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
            {
                string line = sr.ReadLine();

            }
        }

        static byte FromHex(string val)
        {
            int value = Utils.FromHex(string.Format("{0:X2}", val));
            return (byte)value;

        }

        static byte MnemToByte(string mnemonic, bool register)
        {
            byte b = 0;
            mnemonic = mnemonic.ToUpper();
            if (register)
                switch (mnemonic)
                {
                    case "A": b = 0x00; break;
                    case "B": b = 0x01; break;
                    case "C": b = 0x02; break;
                    case "D": b = 0x03; break;
                    case "E": b = 0x04; break;
                    case "R1": b = 0x05; break;
                    case "R2": b = 0x06; break;
                    case "R3": b = 0x07; break;
                    case "R4": b = 0x08; break;
                    case "R5": b = 0x09; break;
                    case "AL": b = 0x0A; break;
                    case "AX": b = 0x0B; break;
                    case "BL": b = 0x0C; break;
                    case "BX": b = 0x0D; break;
                    case "REX": b = 0x0E; break;
                    case "REL": b = 0x0F; break;

                }
            else
                switch (mnemonic)
                {
                    case "NOP": b = 0x00; break;
                    case "MOV": b = 0x01; break;
                    case "ADD": b = 0x02; break;
                    case "SUB": b = 0x03; break;
                    case "MUL": b = 0x04; break;
                    case "DIV": b = 0x05; break;
                    case "JMP": b = 0x06; break;
                    case "JEZ": b = 0x07; break;
                    case "JGZ": b = 0x08; break;
                    case "JLZ": b = 0x09; break;
                    case "LD": b = 0x0A; break;
                    case "STR": b = 0x0B; break;
                    case "ADDR": b = 0x0C; break;
                    //case "NOP": b = 0x0D; break;
                    //case "NOP": b = 0x0E; break;
                    case "INT": b = 0x0F; break;

                }
            return b;

        }

        //static byte[] ParseFile(string path)
        //{
        //    FileStream fs = new FileStream(path, FileMode.Open);

        //    byte[] arr = new byte[fs.Length];

        //    int byteRead;

        //    int value;
        //    for (int i = 0; (byteRead = fs.ReadByte()) != -1; i++)
        //    {
        //        value = Utils.FromHex(string.Format("{0:X2}", byteRead));
        //        arr[i] = (byte)value;

        //    }

        //    return arr;
        //}
    }
}
