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
