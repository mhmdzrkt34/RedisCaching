using ApiService.Models;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiService.Services.RedisService
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<List<Car>> GetListAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = await db.StringGetAsync(key);

            if (value.IsNullOrEmpty)
            {
                return null;
            }

            return JsonSerializer.Deserialize<List<Car>>(value);
        }

        public async Task SetListAsync(string key, List<Car> models)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = JsonSerializer.Serialize(models);
            await db.StringSetAsync(key, value);
        }
    }
}
