using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyweight.Car
{
    /// <summary>
    /// The Flyweight Factory creates and manages the Flyweight objects.
    /// It ensures that flyweights are shared correctly. When the client requests a
    /// flyweight, the factory either returns an existing instance or creates a
    /// new one, if it doesn't exist yet.
    /// </summary>
    public class FlyweightFactory
    {
        /// <summary>
        /// Collection of key, value.
        /// </summary>
        private readonly Dictionary<string, FlyweightCar> flyweights = new Dictionary<string, FlyweightCar>();

        /// <summary>
        /// Constructor in which add new elements to dictionary.
        /// </summary>
        /// <param name="car"></param>
        public FlyweightFactory(params CarUnique[] car)
        {
            foreach (CarUnique item in car)
            {
                flyweights.Add(GetKey(item), new FlyweightCar(item));
            }
        }

        /// <summary>
        /// Get key for dictionary.
        /// </summary>
        /// <param name="key"> Car unique elements. </param>
        /// <returns> Returns a Flyweight's string hash for a given state. </returns>
        public string GetKey(CarUnique key)
        {
            List<string> elements = new List<string>()
            {
                key.Model,
                key.Color,
                key.Company
            };

            if (key.Owner != null && key.Number != null)
            {
                elements.Add(key.Number);
                elements.Add(key.Owner);
            }

            elements.Sort();

            return string.Join("_", elements);
        }

        /// <summary>
        /// Get flyweight.
        /// </summary>
        /// <param name="sharedState"> Shared state. </param>
        /// <returns> Returns an existing Flyweight with a given state or creates a new one. </returns>
        public FlyweightCar GetFlyweight(CarUnique sharedState)
        {
            // Check if collections can't find a key, then create a new one object.
            if (!flyweights.Any(t => t.Key == GetKey(sharedState)))
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                flyweights.Add(GetKey(sharedState), new FlyweightCar(sharedState));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }

            return flyweights.FirstOrDefault(t => t.Key == GetKey(sharedState)).Value;
        }

        /// <summary>
        /// Display dictionary key.
        /// </summary>
        public void listFlyweights()
        {
            // Count element in dictionary.
            int count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");

            foreach (KeyValuePair<string, FlyweightCar> flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Key);
            }
        }
    }
}