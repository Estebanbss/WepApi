using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WepApi.Models;
using WepApi.Models.Repositories;

namespace WepApi.Filters.ActionFilters
{
    public class Plant_ValidatePlantExistingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var plant = context.ActionArguments["plant"] as Plant;

            if (plant == null)
            {
                context.ModelState.AddModelError("Plant", "Plant object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {


                var existingPlant = PlantRepository.GetPlantByProperties(plant?.Height, plant?.Name, plant?.Type, plant?.Color);

                if (existingPlant != null)
                {
                    context.ModelState.AddModelError("Plant", "Plant already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }


        }
    }
}
