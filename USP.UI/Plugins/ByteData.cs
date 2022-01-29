using USP.Core;

namespace USP.Plugins
{
    sealed internal class ByteData : IDataType
    {
        private readonly int _len;

        public ByteData(int l = 1) { _len = l <= 8 ? l : 1; }

        private ValueType ValueType => _len switch
        {
            1 => ValueType.BYTE,
            2 => ValueType.SHORT,
            4 => ValueType.INT,
            8 => ValueType.LONG,
            _ => throw new System.Exception("impossible"),
        };

        int IDataType.Length => _len;

        DataUserControl IDataType.ShowControl()
        {
            return new DigiShow(ValueType);
        }

        string IDataType.ParseData(byte[] raw, bool isHex)
        {
            var valueData = new ValueData(raw, ValueType);
            return valueData.HumanValue.ToString(isHex ? "X" : "D");
        }

        string IDataType.ToString() => _len switch
        {
            1 => "BYTE",
            2 => "TWO_BYTE",
            4 => "FOUR_BYTE",
            8 => "EIGHT_BYTE",
            _ => throw new System.NotImplementedException(),
        };
    }
}
