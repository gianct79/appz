/*
* Copyleft 1979-2013 GTO Inc. All rights reversed.
*/

using System;
using System.IO;

namespace printApp
{
    public static class TypeExtensions
    {
        public static int ReadInt(this BinaryReader reader)
        {
            byte ch1 = reader.ReadByte();
            byte ch2 = reader.ReadByte();
            byte ch3 = reader.ReadByte();
            byte ch4 = reader.ReadByte();
            if ((ch1 | ch2 | ch3 | ch4) < 0)
                throw new EndOfStreamException();

            return ((ch1 << 24) + (ch2 << 16) + (ch3 << 8) + (ch4 << 0));
        }

        public static short ReadShort(this BinaryReader reader)
        {
            byte ch1 = reader.ReadByte();
            byte ch2 = reader.ReadByte();
            if ((ch1 | ch2) < 0)
                throw new EndOfStreamException();
            return (short)((ch1 << 8) + (ch2 << 0));
        }

        public static void WriteInt(this BinaryWriter writer, int v)
        {
            writer.Write((byte)(v >> 24));
            writer.Write((byte)(v >> 16));
            writer.Write((byte)(v >> 8));
            writer.Write((byte)(v >> 0));
        }

        public static void WriteShort(this BinaryWriter writer, short v)
        {
            writer.Write((byte)(v >> 8));
            writer.Write((byte)(v >> 0));
        }

        public static bool EqualsIgnoreCase(this string str, string v)
        {
            return str.Equals(v, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
