using Discord.Commands;
using HeroBot.Common.ExtendedModules;
using System.Collections.Generic;
using System.Reflection;

namespace HeroBot.Common.Interfaces
{
    public class AssemblyEntity
    {
        public Assembly Assembly { get; set; }
        public ModuleLoadContext Context { get; set; }
        public string Name { get; set; }
        public List<ModuleInfo> Module { get; set; }
        public IPluginRefferal pluginRefferal { get; set; }
    }
}