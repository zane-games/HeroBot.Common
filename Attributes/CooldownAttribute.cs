using Discord.Commands;
using HeroBot.Common.Helpers;
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
            TimeSpan? cmdCool = await _cooldown.IsCommandCooldowned(context.User.Id, command.Name);
            if (cmdCool.HasValue)
            {
                return PreconditionResult.FromError($"This command is cooldowned, please, wait {cmdCool.Value.ToHumanReadable()}");
            }
            TimeSpan? mCool = await _cooldown.IsModuleCooldowned(context.User.Id, command.Module.Name);
            if (mCool.HasValue)
            {
                return PreconditionResult.FromError($"This module is cooldowned, please, wait {mCool.Value.ToHumanReadable()}");
            }
            return PreconditionResult.FromSuccess();
        }
    }
}
