using HeroBot.Common.Entities;
using System;

namespace HeroBot.Common.Interfaces
{
    public interface IDatabaseService
    {
        Guild GetGuild(ulong id);
        Guild EditGuild(ulong id, Func<Guild, Guild> editfunction);
    }
}
