using SysBot.Base;
using System;
using System.Collections.Generic;

namespace Noexes.Base
{
    public abstract class NoexsSocket : NoexsConnection
    {
        public NoexsSocket(IWirelessConnectionConfig cfg) : base(cfg) { }

        private readonly static object _sync = new();

        private void ResultCheck()
        {
            var result = ReadResult();
            if (result != 0)
            {
                throw new ResultException(result);
            }
        }

        private MemoryInfo ReadInfo()
        {
            lock (_sync)
            {
                WaitForAvailable(MemoryInfo.InfoSize);
                var raw = ReadResponse(MemoryInfo.InfoSize);
                var info = new MemoryInfo(raw);
                //var addr = ReadLong();
                //var size = ReadLong();
                //var type = ReadInt();
                //var perm = ReadInt();

                ResultCheck();

                return info;
                //return new MemoryInfo { Address = addr, Size = size, Type = type, Perm = perm };
            }
        }

        #region Noexs functions
        protected byte[] ReadMem(ulong offset, int length)
        {
            lock (_sync)
            {
                try
                {
                    Send(NoexsCommand.ReadMem(offset, (uint)length));
                    ResultCheck();

                    var bytes = new byte[length];
                    int pos = 0;
                    var buffer = new byte[2048 * 4];

                    while (pos < length)
                    {
                        ResultCheck();

                        int len = ReadCompressed(ref buffer);
                        Array.Copy(buffer, 0, bytes, pos, len);
                        pos += len;
                    }

                    return bytes;
                }
                finally
                {
                    ReadResult(); // ignore
                }
            }
        }

        protected int ReadCompressed(ref byte[] buffer)
        {
            var compressedFlag = ReadByte();
            var decompressedLen = ReadResult();

            if (compressedFlag == 0)
            {
                var rawbuf = ReadResponse(decompressedLen);
                Array.Copy(rawbuf, buffer, decompressedLen);
            }
            else
            {
                int compressedLen = ReadResult();
                var compressedBuffer = ReadResponse(compressedLen);
                int pos = 0;
                for (int i = 0; i < compressedLen; i += 2)
                {
                    byte value = compressedBuffer[i];
                    int count = compressedBuffer[i + 1] & 0xFF;
                    ArrayUtil.Fill(buffer, pos, pos + count, value);
                    pos += count;
                }
            }
            return decompressedLen;
        }

        protected void WriteMem(byte[] data, ulong offset)
        {
            lock (_sync)
            {
                try
                {
                    Send(NoexsCommand.WriteMem(offset, (uint)data.Length));

                    ResultCheck();

                    Send(data);
                }
                finally
                {
                    ReadResult(); // ignore
                }

            }
        }

        protected void Resume() => SendReadResult(NoexsCommand.Resume());

        protected void Pause() => SendReadResult(NoexsCommand.Pause());

        protected int Attach(ulong pid)
        {
            lock (_sync)
            {
                Send(NoexsCommand.Attach(pid));
                return ReadResult();
            }
        }

        protected void Detach() => SendReadResult(NoexsCommand.Detach());

        protected MemoryInfo[] QueryMulti(long start, int max)
        {
            lock (_sync)
            {
                Send(NoexsCommand.QueryMulti(start, max));
                var res = new List<MemoryInfo>();
                int count = 0;
                for (count = 0; count < max; count++)
                {
                    var info = ReadInfo();
                    if (info.Type == MemoryType.RESERVED)
                    {
                        break;
                    }
                    res.Add(info);
                }
                ReadResult();
                return res.ToArray();
            }
        }

        protected ulong CurrentPid()
        {
            lock (_sync)
            {
                Send(NoexsCommand.CurrentPid());
                var cpid = ReadLong();
                var r = ReadResult();
                if (r != 0) cpid = 0;
                return cpid;
            }
        }

        protected ulong AttachedPid()
        {
            lock (_sync)
            {
                Send(NoexsCommand.AttachedPid());
                var caid = ReadLong();
                var rc = ReadResult();
                if (rc != 0) throw new ImpossibleException(rc);
                return caid;
            }
        }

        protected IEnumerable<ulong> ListPids()
        {
            lock (_sync)
            {
                Send(NoexsCommand.ListPids());
                var count = ReadResult();
                var data = ReadResponse(count * 8);
                ReadResult();
                for (var i = 0; i < count; i++)
                {
                    yield return BitConverter.ToUInt64(data, i * 8);
                }
            }
        }

        protected ulong GetTitleId(ulong pid)
        {
            lock (_sync)
            {
                Send(NoexsCommand.GetTitleID(pid));
                var tid = ReadLong();
                ReadResult();
                return tid;
            }
        }

        protected void Search(ulong start, ulong end, ulong value, uint searchsize)
        {
            // TODO
            lock (_sync)
            {
                // search type  _8, _16, _32, _64 
                Send(NoexsCommand.SearchLocal(start, end, value, value, searchsize, 0));
                var compressedLen = ReadResult();
                if (compressedLen != 0)
                {
                    var zipbuf = ReadResponse(compressedLen);
                }
                var rc = ReadResult();
                if (rc != 0) throw new ImpossibleException(rc);
            }
        }
        #endregion
    }
}
