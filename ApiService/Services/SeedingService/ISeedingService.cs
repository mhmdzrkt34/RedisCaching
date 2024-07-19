using ApiService.Responces.SeedingResponces;

namespace ApiService.Services.SeedingService
{
    public interface ISeedingService
    {

        public Task<SeedDataResponceBase> seedDate();
    }
}
