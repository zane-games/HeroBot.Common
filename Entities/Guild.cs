using System;
using System.Collections.Generic;
using System.Text;

namespace HeroBot.Common.Entities
{
    public class Guild
    {
        public ulong Id { get; set; }
        public List<Plugin> EnabledPlugins { get; set; }
        public string[] DisabledCommands { get; set; }
    }
}
