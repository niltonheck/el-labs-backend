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
    public class ModelRepositoryTest
    {

        [Fact]
        public async void Should_RequestSuccessful_Model()
        {
            var data = new List<Model>
            {
                new Model { Name = "Onix 1.6" },
                new Model { Name = "Onix LTE 1.6" },
                new Model { Name = "Onix LTE 1.8" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Model>>();
            mockSet.As<IQueryable<Model>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Model>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Model>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Model>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IModelContext>();
            mockContext.Setup(c => c.Models).Returns(mockSet.Object);

            var repo = new ModelRepository(mockContext.Object);
            var d = await repo.Get();

            Assert.Equal(3, d.Count);
            Assert.Equal("Onix 1.6", d[0].Name);
            Assert.Equal("Onix LTE 1.6", d[1].Name);
            Assert.Equal("Onix LTE 1.8", d[2].Name);
        }
    }
}
