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
    public class BrandRepositoryTest
    {

        [Fact]
        public async void Should_RequestSuccessful_Brands()
        {
            var data = new List<Brand>
            {
                new Brand { Name = "Ford" },
                new Brand { Name = "Chevrolet" },
                new Brand { Name = "Caoa Cherry" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Brand>>();
            mockSet.As<IQueryable<Brand>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Brand>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Brand>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Brand>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IBrandContext>();
            mockContext.Setup(c => c.Brands).Returns(mockSet.Object);

            var repo = new BrandRepository(mockContext.Object);
            var d = await repo.Get();

            Assert.Equal(3, d.Count);
            Assert.Equal("Ford", d[0].Name);
            Assert.Equal("Chevrolet", d[1].Name);
            Assert.Equal("Caoa Cherry", d[2].Name);
        }
    }
}
