using System;
using System.Threading.Tasks;

namespace HeroBot.Common.Interfaces
{
    public interface ICooldownService
    {
        Task<TimeSpan?> IsModuleCooldowned(ulong userid, string moduleName);
        Task<TimeSpan?> IsCommandCooldowned(ulong userid, string commandName);
    }
}
