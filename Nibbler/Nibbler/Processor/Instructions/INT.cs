using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nibbler.Motherboard;

namespace Nibbler.Processor.Instructions
{
    class INT : CPUInstruction
    {
        public INT()
            : base(0x0F)
        {


        }

        public enum Interrupts
        {
            HALT = 0xFF,
            PRINT_VALUE = 0x0A,
            DISPLAY = 0x80

        }

        // -= Interrupt =-
        // INT CODE [Register]
        // Gets next memory address for CODE
        // If interrupt requires, gets memory address for Register
        public override void Execute(Mainboard mainboard)
        {
            mainboard.GetCPU().IncrementPC();
            mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
            byte interrupt = mainboard.GetCPU().GetInstruction();

            switch (interrupt)
            {
                case 0xFF: Console.ReadKey(); break; // HALT 

                case 0x0A:
                    mainboard.GetCPU().IncrementPC();
                    mainboard.GetCPU().FetchInstruction(mainboard.GetRAM());
                    byte register = mainboard.GetCPU().GetInstruction();              
                    Console.WriteLine(mainboard.GetCPU().GetRegister(register).GetByteValue()); break; // Print register value

                case 0x80: break;

            }
        }
    }
}
