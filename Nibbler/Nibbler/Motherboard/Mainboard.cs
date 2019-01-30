using Nibbler.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nibbler.Motherboard
{
    public class Mainboard
    {
        public static List<Component> components = new List<Component>();

        private CPU cpu;
        private Bus bus;
        private Memory memory;

        public Mainboard(CPU cpu)
        {
            this.cpu = cpu;
            this.bus = new Bus();
            this.memory = new Memory(cpu.GetMemoryWidth());

        }

        public void Cycle()
        {
            cpu.Think(this);

            foreach (Component c in components)
            {
                if (bus.Read(c.GetComponentID()))
                {
                    c.RecieveData(bus.Read());

                }
            }
        }

        public Memory GetRAM()
        {
            return memory;

        }

        public CPU GetCPU()
        {
            return cpu;

        }

        public void SendBus(byte recipient, byte data)
        {
            bus.Write(recipient, data);

        }
    }
}
