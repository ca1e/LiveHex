using USP.Core;

namespace USP.UI.Script
{
    public record ScriptRecord
    {
        public string Description { get; set; } = "<no description>";
        public string Address { get; set; } = "main";
        public DataType DType { get; set; } = DataType.BYTE;
        public bool Hexadecimal { get; set; } = false;

        public string UpdateData(IRAMEditor editor)
        {
            var pointer = editor.GetPointer(Address);
            if (pointer == ulong.MaxValue)
            {
                return "??";
            }
            else
            {
                var len = DType switch
                {
                    DataType.BYTE => 2,
                    DataType.TWO_BYTE => 4,
                    DataType.FOUR_BYTE => 8,
                    _ => throw new System.Exception("impossible"),
                };
                var rawMemdata = editor.ReadAbsolute(pointer, len);
                var valueType = DType switch
                {
                    DataType.BYTE => ValueType.SHORT,
                    DataType.TWO_BYTE => ValueType.INT,
                    DataType.FOUR_BYTE => ValueType.LONG,
                    _ => throw new System.Exception("impossible"),
                };
                var valueData = new ValueData(rawMemdata, valueType);
                return valueData.HumanValue.ToString(Hexadecimal ? "X" : "D");
            }
        }
    }

    public enum DataType : byte
    {
        BYTE = 0,
        TWO_BYTE,
        FOUR_BYTE,
    }
}
