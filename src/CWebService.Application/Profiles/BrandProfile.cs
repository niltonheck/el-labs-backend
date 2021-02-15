using System.Collections.Generic;
using AutoMapper;
using CWebService.Application.Models;
using CWebService.Domain.Entities;

namespace CWebService.Application.Profiles
{
    public class BrandProfile : Profile {
        
        public BrandProfile() {
            this.CreateMap<Brand, BrandModel>().ReverseMap();
        }
    }
}