using SysBot.Base;
using System.Collections.Generic;

namespace Noexes.Base
{
    public interface INoexsConnectionSync : ISwitchConnectionSync
    {
        int Attach(ulong pid);

        void Resume();
        
        IEnumerable<ulong> GetPids();

        ulong GetTitleIdFromPid(ulong pid);
    }
}
