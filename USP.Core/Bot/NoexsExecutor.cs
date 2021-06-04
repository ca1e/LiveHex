using Noexes.Base;
using SysBot.Base;
using System.Collections.Generic;

namespace USP.Core
{
    public abstract class NoexsExecutor<T> : IExecutor, IRAMEditor where T : class, INoexsBotConfig
    {
        public readonly INoexsConnectionSync Connection;
        public readonly T Config;

        protected NoexsExecutor(IConsoleBotConnector<INoexsConnectionSync, INoexsConnectionSync> cfg)
        {
            Config = (T)cfg;
            Connection = cfg.CreateSync();
        }

        public void Run()
        {
            Connection.Connect();

            var result = Connection.Attach();
            System.Diagnostics.Debug.WriteLine($"[Attach] {result}");
            if(result == 0)
            {
                Connection.Resume();
            }
            else
            {
                throw new System.Exception($"err code: {result}");
            }
        }

        public IEnumerable<ulong> GetPids()
        {
            return Connection.GetPids();
        }

        public ProcessInfo GetInfo()
        {
            Connection.InitInfo();
            return new ProcessInfo
            {
                MainBase = Connection.GetMainNsoBase(),
                HeepBase = Connection.GetHeapBase(),
                TitleId = Connection.GetTitleID(),
                BuildId = Connection.GetBuildID()
            };
        }

        public byte[] Read(uint offset, int length) => Connection.ReadBytes(offset, length);
        public byte[] ReadMain(ulong offset, int length) => Connection.ReadBytesMain(offset, length);
        public byte[] ReadAbsolute(ulong offset, int length) => Connection.ReadBytesAbsolute(offset, length);
        public void Write(byte[] data, uint offset) => Connection.WriteBytes(data, offset);
        public void WriteMain(byte[] data, ulong offset) => Connection.WriteBytesMain(data, offset);
        public void WriteAbsolute(byte[] data, ulong offset) => Connection.WriteBytesAbsolute(data, offset);

        public ulong GetPointer(string evalStr)
        {
            var vars = new Dictionary<string, ulong>() { { "main", Connection.GetMainNsoBase() }, { "heap", Connection.GetHeapBase() } };
            var eval = new ExpressionEvaluator(vars, (ulong addr) => {
                var data = Connection.ReadBytesAbsolute(addr, 0x8);
                var realaddr = new ValueData(0x8, data);
                // Debug.WriteLine($"{realaddr.HumanValue:X}");
                return realaddr.HumanValue;
            });
            return eval.Eval(evalStr);
        }
    }
}
