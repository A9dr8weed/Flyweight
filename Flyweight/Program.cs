using Flyweight.Car;

using System;

namespace Flyweight
{
    public static class Program
    {
        private static void Main()
        {
            // Fills factory elements.
            FlyweightFactory factory = new FlyweightFactory(
                new CarUnique { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new CarUnique { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new CarUnique { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new CarUnique { Company = "BMW", Model = "M5", Color = "red" },
                new CarUnique { Company = "BMW", Model = "X6", Color = "white" }
                );

            // Print all elements.
            factory.listFlyweights();

            addCarToDatabase(factory, new CarUnique
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            addCarToDatabase(factory, new CarUnique
            {
                Number = "CL234IR",
                Owner = "Bro Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            factory.listFlyweights();

            Console.ReadLine();

            double longitude = 37.61;
            double latitude = 55.74;

            HouseFactory houseFactory = new HouseFactory();

            for (int i = 0; i < 5; i++)
            {
                House panelHouse = houseFactory.GetHouse("Panel");

                panelHouse?.Build(longitude, latitude);

                longitude += 10;
                latitude += 10;
            }

            for (int i = 0; i < 5; i++)
            {
                House brickHouse = houseFactory.GetHouse("Brick");

                brickHouse?.Build(longitude, latitude);

                longitude += 10;
                latitude += 10;
            }

            Console.WriteLine($"Count of object: {houseFactory.TotalObjectsCreated}");
        }

        /// <summary>
        /// Try to add new element.
        /// </summary>
        /// <param name="factory"> Collection. </param>
        /// <param name="car"> Added element. </param>
        public static void addCarToDatabase(FlyweightFactory factory, CarUnique car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            // Checks if there is such an item in the collection.
            FlyweightCar flyweight = factory.GetFlyweight(new CarUnique
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            flyweight.Operation(car);
        }
    }
}