using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Noexes.Base
{
    public sealed class NoexsSocketSync : NoexsSocket, INoexsConnectionSync
    {
        public NoexsSocketSync(IWirelessConnectionConfig cfg) : base(cfg) { }

        /// <summary>
        /// wrapper above
        /// </summary>
        int INoexsConnectionSync.Attach(ulong pid)
        {
            Log($"[PID] Current pid: {CurrentPid()}");
            Log($"[PID] Attached pid: {AttachedPid()}");
            return Attach(pid);
        }

        void INoexsConnectionSync.Resume() => Resume();

        private ulong Main_ = ulong.MinValue;
        private ulong Heap_ = ulong.MinValue;

        private void InitInfo()
        {
            var mi = QueryMulti(0, 1000);
            //var mainm = mi.Where(m=>m.GetMemType() == MemoryType.CODE_STATIC && m.Perm == 0b101).Skip(1).First();
            //var heapm = mi.Where(m => m.GetMemType() == MemoryType.HEAP).OrderBy(m=>m.Address).First();

            int moduleCount = 0;
            foreach (var m in mi)
            {
                if (m.GetMemType() == MemoryType.CODE_STATIC && m.Perm == 0b101)
                {
                    moduleCount++;
                }
            }
            var mod = 0;
            var heapB = false;
            foreach (var m in mi)
            {
                if (!heapB && m.GetMemType() == MemoryType.HEAP)
                {
                    heapB = true;
                    Heap_ = m.Address;
                    continue;
                }
                if (m.GetMemType() == MemoryType.CODE_STATIC && m.Perm == 0b101)
                {
                    if (mod == 0 && moduleCount == 1)
                    {
                        Main_ = m.Address;
                        continue;
                    }
                    if (moduleCount > 1)
                    {
                        if(mod == 1)
                        {
                            Main_ = m.Address;
                            continue;
                        }
                    }
                    mod++;
                }
            }
        }

        public ulong GetMainNsoBase()
        {
            if (Main_ == ulong.MinValue) InitInfo();
            return Main_;
        }

        public ulong GetHeapBase()
        {
            if (Heap_ == ulong.MinValue) InitInfo();
            return Heap_;
        }

        IEnumerable<ulong> INoexsConnectionSync.GetPids() => ListPids();

        ulong INoexsConnectionSync.GetTitleIdFromPid(ulong pid) => GetTitleId(pid);

        public ulong GetTitleID() => GetTitleId(AttachedPid());

        public ulong GetBuildID() => ulong.MaxValue;

        private byte[] ReadInternal(ulong offset, int length, SwitchOffsetType type)
        {
            return type switch
            {
                SwitchOffsetType.Heap => ReadMem(Heap_ + offset, length),
                SwitchOffsetType.Main => ReadMem(Main_ + offset, length),
                SwitchOffsetType.Absolute => ReadMem(offset, length),
                _ => throw new NotImplementedException(),
            };
        }

        public byte[] ReadBytes(uint offset, int length) => ReadInternal(offset, length, SwitchOffsetType.Heap);
        public byte[] ReadBytesMain(ulong offset, int length) => ReadInternal(offset, length, SwitchOffsetType.Main);
        public byte[] ReadBytesAbsolute(ulong offset, int length) => ReadInternal(offset, length, SwitchOffsetType.Absolute);
        public void WriteBytes(byte[] data, uint offset) => WriteMem(data, Heap_ + offset);
        public void WriteBytesMain(byte[] data, ulong offset) => WriteMem(data, Main_ + offset);
        public void WriteBytesAbsolute(byte[] data, ulong offset) => WriteMem(data, offset);
    }
}
