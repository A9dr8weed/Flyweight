using System;

namespace Flyweight
{
    public class BrickHouse : House
    {
        public BrickHouse()
        {
            _stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine($"A panel house was built from {_stages} floors; coordinates: {latitude} latitude and {longitude} longitude");
        }
    }
}