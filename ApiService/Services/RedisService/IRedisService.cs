using ApiService.Models;

namespace ApiService.Services.RedisService
{
    public interface IRedisService
    {
        Task<List<Car>> GetListAsync(string key);
        Task SetListAsync(string key, List<Car> models);
    }

}
