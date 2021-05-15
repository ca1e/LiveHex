using SysBot.Base;
using System.Collections.Generic;

namespace Noexes.Base
{
    public interface INoexsConnectionSync : ISwitchConnectionSync
    {
        IEnumerable<ulong> GetPids();

        ulong CurrentPid();

        ulong GetTitleId(ulong pid);

        int Attach(ulong pid);
    }
}
