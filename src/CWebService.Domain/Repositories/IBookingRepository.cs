using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CWebService.Domain.Entities;

namespace CWebService.Domain.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking>        GetSingle(long id);
        Task<Booking>        InsertIntoDatabase(Booking book);
        Task<Booking>        UpdateIntoDatabase(Booking book);
        Task<MemoryStream>        GenerateContract(long id);
    }
}