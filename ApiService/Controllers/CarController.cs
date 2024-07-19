using ApiService.Responces.CarResponces;
using ApiService.Services.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {

            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCars()
        {


            try
            {

                GetAllCarsResponceBase responce = await _carService.GetAllCars();


                return StatusCode(responce.status, responce);

               

            }catch(Exception ex)
            {


                return StatusCode(500, new
                {

                    status = 500,
                    body = new
                    {

                        message = ex.Message
                    }
                });
            }
        }
    }
}
