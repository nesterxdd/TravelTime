namespace TravelTimeInternshipTask.Dtos
{
    public class RegionDto
    {
        public string Name { get; set; } = string.Empty;

        public double[][][] Coordinates { get; set; } = new double[10][][]; // I am using such array only for reading json data in IOUtils after reading I am making Region object with List with custom type
    }
}
