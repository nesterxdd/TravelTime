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
        public Coordinate GetCoordinate(int i)
        {
            return Coordinates[i];
        }

        public bool ContainsPoint(Coordinate coordinate)
        {
            bool inside = false;

            for (int i = 0, j = Coordinates.Count - 1; i < Coordinates.Count; j = i++)
            {
                Coordinate c1 = Coordinates[i];
                Coordinate c2 = Coordinates[j];

                if (c1.X == coordinate.X && c1.Y == coordinate.Y)
                {
                    return true;
                }

                if (IsOnEdge(coordinate, c1, c2))
                {
                    return true;
                }

                if (((c1.Y > coordinate.Y) != (c2.Y > coordinate.Y)) && (coordinate.X < (c2.X - c1.X) * (coordinate.Y - c1.Y) / (c2.Y - c1.Y) + c1.X))
                {
                    inside = !inside;
                }
            }

            return inside;
        }

        private bool IsOnEdge(Coordinate coordinate, Coordinate start, Coordinate end)
        {
            if (coordinate.X < Math.Min(start.X, end.X) || coordinate.X > Math.Max(start.X, end.X) || coordinate.Y < Math.Min(start.Y, end.Y) || coordinate.Y > Math.Max(start.Y, end.Y))
            {
                return false;
            }

            double cross = (coordinate.Y - start.Y) * (end.X - start.X) - (coordinate.X - start.X) * (end.Y - start.Y);
            return Math.Abs(cross) < 1e-10;
        }
    }
}
