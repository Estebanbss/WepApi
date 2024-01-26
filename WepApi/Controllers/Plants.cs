using Microsoft.AspNetCore.Mvc;
using WepApi.Filters;
using WepApi.Filters.ActionFilters;
using WepApi.Filters.ExceptionFilters;
using WepApi.Models;
using WepApi.Models.Repositories;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Plants : ControllerBase
    {
     

        [HttpGet]

        public IActionResult GetPlants()
        {
            return Ok(PlantRepository.GetPlants());
        }

        [HttpGet("{id}")]
        [Plant_ValidatePlantIdFilter]
        public IActionResult GetPlantById(int id)
        {


            return Ok(PlantRepository.GetPlantByID(id));
        }

        [HttpPost]
        [Plant_ValidatePlantExistingFilter]
        public IActionResult CreatePlant([FromBody] Plant plant)
        {

            PlantRepository.AddPlant(plant);

            return CreatedAtAction(nameof(GetPlantById),
                new {id= plant.PlantId},
                plant);
        }

        [HttpPut("{id}")]
        [Plant_ValidatePlantIdFilter]
        [Plant_ValidateUpdatePlantFilter]
        [Plant_HandleUpdtaeExceptionsFilter]
        public IActionResult UpdatePlant(int id, Plant plant)
        {

            PlantRepository.UpdatePlant(plant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Plant_ValidatePlantIdFilter]
        public IActionResult DeletePlant(int id)
        {
            var plant = PlantRepository.GetPlantByID(id);

            PlantRepository.DeletePlant(id);

            return Ok($"Delete plant: {id}");
        }

    }
}
