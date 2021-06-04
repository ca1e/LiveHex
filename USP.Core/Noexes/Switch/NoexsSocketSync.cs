using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace Noexes.Base
{
    public sealed class NoexsSocketSync : SwitchSocket, INoexsConnectionSync
    {
        private readonly static object _sync = new();

        public NoexsSocketSync(IWirelessConnectionConfig cfg) : base(cfg) { }

        public override void Connect()
        {
            Log("Connecting to device...");
            // Info.Port == 7331;
            var result = Connection.BeginConnect(Info.IP, Info.Port, null, null);

            bool success = result.AsyncWaitHandle.WaitOne(3000, true);
            if (success)
            {
                Connection.EndConnect(result);
            }
            else
            {
                Connection.Close();
                throw new SocketException(10060); // Connection timed out.
            }
            Connected = true;
            Log("Connected!");
        }

        public override void Reset()
        {
            Disconnect();
            Connect();
        }

        public override void Disconnect()
        {
            Log("Disconnecting from device...");
            Connection.Disconnect(false);
            Connected = false;
            Log("Disconnected!");
        }

        private int Read(byte[] buffer) => Connection.Receive(buffer);
        public int Send(byte[] buffer) => Connection.Send(buffer);

        private int ReadResult()
        {
            var c = ReadResponse(4);
            return BitConverter.ToInt32(c, 0);
        }

        private byte ReadByte() => ReadResponse(1)[0];

        private ushort ReadShort() => BitConverter.ToUInt16(ReadResponse(2), 0);

        private uint ReadInt() => BitConverter.ToUInt32(ReadResponse(4), 0);

        private ulong ReadLong() => BitConverter.ToUInt64(ReadResponse(8), 0);

        private MemoryInfo ReadInfo()
        {
            var addr = ReadLong();
            var size = ReadLong();
            var type = ReadInt();
            var perm = ReadInt();
            var r = ReadResult();
            if(r != 0)
            {
                throw new Exception($"err code: {r}");
            }
            //return info;
            return new MemoryInfo { Address = addr, Size = size, Type = type, Perm = perm };
        }

        private byte[] ReadResponse(int length)
        {
            // Thread.Sleep(1);
            lock (_sync)
            {
                var buffer = new byte[length];
                var i = Read(buffer);
                System.Diagnostics.Debug.WriteLine($"[read] Require: {length}, Get:{i}, Available: {Connection.Available}");
                return buffer;
            }
        }

        private int SendResult(byte[] buf)
        {
            lock (_sync)
            {
                Send(buf);
                return ReadResult();
            }
        }
        
        private void WaitForAvailable(int len)
        {
            while (Connection.Available < len) {; }
        }

        public IEnumerable<ulong> GetPids()
        {
            lock (_sync)
            {
                Send(NoexsCommand.GetPids());
                var count = ReadResult();
                var data = ReadResponse(count * 8);
                ReadResult();
                for (var i = 0; i<count; i++)
                {
                    yield return BitConverter.ToUInt64(data, i * 8);
                }
            }
        }

        public ulong CurrentPid()
        {
            lock (_sync)
            {
                Send(NoexsCommand.GetCurrentPid());
                var cpid = ReadLong();
                if (ReadResult() != 0) cpid = 0;
                return cpid;
            }
        }

        public ulong GetTitleId(ulong pid)
        {
            lock (_sync)
            {
                Send(NoexsCommand.GetTitleID(pid));
                var tid = ReadLong();
                ReadResult();
                return tid;
            }
        }

        private int Attach(ulong pid)
        {
            lock (_sync)
            {
                Send(NoexsCommand.Attach(pid));
                return ReadResult();
            }
        }

        public int Attach()
        {
            var cpid = CurrentPid();
            System.Diagnostics.Debug.WriteLine($"[PID] Current pid: {cpid}");
            return Attach(cpid);
        }

        public void Resume() => SendResult(NoexsCommand.Resume());

        public MemoryInfo[] Query(long start, int max)
        {
            lock (_sync)
            {
                Send(NoexsCommand.Query(start, max));
                var res = new List<MemoryInfo>();
                int count = 0;
                for (count = 0; count < max; count++)
                {
                    var info = ReadInfo();
                    if (info.GetMemType() == MemoryType.RESERVED)
                    {
                        break;
                    }
                    res.Add(info);
                }
                ReadResult();
                return res.ToArray();
            }
        }

        private ulong Main_ = ulong.MaxValue;
        private ulong Heap = ulong.MaxValue;

        public void InitInfo()
        {
            var mi = Query(0, 1000);
            int moduleCount = 0;
            foreach (var m in mi)
            {
                if (m.GetMemType() == MemoryType.CODE_STATIC && m.Perm == 0b101)
                {
                    moduleCount++;
                }
            }
            var mod = 0;
            var heapB = false;
            foreach (var m in mi)
            {
                if (m.GetMemType() == MemoryType.HEAP && !heapB)
                {
                    heapB = true;
                    Heap = m.Address;
                }
                if (m.GetMemType() == MemoryType.CODE_STATIC && m.Perm == 0b101)
                {
                    if (mod == 0 && moduleCount == 1)
                    {
                        Main_ = m.Address;
                        break;
                    }
                    if (moduleCount > 1)
                    {
                        switch (mod)
                        {
                            case 1:
                                Main_ = m.Address;
                                break;
                        }
                    }
                    mod++;
                }
            }
            System.Diagnostics.Debug.Write(mi);
        }

        public ulong GetMainNsoBase()
        {
            return Main_;
        }

        public ulong GetHeapBase()
        {
            return Heap;
        }

        public ulong GetTitleID()
        {
            return GetTitleId(CurrentPid());
        }

        public ulong GetBuildID()
        {
            return ulong.MaxValue;
        }

        public byte[] ReadBytes(uint offset, int length) => throw new NotImplementedException();
        public byte[] ReadBytesMain(ulong offset, int length) => throw new NotImplementedException();
        public byte[] ReadBytesAbsolute(ulong offset, int length) => ReadInternal(offset, length, SwitchOffsetType.Absolute);

        public void WriteBytes(byte[] data, uint offset) => throw new NotImplementedException();
        public void WriteBytesMain(byte[] data, ulong offset) => throw new NotImplementedException();
        public void WriteBytesAbsolute(byte[] data, ulong offset) => WriteInternal(data, offset, SwitchOffsetType.Absolute);

        private byte[] ReadInternal(ulong offset, int length, SwitchOffsetType type)
        {
            lock (_sync)
            {
                try
                {
                    Send(NoexsCommand.ReadMem(offset, (uint)length));
                    var data = ReadResult();
                    if(data != 0)
                    {
                        throw new Exception($"err code: {data}");
                    }

                    var bytes = new byte[length];
                    int pos = 0;
                    var buffer = new byte[2048 * 4];

                    while (pos < length)
                    {
                        data = ReadResult();
                        if (data != 0)
                        {
                            throw new Exception($"err code: {data}");
                        }
                        int len = ReadCompressed(ref buffer);
                        Array.Copy(buffer, 0, bytes, pos, len);
                        pos += len;
                    }

                    return bytes;
                }
                finally
                {
                    ReadResult(); // ignore
                }
            }
        }

        private int ReadCompressed(ref byte[] buffer)
        {
            var compressedFlag = ReadByte();
            var decompressedLen = ReadResult();

            if (compressedFlag == 0)
            {
                var rawbuf = ReadResponse(decompressedLen);
                Array.Copy(rawbuf, buffer, decompressedLen);
            }
            else
            {
                int compressedLen = ReadResult();
                var compressedBuffer = ReadResponse(compressedLen);
                int pos = 0;
                for (int i = 0; i < compressedLen; i += 2)
                {
                    byte value = compressedBuffer[i];
                    int count = compressedBuffer[i + 1] & 0xFF;
                    ArrayFill.Fill(buffer, pos, pos + count, value);
                    pos += count;
                }
            }
            return decompressedLen;
        }

        private void WriteInternal(byte[] data, ulong offset, SwitchOffsetType type)
        {
            lock (_sync)
            {
                try
                {
                    Send(NoexsCommand.WriteMem(offset, (uint)data.Length));
                    var result = ReadResult();
                    if (result != 0)
                    {
                        throw new Exception($"err code: {result}");
                    }
                    Send(data);
                }
                finally
                {
                    ReadResult(); // ignore
                }

            }
        }
    }
}
