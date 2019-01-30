using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Motherboard
{
    public abstract class Component
    {
        private bool onBus;
        private byte component;

        // Is the component connected to the bus? What's it's id?
        public Component(bool onBus, byte component, bool macro = true)
        {
            this.onBus = onBus;
            this.component = component;

            if (macro)
                Mainboard.components.Add(this);

        }

        public byte GetComponentID()
        {
            return this.component;

        }

        public abstract void RecieveData(byte data);

    }
}
