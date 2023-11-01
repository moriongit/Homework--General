using Indexer_task_2.Models;

namespace Indexer_task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gallery myGallery = new Gallery
            {
                Name = "My Car Gallery",
                Cars = new Car[]
            {
                new Car { Name = "Opel", Colour = "Red", ProducedYear = 2020 },
                new Car { Name = "Hyundai", Colour = "White", ProducedYear = 2021 },
                new Car { Name = "LADA", Colour = "Black", ProducedYear = 2019 }
            }
            };

            
            Console.WriteLine("Car at index 1: " + myGallery[1].Name);

            
            
            bool hasCarWithName = myGallery["Hyundai"];
            bool hasCarWithName2 = myGallery["Kia"];

            Console.WriteLine("Car 'Hyundai' exists: " + hasCarWithName);
            Console.WriteLine("Car 'Kia' exists: " + hasCarWithName2);



        }
    }
}