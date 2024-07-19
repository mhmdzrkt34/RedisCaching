using ApiService.Data;
using ApiService.Models;
using ApiService.Responces.CarResponces;
using ApiService.Services.RedisService;
using System.Text.Json;


using Microsoft.EntityFrameworkCore;

namespace ApiService.Services.CarService
{
    public class CarService : ICarService
    {

        private readonly AppDbContext _context;

        private readonly IRedisService _redisService;






        public CarService(AppDbContext context,IRedisService redisService)
        {

            _context = context;
            _redisService = redisService;
        }
        public async Task<GetAllCarsResponceBase> GetAllCars()
        {
            try
            {

                List<Car> redisCars = await _redisService.GetListAsync("car-getallcars");

                if (redisCars == null)
                {

                    List<Car> cars = await _context.cars.ToListAsync();

                    await _redisService.SetListAsync("car-getallcars", cars);

                    return new GetAllCarsResponceFirst()
                    {
                        body = cars,

                        status = 200,
                        type = "success"


                    };
                }
                else
                {

                    return new GetAllCarsResponceFirst()
                    {

                        body = redisCars,

                        status = 200,
                        type = "success"
                    };



                }




            }catch(Exception ex)
            {

                throw;
            }
        }
    }
}
