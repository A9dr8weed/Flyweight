using Newtonsoft.Json;

using System;

namespace Flyweight.Car
{
    /// <summary>
    /// The Flyweight stores a common portion of the state (also called intrinsic
    /// state) that belongs to multiple real business entities. The Flyweight
    /// accepts the rest of the state (extrinsic state, unique for each entity)
    /// via its method parameters.
    /// </summary>
    public class FlyweightCar
    {
        private readonly CarUnique _sharedState;

        public FlyweightCar(CarUnique car)
        {
            _sharedState = car;
        }

        public void Operation(CarUnique uniqueState)
        {
            string shared = JsonConvert.SerializeObject(_sharedState);
            string unique = JsonConvert.SerializeObject(uniqueState);

            Console.WriteLine($"Flyweight: Displaying shared {shared} and unique {unique} state.");
        }
    }
}