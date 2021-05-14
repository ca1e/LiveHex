using SysBot.Base;
using System.Collections.Generic;

namespace Noexes.Base
{
    public abstract class NoexsExecutor<T> : INoexsExecutor where T : class, INoexsBotConfig
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
        }

        public IEnumerable<ulong> GetPids()
        {
            return Connection.GetPids();
        }

        public string GetTitleId(ulong pid)
        {
            return $"{Connection.GetTitleId(pid):X}";
        }

        public void Attach(ulong pid)
        {
            var code = Connection.Attach(pid);
        }
    }
}
