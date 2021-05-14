using SysBot.Base;
using System;

namespace Noexes.Base
{
    public record NoexsConnectionConfig : INoexsBotConfig, IWirelessConnectionConfig
    {
        public string IP { get; set; } = string.Empty;

        /// <inheritdoc/>
        public int Port { get; set; } = 7331;

        public INoexsConnectionSync CreateAsynchronous()
        {
            throw new NotImplementedException();
        }

        public INoexsConnectionSync CreateSync() => new NoexsSocketSync(this);
    }

    public interface INoexsBotConfig : IConsoleBotConnector<INoexsConnectionSync, INoexsConnectionSync>
    {
    }
}
