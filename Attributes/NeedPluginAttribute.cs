using Discord.Commands;
using Discord.WebSocket;
using HeroBot.Common.Entities;
using HeroBot.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroBot.Common.Attributes
{
    public class NeedPluginAttribute : PreconditionAttribute
    {

        public static IDatabaseService databaseService;

        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            // Check if this user is a Guild User, which is the only context where roles exist
            if (context.User is SocketGuildUser gUser)
            {
                    Console.WriteLine(context.Guild.Id);
                    var guildService = databaseService;
                    var guild = guildService.GetGuilds(context.Guild.Id).First();
                    if (guild != null)
                    {
                        if (guild.EnabledPlugins.Where(x => x.Name == command.Module.Name).Count() > 0)
                        {
                            return Task.FromResult(PreconditionResult.FromSuccess());
                        }
                        else
                        {
                            if (command.Module.IsSubmodule)
                            {
                                if (CheckSubModule(guild, command.Module))
                                {
                                    return Task.FromResult(PreconditionResult.FromSuccess());
                                }
                            }
                            return Task.FromResult(PreconditionResult.FromError("Plugin not enabled"));
                        }
                    }
                    else return Task.FromResult(PreconditionResult.FromError("Can't find your guild in the database"));
            }
            return Task.FromResult(PreconditionResult.FromSuccess());
        }

        private bool CheckSubModule(Guild guild, ModuleInfo module)
        {
            // Resolving the submodule
            var resolvedModule = module;
            while (resolvedModule.IsSubmodule)
                resolvedModule = resolvedModule.Parent;
            return guild.EnabledPlugins.Where(x => x.Name == resolvedModule.Name).Count() > 0;
        }
    }
}
