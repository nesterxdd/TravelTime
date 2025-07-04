using TravelTimeInternshipTask.Models;

namespace TravelTimeInternshipTask.Tests
{
    public class ProgramEdgeCasesTests
    {
        private readonly List<Polygon> squarePolygons = new List<Polygon>
        {
            new Polygon(new List<Coordinate>
            {
                new Coordinate(0, 0),
                new Coordinate(0, 10),
                new Coordinate(10, 10),
                new Coordinate(10, 0),
                new Coordinate(0, 0) 
            })
        };

        private Region CreateSquareRegion()
        {
            Region region = new Region("SquareRegion", squarePolygons);
            return region;
        }

        [Fact]
        public void LocationOnVertexIsConsideredInside()
        {
            Region region = CreateSquareRegion();
            Location location = new Location("VertexPoint", new Coordinate(0, 0));

            bool result = region.IsInRegion(location);

            Assert.True(result);
        }

        [Fact]
        public void LocationOnEdgeIsConsideredInsideOrFalse()
        {
            Region region = CreateSquareRegion();
            Location location = new Location("EdgePoint", new Coordinate(0, 5));

            bool result = region.IsInRegion(location);

            Assert.True(result);
        }

        [Fact]
        public void LocationOutsidePolygonIsConsideredOutside()
        {
            Region region = CreateSquareRegion();
            Location location = new Location("OutsidePoint", new Coordinate(-1, 5));

            bool result = region.IsInRegion(location);

            Assert.False(result);
        }

        [Fact]
        public void LocationInsidePolygonIsConsideredInside()
        {
            Region region = CreateSquareRegion();
            Location location = new Location("InsidePoint", new Coordinate(5, 5));

            bool result = region.IsInRegion(location);

            Assert.True(result);
        }

        [Fact]
        public void LocationOnHorizontalEdgeIsConsideredInside()
        {
            Region region = CreateSquareRegion();
            Location location = new Location("HorizontalEdge", new Coordinate(5, 0));

            bool result = region.IsInRegion(location);

            Assert.True(result);
        }

        [Fact]
        public void LocationOnVerticalEdgeIsConsideredInside()
        {
            Region region = CreateSquareRegion();
            Location location = new Location("VerticalEdge", new Coordinate(0, 5));

            bool result = region.IsInRegion(location);

            Assert.True(result);
        }




    }
}
