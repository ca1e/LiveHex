using System;
using System.Linq;

namespace USP.Core
{
    public class ValueData
    {
        public ValueData(int type, byte[]? data)
        {
            if (data == null)
                this.bytes = new byte[type];
            else
                this.bytes = data;

        }
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
}
