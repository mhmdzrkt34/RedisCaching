
using ApiService.Data;
using ApiService.Responces.SeedingResponces;

using ApiService.Models;

namespace ApiService.Services.SeedingService
{
    public class SeedingService : ISeedingService
    {

        private readonly AppDbContext _context;


        public SeedingService(AppDbContext context)
        {


            _context = context;
        }
        public async Task<SeedDataResponceBase> seedDate()
        {
            try
            {

                for (int i = 0; i < 1000; i++)
                {


                    _context.cars.Add(new Car()
                    {


                        name = $"car{i.ToString()}"


                    });
                }

                await _context.SaveChangesAsync();

                return new SeedingResponceFirst()
                {

                    status = 200,
                    body="seeded succesfully",
                    type="success"
  
                };

                
            }catch(Exception ex)
            {


                throw;



            }
        }
    }
}
