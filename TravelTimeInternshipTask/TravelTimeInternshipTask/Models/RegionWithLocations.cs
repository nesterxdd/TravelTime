namespace TravelTimeInternshipTask.Models
{
    public class RegionWithLocations
    {
        public string Region { get; }
        private List<string> MatchedLocations;

        public RegionWithLocations(string Region, List<string> MatchedLocations)
        {
            this.Region = Region;
            this.MatchedLocations = MatchedLocations;
        }
        public RegionWithLocations()
        {
            Region = string.Empty;
            MatchedLocations = new List<string>();
        }

        public void AddLocation(string location)
        {
            if(location != string.Empty)
            {
                MatchedLocations.Add(location);
            }         
        }

    }
}
