using System.ComponentModel.DataAnnotations;

namespace ApiService.Models
{
    public class Car
    {
        [Key]
        public string id {  get; set; }


        public string name { get; set; }

        public DateTime time {  get; set; }



        public Car()
        {


            id = Guid.NewGuid().ToString();

            time = DateTime.UtcNow;
        }
    }
}
