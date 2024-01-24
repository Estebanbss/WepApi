using System.ComponentModel.DataAnnotations;

namespace WepApi.Models
{
    public class Plant
    {
        [Required]
        public int PlantId { get; set; }
        public string? Type { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public string? Name { get; set; }
   
        public int? Height { get; set; }
        public double? Price { get; set; }


    }
}
