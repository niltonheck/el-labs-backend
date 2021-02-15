using CWebService.Domain.Entities;
using CWebService.Infrastructure.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts {
    public class BookingContext : DbContext, IBookingContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
        : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; set; }

        public void Remove(Booking booking)
        {
            this.Remove(booking);
        }

        void IBookingContext.SaveChanges()
        {
            this.SaveChanges();
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite("Data Source=C:\\Users\\Nilton Heck\\source\\repos\\c-web-service\\cwebservice.db");
    }
}