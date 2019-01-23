using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Motherboard
{
    abstract class Component
    {
        private bool onBus;
        private byte component;

        // Is the component connected to the bus? What's it's id?
        public Component(bool onBus, byte component)
        {
            this.onBus = onBus;
            this.component = component;

        }

        public byte GetComponent()
        {
            return this.component;

        }

        public abstract void RecieveData(byte data);

    }
}
