using Nibbler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibbler.Processor
{
    class Bus
    {
        private byte reciever = 0x00;
        private byte busData = 0x00;
        private bool waiting = false;

        // component = X | Recipient
        public bool Read(byte component)
        {
            if (Nibble.ToNibble(reciever, false) == component)
                return true;

            return false;

        }

        public byte Read()
        {
            waiting = false;

            byte temp = busData;
            busData = 0x00;

            return temp;

        }

        // data = Recipient | Nibbledata
        public void Write(byte recipient, byte data)
        {
            reciever = recipient;
            busData = data;
            waiting = true;

        }

        public bool IsWaiting()
        {
            return waiting;

        }
    }
}
