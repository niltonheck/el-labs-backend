using System.Collections.Generic;
using AutoMapper;
using CWebService.Application.Models;
using CWebService.Domain.Entities;

namespace CWebService.Application.Profiles
{
    public class ModelProfile : Profile {
        
        public ModelProfile() {
            this.CreateMap<Model, ModelModel>();

            this.CreateMap<ModelModel, Model>();
        }
    }
}