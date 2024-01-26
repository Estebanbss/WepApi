using Microsoft.AspNetCore.Http.HttpResults;
using WepApi.Controllers;

namespace WepApi.Models.Repositories
{
    public class PlantRepository
    {

        private static List<Plant> plants = new List<Plant>()
        {
            // instancia 1
            new Plant {PlantId = 1, Color = "Green", Height = 2, Name = "Lettuce"},
            // Instancia 2
            new Plant { PlantId = 2, Color = "Red", Height = 3, Name = "Tomato" },

            // Instancia 3
            new Plant { PlantId = 3, Color = "Yellow", Height = 4, Name = "Sunflower" },

            // Instancia 4
            new Plant { PlantId = 4, Color = "Purple", Height = 5, Name = "Lavender" },

            // Instancia para fresas
            new Plant { PlantId = 5, Color = "Red", Height = 3, Name = "Strawberry" },
        };

        public static List<Plant> GetPlants()
        {
            return plants;
        }
        public static bool PlantExist(int id)
        {
            return plants.Any(x => x.PlantId == id);
        }

        public static Plant? GetPlantByID(int id)
        {
            return plants.FirstOrDefault(X => X.PlantId == id);
        }

        public static Plant? GetPlantByProperties(int? height, string? name, string? type, string? color)
        {
            return plants.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(name) &&
            !string.IsNullOrWhiteSpace(x.Name) &&
            x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
             !string.IsNullOrWhiteSpace(type) &&
            !string.IsNullOrWhiteSpace(x.Type) &&
            x.Type.Equals(type, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            height.HasValue &&
            x.Height.HasValue &&
            height.Value == x.Height.Value);

        }

        public static void AddPlant(Plant plant)
        {
            int maxId = plants.Max(x => x.PlantId);
            plant.PlantId = maxId + 1;
            plants.Add(plant);
        }

        public static void UpdatePlant(Plant plant)
        {
            var plantToUpdate = plants.First(x => x.PlantId == plant.PlantId);
            plantToUpdate.Name = plant.Name;
            plantToUpdate.Price = plant.Price;
            plantToUpdate.Color = plant.Color;
            plantToUpdate.Height = plant.Height;
            plantToUpdate.Type = plant.Type;
        }

        public static void DeletePlant(int PlantId)
        {
            var plant = GetPlantByID(PlantId);
            if(plant != null)
            {
                plants.Remove(plant);
            }
        }
    }
}
