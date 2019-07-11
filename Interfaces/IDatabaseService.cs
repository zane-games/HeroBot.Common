using HeroBot.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroBot.Common.Interfaces
{
    public interface IDatabaseService
    {
        Guild GetGuild(ulong id);
    }
}
