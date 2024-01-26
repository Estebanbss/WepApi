using System.ComponentModel.DataAnnotations;
using WepApi.Models.Validations;

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

        [Plant_EnsureCorrectHighAtrribute]
        public int? Height { get; set; }
        public double? Price { get; set; }


    }
}
