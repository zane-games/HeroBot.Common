using Discord.Commands;
using HeroBot.Common.ExtendedModules;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HeroBot.Common.Entities
{
    public sealed class ContextEntity
    {
        public string Name { get; set; }
        public ModuleInfo Module { get; set; }
        public Assembly Assembly { get; set; }
        public ModuleLoadContext Context { get; set; }
    }
}
