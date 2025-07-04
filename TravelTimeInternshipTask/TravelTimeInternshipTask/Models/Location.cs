namespace TravelTimeInternshipTask.Models
{
    public class Location
    {
        public string Name { get; }
        public Coordinate Coordinates { get; }

        public Location()
        {
            Name = string.Empty;
            Coordinates = new Coordinate(0,0);
        }

        public Location(string Name, Coordinate coordinate)
        {
            this.Name = Name;
            Coordinates = coordinate;
        }

        public bool IsEmpty()
        {
            return Name == string.Empty;
        }

    }
}
