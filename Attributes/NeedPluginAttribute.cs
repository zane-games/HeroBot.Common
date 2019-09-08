using Discord.Commands;
using HeroBot.Common.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HeroBot.Common.Attributes
{
    public class NeedPluginAttribute : PreconditionAttribute
    {

        public override async Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {

            // Get the databaseservices from the service provider
            var isP = await services.GetRequiredService<IModulesService>().IsPluginEnabled(context.Guild, ResolveMainModuleName(command.Module));
            if (!isP)
            {
                return PreconditionResult.FromError($"Plugin is not enabled on `{context.Guild}`");
            }
            return PreconditionResult.FromSuccess();
        }

        private ModuleInfo ResolveMainModuleName(ModuleInfo moduleInfo)
        {
            while (moduleInfo.IsSubmodule)
                moduleInfo = moduleInfo.Parent;
            return moduleInfo;
        }
    }
}
