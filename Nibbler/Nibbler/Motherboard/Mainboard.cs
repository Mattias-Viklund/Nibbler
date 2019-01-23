using Nibbler.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Motherboard
{
    class Mainboard
    {
        private CPU cpu;
        private Bus bus;
        private Memory memory;

        public Mainboard(CPU cpu, byte memory)
        {
            this.cpu = cpu;

        }

        public void Cycle()
        {
            cpu.Think(this);

        }

        public byte GetRAM()
        {
            return memory.GetComponent();

        }

        public void SendBus(byte recipient, byte data)
        {
            bus.Write(recipient, data);

        }
    }
}
