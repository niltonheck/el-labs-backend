using System.Collections.Generic;
using AutoMapper;
using CWebService.Application.Models;
using CWebService.Domain.Entities;

namespace CWebService.Application.Profiles
{
    public class BookingProfile : Profile {
        
        public BookingProfile() {
            this.CreateMap<Booking, BookingModel>().ReverseMap();

            this.CreateMap<BookingRequestModel, BookingModel>()
                .ForMember(d => d.Id, s => s.Ignore())
                .ForMember(d => d.RentalAmount, s => s.Ignore())
                .ForMember(d => d.ExtraAmount, s => s.Ignore())
                .ForMember(d => d.TotalAmount, s => s.Ignore());
        }
    }
}