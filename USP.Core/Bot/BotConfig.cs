using SysBot.Base;
using System;

namespace USP.Core
{
    [Serializable]
    public sealed record BotConfig : SwitchConnectionConfig { }

    public sealed class SysBot : CoreBot<BotConfig> { public SysBot(BotConfig cfg) : base(cfg) { } }

    public record ProcessInfo
    {
        public ulong MainBase { get; init; } = ulong.MinValue;
        public ulong HeepBase { get; init; } = ulong.MinValue;

        public ulong TitleId { get; init; } = ulong.MaxValue;
        public ulong BuildId { get; init; } = ulong.MaxValue;
    }
}
