using ApiService.Responces.SeedingResponces;
using ApiService.Services.SeedingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeedingController : ControllerBase
    {


        private readonly ISeedingService _seedingService;


        public SeedingController(ISeedingService seedingService)
        {

            _seedingService = seedingService;
        }    
        [HttpPost]
        public async Task<IActionResult> seedDate()
        {

            try
            {

                SeedDataResponceBase responce = await _seedingService.seedDate();


                return StatusCode(responce.status, responce);


            }catch(Exception ex)
            {


                return StatusCode(500, new
                {

                    status=500,
                    message = "internal server error"
                });
            }




        }
    }
}
