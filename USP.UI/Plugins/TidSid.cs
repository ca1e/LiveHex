using System;

namespace USP.Plugins
{
    sealed internal class TidSid : IDataType
    {
        int IDataType.Length => 4;
        string IDataType.ToString() => "TIDSID";

        string IDataType.ParseData(byte[] raw, bool _)
        {
            var tid = BitConverter.ToUInt16(raw.AsSpan());
            var sid = BitConverter.ToUInt16(raw.AsSpan()[2..]);
            return $"t/s:{tid}/{sid}";
        }

        DataUserControl IDataType.ShowControl()
        {
            throw new System.NotImplementedException();
        }
    }
}
