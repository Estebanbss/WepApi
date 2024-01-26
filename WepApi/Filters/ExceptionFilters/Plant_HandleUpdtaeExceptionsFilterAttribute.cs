using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WepApi.Models.Repositories;

namespace WepApi.Filters.ExceptionFilters
{
    public class Plant_HandleUpdtaeExceptionsFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strPlantId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strPlantId, out int PlantId))
            {
                if (!PlantRepository.PlantExist(PlantId))
                {
                    context.ModelState.AddModelError("PlantId", "Plant doesnt exist anymore");
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
