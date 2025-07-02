using System;
using TravelTimeInternshipTask.Models;
using TravelTimeInternshipTask.Utils;

namespace TravelTimeInternshipTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Region> regions = new List<Region>();
            List<Location> locations = new List<Location>();
            string locationJson = "locations.json";
            string regionsJson = "regions.json";

            IOUtils.ReadFromJson(locationJson, regionsJson, ref regions, ref locations);
            List<RegionWithLocations> regionsWithLocation = GetRegionsWithLocations(regions, locations);
            IOUtils.WriteToJson("output.json", regionsWithLocation);


        }

        public static List<RegionWithLocations> GetRegionsWithLocations(List<Region> regions, List<Location> locations)
        {
            List<RegionWithLocations> result = new List<RegionWithLocations>();
            foreach (Region region in regions)
            {
                foreach(Location location in locations)
                {
                    if (region.IsInRegion(location))
                    {
                        region.AddLocation(location);
                        RegionWithLocations existed = result.FirstOrDefault(r => r.Region == region.Name);
                        if(existed != null)
                        {
                            existed.MatchedLocations.Add(location.Name);
                        }
                        else
                        {
                            RegionWithLocations temp = new RegionWithLocations();
                            temp.Region = region.Name;
                            temp.MatchedLocations.Add(location.Name);
                            result.Add(temp);
                        }
                      
                    }
                }
            }
            return result;
        }
    }


}