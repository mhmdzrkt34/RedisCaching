using ApiService.Responces.CarResponces;

namespace ApiService.Services.CarService
{
    public interface ICarService
    {

        public Task<GetAllCarsResponceBase> GetAllCars();
    }
}
