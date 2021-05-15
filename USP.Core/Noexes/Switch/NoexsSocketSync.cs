using SysBot.Base;
using System;
using System.Collections.Generic;
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
            Thread.Sleep(1);
            lock (_sync)
            {
                var buffer = new byte[4];
                var _ = Read(buffer);
                return BitConverter.ToInt32(buffer, 0);
            }
        }

        private void WaitForAvailable(int len)
        {
            while (Connection.Available < len) {; }
        }

        private byte[] ReadResponse(int length)
        {
            Thread.Sleep(1);
            lock (_sync)
            {
                var buffer = new byte[length];
                var _ = Read(buffer);
                return buffer;
            }
        }

        public IEnumerable<ulong> GetPids()
        {
            lock (_sync)
            {
                Send(NoexsCommand.GetPids());
                var count = ReadResult();
                var data = ReadResponse(count * 8);
                for(var i = 0; i<count; i++)
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
                var data = ReadResponse(8);
                return BitConverter.ToUInt64(data, 0);
            }
        }

        public ulong GetTitleId(ulong pid)
        {
            lock (_sync)
            {
                Send(NoexsCommand.GetTitleID(pid));
                var data = ReadResponse(8);
                return BitConverter.ToUInt64(data, 0);
            }
        }

        public int Attach(ulong pid)
        {
            lock (_sync)
            {
                Send(NoexsCommand.Attach(pid));
                return ReadResult();
            }
        }

        public ulong GetMainNsoBase()
        {
            throw new NotImplementedException();
        }

        public ulong GetHeapBase()
        {
            throw new NotImplementedException();
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
        public byte[] ReadBytesAbsolute(ulong offset, int length) => throw new NotImplementedException();

        public void WriteBytes(byte[] data, uint offset) => throw new NotImplementedException();
        public void WriteBytesMain(byte[] data, ulong offset) => throw new NotImplementedException();
        public void WriteBytesAbsolute(byte[] data, ulong offset) => throw new NotImplementedException();
    }
}
