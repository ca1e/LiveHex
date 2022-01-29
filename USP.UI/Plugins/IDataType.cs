namespace USP.Plugins
{
    public interface IDataType
    {
        public int Length { get; }
        public string ParseData(byte[] raw, bool isHex);
        public byte[] GetData(string val);

        public string ToString();
    }
}
