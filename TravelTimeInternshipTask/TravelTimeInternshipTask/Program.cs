using System;
using TravelTimeInternshipTask.Models;
using TravelTimeInternshipTask.Utils;

namespace TravelTimeInternshipTask
{
    class Program
    {
        static void Main(string[] args)
        {

            string regionsFile = null;
            string locationsFile = null;
            string outputFile = null;

            foreach (var arg in args)
            {
                if (arg.StartsWith("--regions="))
                    regionsFile = arg.Substring("--regions=".Length);
                else if (arg.StartsWith("--locations="))
                    locationsFile = arg.Substring("--locations=".Length);
                else if (arg.StartsWith("--output="))
                    outputFile = arg.Substring("--output=".Length);
            }


            if (string.IsNullOrEmpty(regionsFile) || string.IsNullOrEmpty(locationsFile) || string.IsNullOrEmpty(outputFile))
            {
                Console.WriteLine("Error: Please provide all --regions, --locations and --output parameters");
                Console.WriteLine("Usage: dotnet run --regions=regions.json --locations=locations.json --output=output.json");
                return;
            }

            try
            {
                List<Region> regions = new List<Region>();
                List<Location> locations = new List<Location>();

                IOUtils.ReadFromJson(locationsFile, regionsFile, ref regions, ref locations);
                List<RegionWithLocations> regionsWithLocation = GetRegionsWithLocations(regions, locations);
                IOUtils.WriteToJson(outputFile, regionsWithLocation);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

          


        }

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