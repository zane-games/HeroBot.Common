using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroBot.Common.Interfaces
{
    public interface ICooldownService
    {
        Task<bool> IsModuleCooldowned(ulong userid,string moduleName);
        Task<bool> IsCommandCooldowned(ulong userid, string commandName);
    }
}
