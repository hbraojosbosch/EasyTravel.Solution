using EasyTravel.Solution.Contracts.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace EasyTravel.Solution.Cache.Services
{
    public class RedisService : ICacheService
    {
        private readonly IDistributedCache _cache;
        public RedisService(IDistributedCache cache)
        {
            _cache = cache;
        }

        //public RedisService(IConnectionMultiplexer connectionMultiplexer)
        //{
        //    _connectionMultiplexer = connectionMultiplexer;
        //}

        //public async Task SetValueAsync(string key, string value)
        //{
        //    var database = _connectionMultiplexer.GetDatabase();
        //    await database.StringSetAsync(key, value);
        //}

        //public async Task<string> GetValueAsync(string key)
        //{
        //    var database = _connectionMultiplexer.GetDatabase();
        //    return await database.StringGetAsync(key);
        //}
        public async Task<string> GetValueAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }

        public async Task SetValueAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value);
        }
    }
}
