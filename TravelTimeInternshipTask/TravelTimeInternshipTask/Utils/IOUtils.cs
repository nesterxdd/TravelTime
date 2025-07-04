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
        /// <summary>
        /// Reads data from json file and returns Lists with regions and locations
        /// </summary>
        /// <param name="regionJsonFile">json file with regions</param>
        /// <param name="locationJsonFile">json file with locations</param>
        /// <returns>Filled lists with data from json files</returns>
        /// <exception cref="FileNotFoundException">Some file was not found</exception>
        public static (List<Region> Regions, List<Location> Locations) ReadFromJson(string regionJsonFile, string locationJsonFile)
        {
            if (!File.Exists(regionJsonFile))
                throw new FileNotFoundException($"Regions file not found: {regionJsonFile}");

            if (!File.Exists(locationJsonFile))
                throw new FileNotFoundException($"Locations file not found: {locationJsonFile}");

            var regionJson = File.ReadAllText(regionJsonFile);
            var locationJson = File.ReadAllText(locationJsonFile);

            var regions = JsonConvert.DeserializeObject<List<Region>>(regionJson);
            var locations = JsonConvert.DeserializeObject<List<Location>>(locationJson);

            return (regions, locations);
        }



        public static void WriteToJson(string outputJson, List<RegionWithLocations> regions)
        {
            string jsonOutput = JsonConvert.SerializeObject(regions, Formatting.Indented);
            File.WriteAllText(outputJson, jsonOutput);
        }
    }
}
