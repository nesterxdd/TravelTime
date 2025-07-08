using TravelTimeInternshipTask.Models;

namespace TravelTimeInternshipTask.Utils
{
    public static class RegionsUtils
    {
        public static List<RegionWithLocations> GetRegionsWithLocations(List<Region> regions, List<Location> locations)
        {
            List<RegionWithLocations> result = new List<RegionWithLocations>();
            foreach (Region region in regions)
            {
                foreach (Location location in locations)
                {
                    if (region.IsInRegion(location))
                    {
                        region.AddLocation(location);
                        RegionWithLocations? existed = result.FirstOrDefault(r => r.Region == region.Name);
                        if (existed != null)
                        {
                            existed.AddLocation(location.Name);
                        }
                        else
                        {
                            RegionWithLocations temp = new RegionWithLocations(region.Name, new List<string> { location.Name });
                            result.Add(temp);
                        }

                    }
                }
            }
            return result;
        }
    }
}
