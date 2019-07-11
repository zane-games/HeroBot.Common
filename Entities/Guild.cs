using System;
using System.Collections.Generic;
using System.Text;

namespace HeroBot.Common.Entities
{
    public class Guild
    {
        public ulong Id;
        public List<Plugin> EnabledPlugins;
        public string[] DisabledCommands;
    }
}
