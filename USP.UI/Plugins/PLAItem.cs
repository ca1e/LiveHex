using USP.Core;

namespace USP.Plugins
{
    sealed internal class PLAItem : IDataType
    {
        int IDataType.Length => 4;
        string IDataType.ToString() => "PLAITEM";

        string IDataType.ParseData(byte[] raw, bool _)
        {
            var item = new ValueData(raw, ValueType.SHORT);
            var count = new ValueData(raw[2..], ValueType.SHORT);
            return $"{item}({count})";
        }

        DataUserControl IDataType.ShowControl()
        {
            return new ItemShow();
        }
    }
}
