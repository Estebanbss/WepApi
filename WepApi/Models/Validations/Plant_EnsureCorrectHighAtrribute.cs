using System.ComponentModel.DataAnnotations;

namespace WepApi.Models.Validations
{
    public class Plant_EnsureCorrectHighAtrribute: ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var plant = validationContext.ObjectInstance as Plant;

            if (plant != null && !string.IsNullOrWhiteSpace(plant?.Name))
            {
                if (plant.Name.Equals("lettuce", StringComparison.OrdinalIgnoreCase) && plant.Height < 2)
                {
                    return new ValidationResult("For lettuce, the size has to be greather or equal to 1");
                }
                else if (plant.Name.Equals("strawberry", StringComparison.OrdinalIgnoreCase) && plant.Height < 3)
                {
                    return new ValidationResult("For strawberry, the size has to be greather or equal to 2");
                }
            }      
                    return ValidationResult.Success;
               
            
        }
    }
}
