using HeroBot.Common.Entities;
using System;
using System.Collections.Generic;

namespace HeroBot.Common.Interfaces
{
    public interface IDatabaseService
    {
        List<Guild> GetGuilds(ulong id);
        Guild GetGuild(ulong id);
        Guild EditGuild(ulong id, Func<Guild, Guild> editfunction);
    }
}
