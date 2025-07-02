using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelTimeInternshipTask.Models;

namespace TravelTimeInternshipTask.Utils
{
    public static class IOUtils
    {
        public static (List<Region> Regions, List<Location> Locations) ReadFromJson(string regionJsonFile, string locationJsonFile)
        {
<<<<<<< Updated upstream
            string regionJson = File.ReadAllText(regionJsonFile);
            string locationJson = File.ReadAllText(locationJsonFile);

            regions = JsonConvert.DeserializeObject<List<Region>>(regionJson);
            locations = JsonConvert.DeserializeObject<List<Location>>(locationJson);
=======
            if (!File.Exists(regionJsonFile))
                throw new FileNotFoundException($"Regions file not found: {regionJsonFile}");

            if (!File.Exists(locationJsonFile))
                throw new FileNotFoundException($"Locations file not found: {locationJsonFile}");

            var regionJson = File.ReadAllText(regionJsonFile);
            var locationJson = File.ReadAllText(locationJsonFile);

            var regions = JsonConvert.DeserializeObject<List<Region>>(regionJson);
            var locations = JsonConvert.DeserializeObject<List<Location>>(locationJson);
>>>>>>> Stashed changes

            return (regions, locations);
        }


        public static void WriteToJson(string outputJson, List<RegionWithLocations> regions)
        {
            string jsonOutput = JsonConvert.SerializeObject(regions, Formatting.Indented);
            File.WriteAllText(outputJson, jsonOutput);
        }
    }
}
