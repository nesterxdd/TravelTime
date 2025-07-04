using System.Drawing;

namespace TravelTimeInternshipTask.Models
{
    public class Polygon
    {
        private List<Coordinate> Coordinates;
        public Polygon()
        {
            Coordinates = new List<Coordinate>();
        }
        public Polygon(List<Coordinate> Coordinates)
        {
            this.Coordinates = Coordinates;
        }

        /// <summary>
        /// Check whether the coordinate is inside of polygon
        /// </summary>
        /// <param name="coordinate">coordinate variable</param>
        /// <returns>whether the coordinate is inside of polygon</returns>
        public bool ContainsCoordinate(Coordinate coordinate)
        {         
            bool inside = false;

            for (int i = 0; i < Coordinates.Count; i++)
            {
                //getting first point
                Coordinate c1 = Coordinates[i]; 
                // getting second point also includes the last point when i = 0 to get edge from end point to the first point
                Coordinate c2 = Coordinates[(i - 1 + Coordinates.Count) % Coordinates.Count]; 
               
                //check for the coordinate at the one of the vertex of the edge
                if (c1.X == coordinate.X && c1.Y == coordinate.Y)
                {
                    return true;
                }

                //check whether coordinate is on edge 
                if (IsOnEdge(coordinate, c1, c2))
                {
                    return true;
                }

                // | checks whether coordinate is between Y coordinates | checks what x should be to intersect the line if the x greater than initial x then it can intersect |
                if (((c1.Y > coordinate.Y) != (c2.Y > coordinate.Y)) && (coordinate.X < (c2.X - c1.X) * (coordinate.Y - c1.Y) / (c2.Y - c1.Y) + c1.X))
                {
                    inside = !inside; // in total if the number of intersection is odd (which means that the coordinate is inside of polygon) than inside variable will be true 
                }
            }

            return inside;
        }

        /// <summary>
        /// Algorithm to check whether a coordinate is on the edge
        /// </summary>
        /// <param name="coordinate">coordinate value</param>
        /// <param name="start">start coordinate</param>
        /// <param name="end">end coordinate</param>
        /// <returns>whether a coordinate is on the edge</returns>
        private bool IsOnEdge(Coordinate coordinate, Coordinate start, Coordinate end)
        {
            //checks if the coordinate is inside of the rectangular of start and end coordinates (simply takes maxs and mins of the coordinates and makes a rectangular)
            if (coordinate.X < Math.Min(start.X, end.X) || coordinate.X > Math.Max(start.X, end.X) || coordinate.Y < Math.Min(start.Y, end.Y) || coordinate.Y > Math.Max(start.Y, end.Y))
            {
                return false;
            }

            //cross product, if the result is 0 than coordinate is on the edge if its less than 0 its on the right of the edge if greater than 0 than its on the left of the edge
            double cross = (coordinate.Y - start.Y) * (end.X - start.X) - (coordinate.X - start.X) * (end.Y - start.Y);
            //taking abs value of the cross product and check if its 0(small value is used to accept close numbers to 0)
            return Math.Abs(cross) < 1e-10;
        }
    }
}
