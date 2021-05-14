using Noexes.Base;
using SysBot.Base;
using System;

namespace USP.Core
{
    [Serializable]
    public sealed record SysBotConfig : SwitchConnectionConfig { }
    
    [Serializable]
    public sealed record NoexsConfig : NoexsConnectionConfig { }

    public sealed class SysBot : CoreBot<SysBotConfig> { public SysBot(SysBotConfig cfg) : base(cfg) { } }

    public sealed class NoexsBot : NoexsExecutor<NoexsConfig> { public NoexsBot(NoexsConfig cfg) : base(cfg) { } }

    public record ProcessInfo
    {
        public ulong MainBase { get; init; } = ulong.MinValue;
        public ulong HeepBase { get; init; } = ulong.MinValue;

        public ulong TitleId { get; init; } = ulong.MaxValue;
        public ulong BuildId { get; init; } = ulong.MaxValue;
    }
}
