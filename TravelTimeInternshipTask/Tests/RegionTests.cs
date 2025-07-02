using System.Collections.Generic;
using TravelTimeInternshipTask.Models;
using Xunit;

namespace TravelTimeInternshipTask.Tests
{
    public class ProgramEdgeCasesTests
    {
        private readonly List<List<List<double>>> squarePolygon = new()
        {
            new List<List<double>>
            {
                new List<double>{0, 0},
                new List<double>{0, 10},
                new List<double>{10, 10},
                new List<double>{10, 0},
                new List<double>{0, 0} // Closing polygon
            }
        };

        private Region CreateSquareRegion()
        {
            return new Region("SquareRegion", squarePolygon);
        }

        [Fact]
        public void LocationOnVertexIsConsideredInside()
        {
            var region = CreateSquareRegion();
            var location = new Location("VertexPoint", new List<double> { 0, 0 });

            bool result = region.IsInRegion(location);

            Assert.True(result);
        }

        [Fact]
        public void LocationOnEdgeIsConsideredInsideOrFalse()
        {
            var region = CreateSquareRegion();
            var location = new Location("EdgePoint", new List<double> { 0, 5 });

            bool result = region.IsInRegion(location);


            Assert.True(result == true);
        }

        [Fact]
        public void LocationOutsidePolygonIsConsideredOutside()
        {
            var region = CreateSquareRegion();
            var location = new Location("OutsidePoint", new List<double> { -1, 5 });

            bool result = region.IsInRegion(location);

            Assert.False(result);
        }

        [Fact]
        public void LocationInsidePolygonIsConsideredInside()
        {
            var region = CreateSquareRegion();
            var location = new Location("InsidePoint", new List<double> { 5, 5 });

            bool result = region.IsInRegion(location);

            Assert.True(result);
        }
    }
}
