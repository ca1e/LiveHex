namespace USP.UI.Script
{
    public record ScriptRecord
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public DataType type { get; set; }
        public bool Hexadecimal { get; set; }
    }

    public enum DataType
    {
        BYTE,
        TWO_BYTE,
        FOUR_BYTE,
    }
}
