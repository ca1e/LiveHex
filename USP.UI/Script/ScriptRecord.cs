using System.Collections.Generic;
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

        public static List<string> GetDefaultTypes()
        {
            return new List<string> { "BYTE", "U16", "U32", "U64", "TIDSID" };
        }

        private static IDataType GetDataType(string t)
        {
            return t switch
            {
                "BYTE" => new ByteData(1),
                "U16" => new ByteData(2),
                "U32" => new ByteData(4),
                "U64" => new ByteData(8),
                "TIDSID" => new TidSid(),
                _ => throw new System.NotImplementedException(),
            };
        }

        private IDataType _DType = new ByteData(1); // default
        public bool Hexadecimal { get; set; } = false;

        public DataUserControl ShowControl(byte[] data)
        {
            var form = _DType.ShowControl();
            form.Data = data;
            return form;
        }

        public byte[] GetData(IRAMEditor editor)
        {
            var pointer = editor.GetPointer(Address);
            if (pointer == ulong.MaxValue)
            {
                return System.Array.Empty<byte>();
            }
            return editor.ReadAbsolute(pointer, _DType.Length);
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
