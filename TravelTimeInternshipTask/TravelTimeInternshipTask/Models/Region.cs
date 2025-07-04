using System.Collections.Generic;

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

        //public bool IsInRegion(Location location)
        //{
        //    for (int i = 0; i < Coordinates.Count; i++)
        //    {
        //        int intersectCount = 0;
        //        for (int j = 0; j < Coordinates[i].Count ; j++)
        //        {
        //            List<double> c1 = Coordinates[i][j];
        //            List<double> c2 = Coordinates[i][(j+1) % Coordinates[i].Count];

        //            bool intersect = (c1[1] > location.Coordinates[1]) != (c2[1] > location.Coordinates[1]) && (location.Coordinates[0] < (c2[0] - c1[0]) * (location.Coordinates[1] - c1[1]) / (c2[1] - c1[1] + 0.00000000000000000001) + c1[0]);
        //            //bool intersect = (c1.Y > location.Coordinates.Y) != (c2.Y > location.Coordinates.Y) && (location.Coordinates.X < (c2.X - c1.X) * (location.Coordinates.Y - c1.Y) / (c2.Y - c1.Y + 0.1m) + c1.X);

        //            if (intersect)
        //            {
        //                intersectCount++;
        //            }

        //        }
        //        if (intersectCount % 2 != 0)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;

        //}

        public bool IsInRegion(Location location)
        {
            Coordinate coordinate = location.Coordinates;
            if (coordinate == null)
            {
                return false;
            }
               
            return Coordinates.Any(polygon => polygon.ContainsPoint(coordinate));
        }


    }
}
