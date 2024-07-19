using ApiService.Models;

namespace ApiService.Responces.CarResponces
{
    public class GetAllCarsResponceFirst:GetAllCarsResponceBase
    {

        public List<Car> body { get; set; }

        public int status {  get; set; }



        public string type { get; set; }
    }
}
