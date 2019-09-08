using StackExchange.Redis;

namespace HeroBot.Common.Interfaces
{
    public interface IRedisService
    {
        ISubscriber GetSubscriber();
        IDatabaseAsync GetDatabase();
    }
}
