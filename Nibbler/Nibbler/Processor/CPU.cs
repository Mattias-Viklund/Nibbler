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
    public class CPU : Component
    {
        private byte[] programCounter;
        private byte memoryWidth;

        private bool waiting;
        private byte instruction;
        private byte lastInstruction;

        private CPURegister[] registers = new CPURegister[0x12]; // (16) 8 bit registers, (1) 16 bit register
        private CPUInstruction[] instructions = new CPUInstruction[0x10]; // 0x0F + 1 instructions

        public CPU(byte memoryWidth)
            : base(true, 0x00)
        {
            this.memoryWidth = memoryWidth;
            this.programCounter = new byte[memoryWidth];
            SetupRegisters();
            SetupInstructions();

        }

        public void Think(Mainboard mainboard)
        {
            FetchInstruction(mainboard.GetRAM());
            ExecuteInstruction(mainboard);

            IncrementPC();

        }


        public byte FetchInstruction(Memory memory)
        {
            lastInstruction = instruction;
            instruction = memory.ReadData(programCounter);
            return instruction;

        }

        public void ExecuteInstruction(Mainboard mainboard)
        {
            switch (instruction)
            {
                case 0x00: instructions[0x00].Execute(mainboard); break; // NOP
                case 0x01: instructions[0x01].Execute(mainboard); break; // MOV
                case 0x02: instructions[0x02].Execute(mainboard); break; // ADD
                case 0x03: instructions[0x03].Execute(mainboard); break; // SUB
                case 0x04: instructions[0x04].Execute(mainboard); break; // MUL
                case 0x05: instructions[0x05].Execute(mainboard); break; // DIV
                case 0x06: instructions[0x06].Execute(mainboard); break; // JMP
                case 0x07: instructions[0x07].Execute(mainboard); break; // JEZ
                case 0x08: instructions[0x08].Execute(mainboard); break; // JGZ
                case 0x09: instructions[0x09].Execute(mainboard); break; // JLZ
                case 0x0A: instructions[0x0A].Execute(mainboard); break; // LD
                case 0x0B: instructions[0x0B].Execute(mainboard); break; // STR
                case 0x0C: instructions[0x0C].Execute(mainboard); break; // ADDR
                case 0x0D: instructions[0x0D].Execute(mainboard); break; // NOP
                case 0x0E: instructions[0x0E].Execute(mainboard); break; // NOP
                case 0x0F: instructions[0x0F].Execute(mainboard); break; // INT

            }
        }

        public override void RecieveData(byte data)
        {

        }

        public byte GetMemoryWidth()
        {
            return this.memoryWidth;

        }
        public byte GetInstruction()
        {
            return instruction;
        }
        public int GetPC()
        {
            int PC = Maths.ByteArrToInt(programCounter);
            return PC;

        }

        public void IncrementPC()
        {
            Maths.AddArray(ref programCounter, memoryWidth, 1);

        }

        public CPURegister GetRegister(byte register)
        {
            if (register >= registers.Length)
                return null;

            return registers[register];

        }

        public void SetRegister(byte register, byte[] value)
        {
            GetRegister(register).SetValue(value);

        }

        public void SetRegister(byte register, byte value)
        {
            GetRegister(register).SetValue(value);

        }

        public bool IsSameInstruction()
        {
            if (lastInstruction == instruction)
                return true;

            return false;

        }

        private void SetupRegisters()
        {
            registers[0x00] = new _8BitRegister(0x00); // A
            registers[0x01] = new _8BitRegister(0x01); // B
            registers[0x02] = new _8BitRegister(0x02); // C
            registers[0x03] = new _8BitRegister(0x03); // D
            registers[0x04] = new _8BitRegister(0x04); // E
            registers[0x05] = new _8BitRegister(0x05); // F
            registers[0x06] = new _8BitRegister(0x06); // R1
            registers[0x07] = new _8BitRegister(0x07); // R2
            registers[0x08] = new _8BitRegister(0x08); // R3
            registers[0x09] = new _8BitRegister(0x09); // R4
            registers[0x0A] = new _8BitRegister(0x0A); // R5
            registers[0x0B] = new _8BitRegister(0x0B); // AL
            registers[0x0C] = new _8BitRegister(0x0C); // AX
            registers[0x0D] = new _8BitRegister(0x0D); // BL
            registers[0x0E] = new _8BitRegister(0x0E); // BX
            registers[0x0F] = new _8BitRegister(0x0F); // X

            registers[0x10] = new _16BitRegister(0x10); // REX
            registers[0x11] = new _32BitRegister(0x11); // REL

        }
        private void SetupInstructions()
        {
            instructions[0x00] = new NOP();
            instructions[0x01] = new MOV();
            instructions[0x02] = new ADD();
            instructions[0x03] = new NOP();
            instructions[0x04] = new NOP();
            instructions[0x05] = new NOP();
            instructions[0x06] = new NOP();
            instructions[0x07] = new NOP();
            instructions[0x08] = new NOP();
            instructions[0x09] = new NOP();
            instructions[0x0A] = new NOP();
            instructions[0x0B] = new NOP();
            instructions[0x0C] = new ADDR();
            instructions[0x0D] = new NOP();
            instructions[0x0E] = new NOP();
            instructions[0x0F] = new INT();

        }

    }
}
