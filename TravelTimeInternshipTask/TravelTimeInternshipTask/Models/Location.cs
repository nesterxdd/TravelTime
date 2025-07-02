using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTimeInternshipTask.Models
{
    public class Location
    {
        public string Name { get; set; }
        public List<double> Coordinates { get; set; } 

        public Location()
        {
            Name = string.Empty;
            Coordinates = new List<double>();
        }

        public Location(string Name, List<double> coordinate)
        {
            this.Name = Name;
            Coordinates = coordinate;
        }
        public bool IsEmpty()
        {
            return Name == string.Empty;
        }

    }
}
