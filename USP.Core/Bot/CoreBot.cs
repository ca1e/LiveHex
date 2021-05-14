using Noexes.Base;
using SysBot.Base;
using System.Collections.Generic;

namespace USP.Core
{
    public abstract class CoreBot<T> : INoexsExecutor, IRAMEditor where T : class, IConsoleBotConfig
    {
        public readonly ISwitchConnectionSync SwitchConnection;
        public readonly T Config;

        protected CoreBot(IConsoleBotManaged<ISwitchConnectionSync, IConsoleConnectionAsync> cfg)
        {
            Config = (T)cfg;
            SwitchConnection = cfg.CreateSync();
        }

        public void Run()
        {
            SwitchConnection.Connect();
        }

        public ProcessInfo GetInfo()
        {
            return new ProcessInfo{ MainBase = SwitchConnection.GetMainNsoBase(), HeepBase = SwitchConnection.GetHeapBase(),
                TitleId = SwitchConnection.GetTitleID(), BuildId = SwitchConnection.GetBuildID()
            };
        }

        public byte[] Read(uint offset, int length) => SwitchConnection.ReadBytes(offset, length);
        public byte[] ReadMain(ulong offset, int length) => SwitchConnection.ReadBytesMain(offset, length);
        public byte[] ReadAbsolute(ulong offset, int length) => SwitchConnection.ReadBytesAbsolute(offset, length);
        public void Write(byte[] data, uint offset) => SwitchConnection.WriteBytes(data, offset);
        public void WriteMain(byte[] data, ulong offset) => SwitchConnection.WriteBytesMain(data, offset);
        public void WriteAbsolute(byte[] data, ulong offset) => SwitchConnection.WriteBytesAbsolute(data, offset);

        public ulong GetPointer(string evalStr)
        {
            var vars = new Dictionary<string, ulong>() { { "main", SwitchConnection.GetMainNsoBase() }, { "heap", SwitchConnection.GetHeapBase() } };
            var eval = new ExpressionEvaluator(vars, (ulong addr) => {
                var data = SwitchConnection.ReadBytesAbsolute(addr, 0x8);
                var realaddr = new ValueData(0x8, data);
                return realaddr.HumanValue;
            });
            return eval.Eval(evalStr);
        }
    }
}
