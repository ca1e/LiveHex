using SysBot.Base;
using System.Collections.Generic;

namespace USP.Core
{
    public static class CoreUtil
    {
        public static List<string> USBPort => USBUtil.GetList();

        public static Bot GetBot(string ip, int port, ProtocolType protocol = ProtocolType.WiFi)
        {
            var cfg = BotConfigUtil.GetConfig<BotConfig>(ip, port);
            
            if(protocol == ProtocolType.USB ) cfg.Protocol = SwitchProtocol.USB;

            var bot = new Bot(cfg);

            bot.Run();

            return bot;
        }
    }

    public enum ProtocolType // as SwitchProtocol
    {
        WiFi,
        USB,
    }
}
