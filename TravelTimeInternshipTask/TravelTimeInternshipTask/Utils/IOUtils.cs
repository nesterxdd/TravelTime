using Newtonsoft.Json;
using TravelTimeInternshipTask.Dtos;
using TravelTimeInternshipTask.Models;

namespace TravelTimeInternshipTask.Utils
{
    public static class IOUtils
    {
        /// <summary>
        /// File for reading data from json files
        /// </summary>
        /// <param name="regionJsonFile">regions file name</param>
        /// <param name="locationJsonFile">locations file name</param>
        /// <returns>regions and locations list with filled data</returns>
        /// <exception cref="FileNotFoundException">Exception for handling not found file exception</exception>
        public static (List<Region> Regions, List<Location> Locations) ReadFromJson(string regionJsonFile, string locationJsonFile)
        {
            if (!File.Exists(regionJsonFile))
            {
                throw new FileNotFoundException("Regions file not found");
            }
                
            if (!File.Exists(locationJsonFile))
            {
                throw new FileNotFoundException("Locations file not found");
            }
                
            string regionJson = File.ReadAllText(regionJsonFile);
            string locationJson = File.ReadAllText(locationJsonFile);

            List<RegionDto> ?regionDtos = JsonConvert.DeserializeObject<List<RegionDto>>(regionJson);
            List<LocationDto> ?locationDtos = JsonConvert.DeserializeObject<List<LocationDto>>(locationJson);

            if(regionDtos == null || locationDtos == null)
            {
                throw new ArgumentNullException("Regiondto or locationdto is null");
            }

            List<Region> regions = ConvertToRegions(regionDtos);
            List<Location> locations = ConvertToLocations(locationDtos);

            return (regions, locations);
        }

        private static List<Region> ConvertToRegions(List<RegionDto> regionDtos)
        {
            return regionDtos.Select(dto => new Region(
                dto.Name,
                dto.Coordinates.Select(polygonCoords => new Polygon(polygonCoords.Select(coord => new Coordinate(coord[0], coord[1])).ToList()
                )).ToList()
            )).ToList();
        }

        private static List<Location> ConvertToLocations(List<LocationDto> locationDtos)
        {
            return locationDtos.Select(dto => new Location(
               dto.Name,
               new Coordinate(dto.Coordinates[0], dto.Coordinates[1])
           )).ToList();
        }

        public static void WriteToJson(string outputJson, List<RegionWithLocations> regions)
        {
            string jsonOutput = JsonConvert.SerializeObject(regions, Formatting.Indented);
            File.WriteAllText(outputJson, jsonOutput);
        }
    }
   
}

