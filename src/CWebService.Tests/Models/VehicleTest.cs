using CWebService.Domain.Entities;
using Xunit;

namespace CWebService.Tests
{
    public class VehicleTest
    {
        [Fact]
        public void Should_CreateValid_Vehicle()
        {
            var vehicle = new Vehicle{
                Plate = "ABC111",
                Brand = new Brand{
                    Name = "General Brand"
                },
                Model = new Model{
                    Name = "Generic Model",
                    BrandId = 1
                },
                Year = 2001,
                CostPerHour = 1.89, 
                FuelType = Domain.Enums.FuelType.Gasoline,
                TrunkCapacity = 2.50,
                Category = Domain.Enums.Category.Basic
            };

            Assert.NotNull(vehicle);
            Assert.NotNull(vehicle.Plate);
            Assert.NotNull(vehicle.Brand);
            Assert.NotNull(vehicle.Model);
            Assert.NotNull(vehicle.Year);
            Assert.NotNull(vehicle.CostPerHour);
            Assert.NotNull(vehicle.FuelType);
            Assert.NotNull(vehicle.TrunkCapacity);
            Assert.NotNull(vehicle.Category);
        }
    }
}
