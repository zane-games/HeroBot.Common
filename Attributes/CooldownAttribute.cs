using Discord.Commands;
using HeroBot.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace HeroBot.Common.Attributes
{
    public class CooldownAttribute : PreconditionAttribute
    {
        public static ICooldownService _cooldown;

        public TimeSpan cooldown;

        public CooldownAttribute(int seconds) { cooldown = TimeSpan.FromSeconds(seconds); }

        public override async Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (!await _cooldown.IsModuleCooldowned(context.User.Id, command.Module.Name)) {
                if (!await _cooldown.IsCommandCooldowned(context.User.Id, command.Name)) {
                    return PreconditionResult.FromSuccess();
                }
                return PreconditionResult.FromError($"Command cooldowned");
            }
            return PreconditionResult.FromError("Module cooldowned");
        }
    }
}
