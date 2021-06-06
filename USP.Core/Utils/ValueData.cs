using System;
using System.Linq;

namespace USP.Core
{
    public class ValueData
    {
#nullable enable
        public ValueData(byte[]? data, ValueType type)
        {
            if (data == null)
                this.bytes = new byte[(int)type];
            else
                this.bytes = data;

        }
#nullable disable
        public byte[] Bytes => bytes;

        private byte[] bytes;

        public ulong HumanValue
        {
            get
            {
                var s = BitConverter.ToString(bytes.Take(bytes.Length).Reverse().ToArray()).Replace("-", "");
                return ulong.Parse(s, System.Globalization.NumberStyles.HexNumber);
            }
            set
            {
                var r = BitConverter.GetBytes(value);
                Array.Copy(r, 0, bytes, 0, bytes.Length);
            }
        }
    }

    public enum ValueType
    {
        BYTE = 0x1,
        SHORT = 0x2,
        INT = 0x4,
        LONG = 0x8,
    }
}
