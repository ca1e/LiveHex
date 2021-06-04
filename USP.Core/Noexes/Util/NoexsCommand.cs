using System;
using System.Collections.Generic;

namespace Noexes.Base
{
    internal static class NoexsCommand
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

        public static byte[] Resume()
        {
            return GetCommands(NoexsCommandsEnum.Resume).ToArray();
        }

        public static byte[] Pause()
        {
            return GetCommands(NoexsCommandsEnum.Pause).ToArray();
        }

        public static byte[] Detach()
        {
            return GetCommands(NoexsCommandsEnum.Detach).ToArray();
        }

        public static byte[] Attach(ulong pid)
        {
            var cmd = GetCommands(NoexsCommandsEnum.Attach);
            cmd.AddRange(BitConverter.GetBytes(pid));
            return cmd.ToArray();
        }

        public static byte[] ReadMem(ulong offset, uint count)
        {
            var cmd = GetCommands(NoexsCommandsEnum.ReadMem);
            cmd.AddRange(BitConverter.GetBytes(offset));
            cmd.AddRange(BitConverter.GetBytes(count));
            return cmd.ToArray();
        }

        public static byte[] WriteMem(ulong offset, uint count)
        {
            var cmd = GetCommands(NoexsCommandsEnum.WriteMem);
            cmd.AddRange(BitConverter.GetBytes(offset));
            cmd.AddRange(BitConverter.GetBytes(count));
            return cmd.ToArray();
        }

        public static byte[] Query(long start, int max)
        {
            var cmd = GetCommands(NoexsCommandsEnum.QueryMemMulti);
            cmd.AddRange(BitConverter.GetBytes(start));
            cmd.AddRange(BitConverter.GetBytes(max));
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
