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
        public static void ReadFromJson(string locationJsonFile, string regionJsonFile, ref List<Region> regions, ref List<Location> locations)
        {
            if (!File.Exists(regionJsonFile))
            {
                throw new FileNotFoundException($"Regions file not found: {regionJsonFile}");
            }

            if (!File.Exists(locationJsonFile))
            {
                throw new FileNotFoundException($"Locations file not found: {locationJsonFile}");
            }


            string regionJson = File.ReadAllText(regionJsonFile);
            string locationJson = File.ReadAllText(locationJsonFile);

            regions = JsonConvert.DeserializeObject<List<Region>>(regionJson);
            locations = JsonConvert.DeserializeObject<List<Location>>(locationJson);

        }

        public static void WriteToJson(string outputJson, List<RegionWithLocations> regions)
        {
            try
            {
                string jsonOutput = JsonConvert.SerializeObject(regions, Formatting.Indented);
                File.WriteAllText(outputJson, jsonOutput);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error writing output file: {ex.Message}");
            }
           
        }
    }
}
