namespace USP.Plugins
{
    public interface IDataType
    {
        public int Length { get; }
        public string ParseData(byte[] raw, bool isHex);
        public DataUserControl ShowControl();
        public string ToString();
    }
}
