namespace Flyweight
{
    /// <summary>
    /// The Flyweight enables sharing but it does not enforce it.
    /// The concrete objects which implement this interface either be shared or unshared.
    /// </summary>
    public abstract class House
    {
        /// <summary>
        /// Number of stages.
        /// </summary>
        protected int _stages;

        public abstract void Build(double longitude, double latitude);
    }
}