using Newtonsoft.Json;

namespace TravelTimeInternshipTask.Models;

public class RegionWithLocations
{
    public string Region { get; }
    public List<string> MatchedLocations { get; set; }

    public RegionWithLocations(string region, List<string> matchedLocations)
    {
        Region = region;
        MatchedLocations = matchedLocations;
    }

    public void AddLocation(string location)
    {
        if (location != string.Empty)
        {
            MatchedLocations.Add(location);
        }
    }

}
