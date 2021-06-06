using System.Linq;
using USP.Core;

namespace Noexes.Base
{
    public record MemoryInfo
    {
        public static int InfoSize = 24;

        public ulong Address { get; init; } = ulong.MinValue;
        public ulong Size { get; init; } = ulong.MinValue;
        public MemoryType Type { get; init; } = uint.MinValue;
        public uint Perm { get; init; } = uint.MinValue;

        public MemoryInfo(byte[] data)
        {
            Address = new ValueData(data.Take(8).ToArray(), ValueType.LONG).HumanValue;
            Size = new ValueData(data.Skip(8).Take(8).ToArray(), ValueType.LONG).HumanValue;
            Type = (MemoryType)new ValueData(data.Skip(16).Take(4).ToArray(), ValueType.INT).HumanValue;
            Perm = (uint)new ValueData(data.Skip(20).Take(4).ToArray(), ValueType.INT).HumanValue;
        }
    }

    public enum MemoryType
    {
        UNMAPPED = 0,
        IO = 0x01,
        NORMAL = 0x02,
        CODE_STATIC = 0x03,
        CODE_MUTABLE = 0x04,
        HEAP = 0x05,
        SHARED = 0x06,
        WEIRD_MAPPED = 0x07,
        MODULE_CODE_STATIC = 0x08,
        MODULE_CODE_MUTABLE = 0x09,
        IPC_BUFFER_0 = 0x0A,
        MAPPED = 0xB,
        THREAD_LOCAL = 0x0C,
        ISOLATED_TRANSFER = 0x0D,
        TRANSFER = 0x0E,
        PROCESS = 0x0F,
        RESERVED = 0x10,
        IPC_BUFFER_1 = 0x11,
        IPB_BUFFER_3 = 0x12,
        KERNEL_STACH = 0x13,
        CODE_READ_ONLY = 0x14,
        CODE_WRITABLE = 0x15
    }
}
