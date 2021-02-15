using CWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts.Interfaces {
    public interface IBookingContext {
        DbSet<Booking> Bookings { get; set; }
        void SaveChanges();
        void Remove(Booking booking);
    }
}
