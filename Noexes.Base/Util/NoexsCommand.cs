using System;
using System.Collections.Generic;

namespace Noexes.Base.Util
{
    public static class NoexsCommand
    {
        private static List<byte> GetCommands(NoexsCommandsEnum cmd) => new() { (byte)cmd };

        public static byte[] GetPids()
        {
            return GetCommands(NoexsCommandsEnum.ListPids).ToArray();
        }

        public static byte[] GetCurrentPid()
        {
            return GetCommands(NoexsCommandsEnum.CurrentPid).ToArray();
        }

        public static byte[] Attach(ulong pid)
        {
            var cmd = GetCommands(NoexsCommandsEnum.ListPids);
            cmd.AddRange(BitConverter.GetBytes(pid));
            return cmd.ToArray();
        }

        public static byte[] ReadMem(ulong offset, int count)
        {
            var cmd = GetCommands(NoexsCommandsEnum.GetTitleId);
            cmd.AddRange(BitConverter.GetBytes(offset));
            cmd.AddRange(BitConverter.GetBytes(count));
            return cmd.ToArray();
        }

        public static byte[] GetTitleID(ulong pid)
        {
            var cmd = GetCommands(NoexsCommandsEnum.GetTitleId);
            cmd.AddRange(BitConverter.GetBytes(pid));
            return cmd.ToArray();
        }
    }
}
