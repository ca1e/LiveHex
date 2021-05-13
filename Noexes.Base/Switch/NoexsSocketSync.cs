using SysBot.Base;
using System;
using System.Net.Sockets;
using System.Threading;

namespace Noexes.Base
{
    public sealed class NoexsSocketSync : SwitchSocket, INoexsConnectionSync
    {
        public NoexsSocketSync(IWirelessConnectionConfig cfg) : base(cfg) { }

        public override void Connect()
        {
            Log("Connecting to device...");
            //Connection.Connect(Info.IP, Info.Port);
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
        private int Send(byte[] buffer) => Connection.Send(buffer);

        private int ReadResult()
        {
            // give it time to push data back
            Thread.Sleep((MaximumTransferSize / DelayFactor) + BaseDelay);
            var buffer = new byte[4];
            var _ = Read(buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

        private readonly static object _sync = new();

        public ulong[] GetPids()
        {
            //lock (_sync)
            //{
            //}
            throw new System.NotImplementedException();
        }

        public ulong GetTitleID()
        {
            throw new System.NotImplementedException();
        }
    }
}
