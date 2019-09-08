using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace HeroBot.Common.Interfaces
{
    public interface IModulesService
    {
        Task DisablePlugin(IGuild guild, ModuleInfo moduleInfo);
        Task EnablePlugin(IGuild guild, ModuleInfo moduleInfo);
        AssemblyEntity GetAssemblyEntityByModule(ModuleInfo moduleInfo);
        Task<bool> IsPluginEnabled(IGuild guild, ModuleInfo moduleInfo);
    }
}
