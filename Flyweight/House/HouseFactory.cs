using System.Collections.Generic;

namespace Flyweight
{
    /// <summary>
    /// Flyweight Factory: Flyweight Factory - Creates shared flyweight objects.
    /// </summary>
    public class HouseFactory
    {
        /// <summary>
        /// All created objects are stored in a pool.
        /// </summary>
        private readonly Dictionary<string, House> houses = new Dictionary<string, House>();

        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());
        }

        public int TotalObjectsCreated => houses.Count;

        /// <summary>
        /// Returns an existing Flyweight with a given state.
        /// </summary>
        /// <param name="key"> Key in dictionary. </param>
        public House GetHouse(string key)
        {
            if (houses.ContainsKey(key))
            {
                return houses[key];
            }

            return null;
        }
    }
}