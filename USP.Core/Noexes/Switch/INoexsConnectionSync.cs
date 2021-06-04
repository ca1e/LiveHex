using SysBot.Base;
using System.Collections.Generic;

namespace Noexes.Base
{
    public interface INoexsConnectionSync : ISwitchConnectionSync
    {
        IEnumerable<ulong> GetPids();

        ulong GetTitleId(ulong pid);

        int Attach();

        void Resume();

        void InitInfo();
    }
}
