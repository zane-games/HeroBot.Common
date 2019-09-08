using HeroBot.Common.Interfaces;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace HeroBot.Common
{
    public class SimpleCacheImplementation
    {
        private readonly IDatabaseAsync _redis;

        public SimpleCacheImplementation(IRedisService redisService)
        {
            _redis = redisService.GetDatabase();
        }
        public Task CacheValueAsync(string key, string value)
        {
            return _redis.StringSetAsync(key, value, TimeSpan.FromSeconds(120));
        }
        public async Task<RedisValue> GetValueAsync(string key)
        {
            if (await _redis.KeyExistsAsync(key))
                await _redis.KeyExpireAsync(key, TimeSpan.FromSeconds(120));
            return await _redis.StringGetAsync(key);
        }
        public Task InvalidateValueAsync(string key)
        {
            return _redis.KeyDeleteAsync(key);
        }

    }
}
