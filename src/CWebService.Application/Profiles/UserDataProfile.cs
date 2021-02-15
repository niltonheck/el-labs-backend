using System.Collections.Generic;
using AutoMapper;
using CWebService.Application.Models;
using CWebService.Domain.Entities;

namespace CWebService.Application.Profiles
{
    public class UserDataProfile : Profile {
        
        public UserDataProfile() {
            this.CreateMap<User, UserModel>()
            .ReverseMap();

            this.CreateMap<UserProfile, UserProfileModel>()
            .ReverseMap();
        }
    }
}