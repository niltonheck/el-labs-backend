using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using CWebService.Domain.Entities;
using CWebService.Infrastructure.Contexts.Interfaces;
using CWebService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CWebService.Tests
{
    public class VehicleRepositoryTest
    {

        [Fact]
        public async void Should_RequestSuccessful_Model()
        {
            var data = new List<Vehicle>
            {
                new Vehicle { Plate = "ABC1111" },
                new Vehicle { Plate = "ABC2222" },
                new Vehicle { Plate = "ABC3333" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IVehicleContext>();
            mockContext.Setup(c => c.Vehicles).Returns(mockSet.Object);

            var repo = new VehicleRepository(mockContext.Object);
            var d = await repo.Get();

            Assert.Equal(3, d.Count);
            Assert.Equal("ABC1111", d[0].Plate);
            Assert.Equal("ABC2222", d[1].Plate);
            Assert.Equal("ABC3333", d[2].Plate);
        }
    }
}
