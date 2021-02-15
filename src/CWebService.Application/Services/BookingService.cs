using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using CWebService.Application.Models.Brand;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;

namespace CWebService.Application.Services {
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IMapper mapper;

        public BookingService(IBookingRepository bookingRepository, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
        }

        public async Task<BookingModel> ActionReturn(BookingReturnRequestModel model)
        {
            var entity = await this.bookingRepository.GetSingle(model.BookingId);

            var bookingModel = this.mapper.Map<Booking, BookingModel>(entity);
                bookingModel.CalculateExtraCost(model);
                bookingModel.CalculateTotalCost();

            entity.ExtraAmount = bookingModel.ExtraAmount;
            entity.TotalAmount = bookingModel.TotalAmount;

            await this.bookingRepository.UpdateIntoDatabase(entity);

            return bookingModel;
        }

        public async Task<BookingModel> Create(BookingRequestModel model, long userId)
        {
            var validator = new BookingModelValidator().Validate(model);
            if(!validator.IsValid) {
                var error = validator.Errors;
                throw new TaskSchedulerException();
            } 

            var vehicle = this.mapper.Map<Vehicle, VehicleModel>(await this.vehicleRepository.GetSingle(model.VehicleId));

            var rental = this.mapper.Map<BookingRequestModel, Booking>(model);
                rental.RentalAmount = vehicle.SimulateCost(model.NumberOfHours);
                rental.UserId = userId;

            var query = this.bookingRepository.InsertIntoDatabase(rental);

            return this.mapper.Map<Booking, BookingModel>(rental);
        }

        public async Task<MemoryStream> GetContract(long id)
        {
            return await this.bookingRepository.GenerateContract(id);
        }

        public async Task<BookingModel> GetSingle(long id)
        {
            var query = await this.bookingRepository.GetSingle(id);
            return this.mapper.Map<Booking, BookingModel>(query);
        }
    }
}