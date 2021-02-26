using System;

namespace Flyweight
{
    /// <summary>
    /// ConcreteFlyweight: The concrete class of the shared flyweight.
    /// Implements an interface declared of type Flyweight and optionally adds internal state.
    /// Moreover, any state it maintains must be internal, independent of the context.
    /// </summary>
    public class PanelHouse : House
    {
        public PanelHouse()
        {
            _stages = 15;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine($"A panel house was built from {_stages} floors; coordinates: {latitude} latitude and {longitude} longitude");
        }
    }
}
