using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WepApi.Models.Repositories;

namespace WepApi.Filters.ActionFilters
{
    public class Plant_ValidatePlantIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var plantId = context.ActionArguments["id"] as int?;

            if (plantId.HasValue)
            {
                if (plantId.Value <= 0)
                {
                    context.ModelState.AddModelError("PlantId", "PlantId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!PlantRepository.PlantExist(plantId.Value))
                {
                    context.ModelState.AddModelError("PlantId", "Plant doesnt exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };

                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
