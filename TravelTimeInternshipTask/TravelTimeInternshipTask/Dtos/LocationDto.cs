using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelTimeInternshipTask.Dtos
{
    public class LocationDto
    {
        public string Name { get; set; } = string.Empty;

        public double[] Coordinates { get; set; } = new double[10];
    }

}
