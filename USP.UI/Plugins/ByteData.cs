using System.Collections.Generic;
using USP.Core;

namespace USP.Plugins
{
    sealed internal class ByteData : IDataType
    {
        private readonly int _len;

        public ByteData(int l = 1) { _len = l; }

        private ValueType ValueType => _len switch
        {
            1 => ValueType.BYTE,
            2 => ValueType.SHORT,
            4 => ValueType.INT,
            8 => ValueType.LONG,
            _ => throw new System.Exception("impossible"),
        };

        public static List<string> GetDefaultTypes()
        {
            return new List<string> { "BYTE", "TWO_BYTE", "FOUR_BYTE", "EIGHT_BYTE" };
        }

        int IDataType.Length => _len;

        string IDataType.ParseData(byte[] raw, bool isHex)
        {
            var valueData = new ValueData(raw, ValueType);
            return valueData.HumanValue.ToString(isHex ? "X" : "D");
        }

        byte[] IDataType.GetData(string val)
        {
            return new ValueData(null, ValueType)
            {
                HumanValue = ulong.Parse(val)
            }.Bytes;
        }

        string IDataType.ToString() => _len switch
        {
            1 => "BYTE",
            2 => "TWO_BYTE",
            4 => "FOUR_BYTE",
            8 => "EIGHT_BYTE",
            _ => throw new System.Exception("impossible"),
        };
    }
}
