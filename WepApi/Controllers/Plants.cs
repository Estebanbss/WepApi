using Microsoft.AspNetCore.Mvc;
using WepApi.Models;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Plants : ControllerBase
    {
        [HttpGet]

        public string GetPlants()
        {
            return "Reading all the plants";
        }

        [HttpGet("{id}")]

        public string GetPlantById(int id)
        {
            return $"Reading plant {id}";
        }

        [HttpPost]

        public string CreatePlant([FromForm]Plant plant)
        {
            return $"Creating a plant";
        }

        [HttpPut("{id}")]
        public string UpdatePlant(int id)
        {
            return $"Updating plant: {id}";
        }

        [HttpDelete("{id}")]
        public string DeletePlant(int id)
        {
            return $"Delete plant: {id}";
        }

    }
}
