using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;
using Nibbler.Processor.Instructions;
using Nibbler.Processor.Registers;
using Nibbler.Util;

namespace Nibbler.Processor
{
    class CPU : Component
    {
        private byte[] programCounter;
        private byte memoryWidth;

        private bool waiting;

        private CPURegister[] registers = new CPURegister[0x10];
        private CPUInstruction[] instructions = new CPUInstruction[0x10];

        public CPU(byte memoryWidth)
            : base(true, 0x00)
        {
            this.memoryWidth = memoryWidth;
            this.programCounter = new byte[memoryWidth];
            Setup();

        }

        private void Setup()
        {
            instructions[0x00] = new NOP();
            instructions[0x01] = new NOP();
            instructions[0x02] = new NOP();
            instructions[0x03] = new NOP();
            instructions[0x04] = new NOP();
            instructions[0x05] = new NOP();
            instructions[0x06] = new NOP();
            instructions[0x07] = new NOP();
            instructions[0x08] = new NOP();
            instructions[0x09] = new NOP();
            instructions[0x0A] = new NOP();
            instructions[0x0B] = new NOP();
            instructions[0x0C] = new NOP();
            instructions[0x0D] = new NOP();
            instructions[0x0E] = new NOP();
            instructions[0x0F] = new NOP();

        }

        public void Think(Mainboard mainboard)
        {
            Console.WriteLine("Program Counter: " + GetPC());

            byte instruction = ReadInstruction(mainboard.GetRAM());
            ExecuteInstruction(instruction, mainboard);

            IncrementPC();

        }

        public int GetPC()
        {
            int PC = Maths.ByteArrToInt(programCounter);
            return PC;

        }

        public void IncrementPC()
        {
            Maths.IncrementArray(ref programCounter, memoryWidth);

        }

        public byte ReadInstruction(Memory memory)
        {
            return memory.ReadData(programCounter);

        }

        public void ExecuteInstruction(byte instruction, Mainboard mainboard)
        {
            switch (instruction)
            {
                case 0x00: instructions[0x00].Execute(mainboard); break; // NOP
                case 0x01: IncrementPC(); break; // ADD
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
