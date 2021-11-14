using USP.Core;

namespace USP.UI.Editor
{
    class FakeEditor : IRAMEditor
    {
        public ProcessInfo GetInfo()
        {
            return new ProcessInfo{ };
        }

        public ulong GetPointer(string parser)
        {
            return ulong.MaxValue;
        }

        public byte[] Read(uint offset, int length)
        {
            return new byte[length];
        }

        public byte[] ReadAbsolute(ulong offset, int length)
        {
            return new byte[length];
        }

        public byte[] ReadMain(ulong offset, int length)
        {
            return new byte[length];
        }

        public void Write(byte[] data, uint offset)
        {
            return;
        }

        public void WriteAbsolute(byte[] data, ulong offset)
        {
            return;
        }

        public void WriteMain(byte[] data, ulong offset)
        {
            return;
        }
    }
}
