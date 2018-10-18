namespace Nibbler
{
    class Nibble
    {
        public const byte MaxValue = 0xF;
        public const byte MinValue = 0;

        public static byte MergeByteNibble(byte byt, byte nibble, bool first, bool nibbleFirst)
        {
            byte nibb = (byte)(nibble & 0b00001111);

            if (nibbleFirst)
            {
                byte b = byt;

                if (first)
                    b = (byte)((byt & 0b11110000) >> 4);
                else
                    b = (byte)(byt & 0b00001111);

                if (nibbleFirst)
                    b = (byte)(b | (nibble << 4));
                else
                    b = (byte)((b << 4) | nibble);

                return b;

            }
            else
            {
                byte b = byt;

                if (first)
                    b = (byte)((byt & 0b11110000) >> 4);
                else
                    b = (byte)(byt & 0b00001111);

                if (nibbleFirst)
                    b = (byte)(b | (nibble << 4));
                else
                    b = (byte)((b << 4) | nibble);

                return b;

            }
        }

        public static byte ByteToNibble(byte b, bool first)
        {
            if (first)
            {
                return (byte)(b >> 4);

            }
            else
            {
                return (byte)(b & 0b00001111);

            }
        }
    }
}