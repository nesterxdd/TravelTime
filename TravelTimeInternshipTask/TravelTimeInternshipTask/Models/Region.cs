using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TravelTimeInternshipTask.Models
{
    public class Region
    {
        public string Name { get; }
        private List<Polygon> Coordinates;
        private List<Location> Locations;

        public Region()
        {
            Name = string.Empty;
            Coordinates = new List<Polygon>();
            Locations = new List<Location>();
        }

        public Region(string name, List<Polygon> Coordinates)
        {
            Name = name;
            this.Coordinates = Coordinates;
            Locations = new List<Location>();
        }

        public void AddLocation(Location location)
        {
            if (location.IsEmpty())
            {
                return;
            }
            else
            {
                Locations.Add(location);
            }
        }

        /// <summary>
        /// Checks if the location is inside of the region (inside one of the polygon of region)
        /// </summary>
        /// <param name="location">location parameter</param>
        /// <returns>Whether location is inside of a region</returns>
        public bool IsInRegion(Location location)
        {
            Coordinate coordinate = location.Coordinates;
            if (coordinate == null)
            {
                return false;
            }
            
            //loop through all of the polygons of the region and check whether the point is inside of any
            return Coordinates.Any(polygon => polygon.ContainsCoordinate(coordinate));
        }
    }
}
