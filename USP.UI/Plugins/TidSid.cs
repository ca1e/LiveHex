using USP.Core;

namespace USP.Plugins
{
    sealed internal class TidSid : IDataType
    {
        int IDataType.Length => 4;
        string IDataType.ToString() => "TIDSID";

        string IDataType.ParseData(byte[] raw, bool _)
        {
            var tid = new ValueData(raw, ValueType.SHORT);
            var sid = new ValueData(raw[2..], ValueType.SHORT);
            return $"t/s:{tid.HumanValue}/{sid.HumanValue}";
        }

        DataUserControl IDataType.ShowControl()
        {
            throw new System.NotImplementedException();
        }
    }
}
