using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroBot.Common.Interfaces
{
    public interface IRedisService
    {
        ISubscriber GetSubscriber();
        IDatabaseAsync GetDatabase();
    }
}
