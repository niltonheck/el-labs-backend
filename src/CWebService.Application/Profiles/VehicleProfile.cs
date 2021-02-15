using System.Collections.Generic;
using AutoMapper;
using CWebService.Application.Models;
using CWebService.Domain.Entities;

namespace CWebService.Application.Profiles
{
    public class VehicleProfile : Profile {
        
        public VehicleProfile() {
            this.CreateMap<Vehicle, VehicleModel>().ReverseMap();
        }
    }
}