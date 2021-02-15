using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;
using CWebService.Infrastructure.Contexts.Interfaces;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

namespace CWebService.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IBookingContext dbContext;

        public BookingRepository(IBookingContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Booking> GetSingle(long id)
        {
            return await Task.Run(() => {
                return this.dbContext.Bookings.Where(b => b.Id == id).First();
            });
        }

        public async Task<Booking> InsertIntoDatabase(Booking booking)
        {
            return await Task.Run(() => {
                var e = this.dbContext.Bookings.Add(booking);
                dbContext.SaveChanges();

                return e.Entity;
            });
        }

        public async Task<Booking> UpdateIntoDatabase(Booking booking)
        {
            return await Task.Run(() => {
                this.dbContext.SaveChanges();
                return booking;
            });
        }

        public async Task<MemoryStream> GenerateContract(long id) {
            return await Task.Run(() => {

                var booking = this.GetSingle(id);

                PdfDocument document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                
                graphics.DrawString("Simulação de Contrato de Locação - #" + booking.Id, font, PdfBrushes.Black, new PointF(0, 0));
                
                MemoryStream stream = new MemoryStream();
                document.Save(stream);

                stream.Position = 0;
                
                return stream;
            });
        }
    }
}