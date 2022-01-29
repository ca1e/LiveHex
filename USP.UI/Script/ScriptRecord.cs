using System.Windows.Forms;
using USP.Core;
using USP.Plugins;

namespace USP.UI.Script
{
    public record ScriptRecord
    {
        public string Address { get; init; } = "main";
        public string Description { get; set; } = "<no description>";
        public string DataType
        {
            get
            {
                return _DType.ToString();
            }
            set
            {
                _DType = GetDataType(value);
            }
        }

        private static IDataType GetDataType(string t)
        {
            return t switch
            {
                "BYTE" => new ByteData(1),
                "TWO_BYTE" => new ByteData(2),
                "FOUR_BYTE" => new ByteData(4),
                "EIGHT_BYTE" => new ByteData(8),
                "TIDSID" => new TidSid(),
                _ => throw new System.Exception("not implement"),
            };
        }

        public int DataLength => _DType.Length;

        private IDataType _DType = new ByteData(1); // default
        public bool Hexadecimal { get; set; } = false;

        public string ParseData(byte[] raw)=> _DType.ParseData(raw, Hexadecimal);
        public byte[] GetData(string val) => _DType.GetData(val);

        public Form LoadForm(IRAMEditor bot)
        {
           return new ScriptForm(bot, this);
        }

        public string UpdateData(IRAMEditor editor)
        {
            var pointer = editor.GetPointer(Address);
            if (pointer == ulong.MaxValue)
            {
                return "??";
            }
            else
            {
                var rawMemdata = editor.ReadAbsolute(pointer, _DType.Length);
                return _DType.ParseData(rawMemdata, Hexadecimal);
            }
        }
    }
}
