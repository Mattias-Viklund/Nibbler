using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;

namespace Nibbler.Processor
{
    class CPU : Component
    {
        private byte[] programCounter;
        private byte memoryWidth;

        public CPU(byte memoryWidth)
            : base(true, 0x00)
        {
            this.memoryWidth = memoryWidth;
            this.programCounter = new byte[memoryWidth];

        }

        public void Think(Mainboard mainboard)
        {
            ReadInstruction(mainboard.GetRAM());

        }

        public void IncrementPC()
        {
            if (programCounter[memoryWidth-1] == 0xFF)
            {

            }
        }

        public void ReadInstruction(Memory memory)
        {
            memory.ReadData(programCounter);

        }

        public void ExecuteInstruction(byte instruction)
        {
            switch (instruction)
            {
                case 0x00: break; // NOP
                case 0x01: break; // ADD
                case 0x02: break; // SUB
                case 0x03: break; // MUL
                case 0x04: break; // DIV
                case 0x05: break; // JMP
                case 0x06: break; // JEZ
                case 0x07: break; // JGZ
                case 0x08: break; // JLZ
                case 0x09: break; // LD
                case 0x0A: break; // STR
                case 0x0B: break; // NOP
                case 0x0C: break; // NOP
                case 0x0D: break; // NOP
                case 0x0E: break; // NOP
                case 0x0F: break; // INT

            }
        }

        public override void RecieveData(byte data)
        {

        }

        public byte GetMemoryWidth()
        {
            return this.memoryWidth;

        }
    }
}
