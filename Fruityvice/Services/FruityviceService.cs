using Fruityvice.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fruityvice.Services
{
    public interface IFruitService
    {
        Task<Fruit[]> GetAllFruits();
        Task<Fruit[]> GetFruitsByFamily(string fruitFamily);
    }

    public class FruityviceService : IFruitService
    {
        private readonly ILogger<FruityviceService> _logger;

        // Static list of fruits with detailed information
        private static readonly Fruit[] Fruits = new[]
        {
            new Fruit
            {
                Id = 1,
                Name = "Apple",
                Family = "Rosaceae",
                Order = "Rosales",
                Genus = "Malus",
                Nutritions = new Nutritions { Calories = 52, Fat = 0.2f, Sugar = 10.39f, Carbohydrates = 13.81f, Protein = 0.26f }
            },
            new Fruit
            {
                Id = 2,
                Name = "Banana",
                Family = "Musaceae",
                Order = "Zingiberales",
                Genus = "Musa",
                Nutritions = new Nutritions { Calories = 96, Fat = 0.3f, Sugar = 12.23f, Carbohydrates = 22.84f, Protein = 1.3f }
            },
            new Fruit
            {
                Id = 3,
                Name = "Strawberry",
                Family = "Rosaceae",
                Order = "Rosales",
                Genus = "Fragaria",
                Nutritions = new Nutritions { Calories = 32, Fat = 0.3f, Sugar = 4.89f, Carbohydrates = 7.68f, Protein = 0.67f }
            },
            new Fruit
            {
                Id = 4,
                Name = "Persimmon",
                Family = "Ebenaceae",
                Order = "Rosales",
                Genus = "Diospyros",
                Nutritions = new Nutritions { Calories = 81, Fat = 0.0f, Sugar = 18.0f, Carbohydrates = 18.0f, Protein = 0.0f }
            },
            new Fruit
            {
                Id = 5,
                Name = "Papaya",
                Family = "Caricaceae",
                Order = "Caricales",
                Genus = "Carica",
                Nutritions = new Nutritions { Calories = 43, Fat = 0.3f, Sugar = 5.9f, Carbohydrates = 10.82f, Protein = 0.5f }
            },
            // Add more fruits as needed...
        };

        public FruityviceService(ILogger<FruityviceService> logger)
        {
            _logger = logger;
        }

        public Task<Fruit[]> GetAllFruits()
        {
            // Return the in-memory data
            return Task.FromResult(Fruits);
        }

        public async Task<Fruit[]> GetFruitsByFamily(string fruitFamily)
        {
            var fruitsByFamily = Fruits.Where(f => f.Family.Equals(fruitFamily, StringComparison.OrdinalIgnoreCase)).ToArray();
            return await Task.FromResult(fruitsByFamily);
        }
    }
}
