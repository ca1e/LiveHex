using System;

namespace USP.Plugins
{
    sealed internal class PLAItem : IDataType
    {
        int IDataType.Length => 4;
        string IDataType.ToString() => "PLAITEM";

        string IDataType.ParseData(byte[] raw, bool _)
        {
            var item = BitConverter.ToInt16(raw.AsSpan());
            var count = BitConverter.ToInt16(raw.AsSpan()[2..]);
            return $"{item}({count})";
        }

        DataUserControl IDataType.ShowControl()
        {
            return new ItemShow();
        }
    }
}
