using Be.Windows.Forms;
using System;
using USP.Core;

namespace USP.UI
{
    sealed class RAMProvider : IByteProvider
    {
        public IRAMEditor CoreBot { get;  init; }

        public ulong Addr;
        public string Address
        {
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Empty Address");
                }
                try
                {
                    Addr = ulong.Parse(value, System.Globalization.NumberStyles.HexNumber);

                    Bytes = CoreBot.ReadAbsolute(Addr, ByteLength);
                }
                catch
                {
                    throw new Exception("Address Format Error");
                }
            }
        }
        public int ByteLength { get; init; }

        private byte[] Bytes;
        private bool changed;

        public long Length => Bytes.Length;

        public event EventHandler LengthChanged;
        public event EventHandler Changed;

        void OnChanged(EventArgs e)
            => Changed?.Invoke(this, e);

        public void ApplyChanges()
        {
            CoreBot.WriteAbsolute(Bytes, Addr);
            changed = false;
        }

        public void DeleteBytes(long index, long length)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges() => changed;

        public void InsertBytes(long index, byte[] bs)
        {
            throw new NotImplementedException();
        }

        public byte ReadByte(long index)
        {
            return Bytes[index];
        }

        public bool SupportsDeleteBytes() => false;

        public bool SupportsInsertBytes() => false;

        public bool SupportsWriteByte() => true;

        public void WriteByte(long index, byte value)
        {
            Bytes[index] = value;
            changed = true;
            OnChanged(EventArgs.Empty);
            //OnWriteFinished(EventArgs.Empty);
        }
    }
}
