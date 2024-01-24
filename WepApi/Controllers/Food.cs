using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [ApiController]
    public class Food: ControllerBase
    {
        [HttpGet]
        [Route("/food")]
        public string GetFood()
        {
            return "Return all the food";
        }

    }
}
