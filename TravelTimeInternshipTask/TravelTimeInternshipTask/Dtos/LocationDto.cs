namespace TravelTimeInternshipTask.Dtos
{
    public class LocationDto
    {
        public string Name { get; set; } = string.Empty;

        public double[] Coordinates { get; set; } = new double[10];
    }

}
