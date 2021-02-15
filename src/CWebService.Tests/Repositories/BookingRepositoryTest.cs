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
    public class BookingRepositoryTest
    {

        [Fact]
        public async void Should_RequestSuccessful_Brands()
        {
            var data = new List<Booking>
            {
                new Booking { Id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Booking>>();
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IBookingContext>();
            mockContext.Setup(c => c.Bookings).Returns(mockSet.Object);

            var repo = new BookingRepository(mockContext.Object);
            var d = await repo.GetSingle(1);

            Assert.Equal(1, d.Id);
        }
    }
}
