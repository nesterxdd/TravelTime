using TravelTimeInternshipTask.Models;
using TravelTimeInternshipTask.Utils;

namespace TravelTimeInternshipTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string? regionsFile = null;
            string? locationsFile = null;
            string? outputFile = null;

            //used for debugging
            //string regionsFile = "regions.json";
            //string locationsFile = "locations.json";
            //string outputFile = "output.json";

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

                (regions, locations) = IOUtils.ReadFromJson(regionsFile, locationsFile);

                List<RegionWithLocations> regionsWithLocation = RegionsUtils.GetRegionsWithLocations(regions, locations);
                IOUtils.WriteToJson(outputFile, regionsWithLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}