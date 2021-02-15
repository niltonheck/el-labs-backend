using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CWebService.Application.Models;

namespace CWebService.Application.Interfaces {
    public interface IBookingService {
        Task<BookingModel>      Create(BookingRequestModel model, long userId);
        Task<BookingModel>      GetSingle(long id);
        Task<BookingModel>      ActionReturn(BookingReturnRequestModel model);
        Task<MemoryStream>      GetContract(long id);
    }
}