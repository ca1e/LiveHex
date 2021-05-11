using System;
using System.Collections.Generic;

namespace SysBot.Base
{
    public static class LogUtil
    {
        static LogUtil()
        {
        }

        // hook in here if you want to forward the message elsewhere???
        public static readonly List<Action<string, string>> Forwarders = new();

        public static void LogError(string message, string identity)
        {
            
        }

        public static void LogInfo(string message, string identity)
        {
            
        }
    }
}
