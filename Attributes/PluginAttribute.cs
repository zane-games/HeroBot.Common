using Discord.Commands;
using Discord.WebSocket;
using HeroBot.Common.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HeroBot.Common.Attributes
{
    public class PluginAttribute : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            // Check if this user is a Guild User, which is the only context where roles exist
            if (context.User is SocketGuildUser gUser)
            {
                var guild = ((IDatabaseService)services.GetService(typeof(IDatabaseService))).GetGuild(context.Guild.Id);
                if (guild != null)
                {
                    if (guild.EnabledPlugins.Where(x => x.Name == command.Module.Name).Count() > 0 || command.Module.IsSubmodule)
                    {
                        if (guild.DisabledCommands.Contains(command.Name))
                        {
                            return Task.FromResult(PreconditionResult.FromError("This command is disabled"));
                            
                        }
                        else return Task.FromResult(PreconditionResult.FromSuccess());
                    }
                    else
                    {
                        return Task.FromResult(PreconditionResult.FromError("This plugin is not enabled"));
                    }
                }
                else
                {
                    return Task.FromResult(PreconditionResult.FromError("I can't find you guild in my database"));
                }
            }
            else
                return Task.FromResult(PreconditionResult.FromSuccess());
        }
    }
}
