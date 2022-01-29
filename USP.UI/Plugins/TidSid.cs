using System;
using USP.Core;

namespace USP.Plugins
{
    sealed internal class TidSid : IDataType
    {
        int IDataType.Length => 4;

        byte[] IDataType.GetData(string val)
        {
            throw new NotImplementedException();
        }

        string IDataType.ParseData(byte[] raw, bool _)
        {
            var tid = new ValueData(raw, Core.ValueType.SHORT);
            var sid = new ValueData(raw[2..], Core.ValueType.SHORT);
            return $"t/s:{tid.HumanValue}/{sid.HumanValue}";
        }

        public override string ToString() => "TIDSID";
    }
}
