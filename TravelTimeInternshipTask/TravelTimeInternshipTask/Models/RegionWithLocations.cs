using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTimeInternshipTask.Models
{
    public class RegionWithLocations
    {
        public string Region { get; set; } = string.Empty;
        public List<string> MatchedLocations { get; set; } 

        public RegionWithLocations(string Region, List<string> MatchedLocations)
        {
            this.Region = Region;
            this.MatchedLocations = MatchedLocations;
        }
        public RegionWithLocations()
        {
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
