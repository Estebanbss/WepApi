using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WepApi.Models;

namespace WepApi.Filters.ActionFilters
{
    public class Plant_ValidateUpdatePlantFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var plant = context.ActionArguments["plant"] as Plant;

            if (id.HasValue && plant != null && id != plant.PlantId)
            {
                context.ModelState.AddModelError("PlantId", "PlantId is not the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };

                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
