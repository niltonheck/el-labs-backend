using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using CWebService.Application.Models.Brand;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;

namespace CWebService.Application.Services {
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IMapper mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) {
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Create(VehicleModel model)
        {
            var validator = new VehicleModelValidator().Validate(model);
            if(!validator.IsValid) {
                var error = validator.Errors;
                throw new TaskSchedulerException();
            } 

            return await this.vehicleRepository.InsertIntoDatabase(this.mapper.Map<VehicleModel, Vehicle>(model));
        }

        public async Task<IList<VehicleModel>> GetAll()
        {
            return this.mapper.Map<IList<Vehicle>, IList<VehicleModel>>(await this.vehicleRepository.Get());
        }

        public async Task<IList<VehicleModel>> GetByModel(long modelId)
        {
            var list = await this.vehicleRepository.GetByModel(modelId);
            return this.mapper.Map<IList<Vehicle>, IList<VehicleModel>>(list);
        }

        public async Task<VehicleModel> GetSingle(long vehicleId)
        {
            return this.mapper.Map<Vehicle, VehicleModel>(await this.vehicleRepository.GetSingle(vehicleId));
        }

        public async Task<bool> Delete(long vehicleId)
        {
            return await this.vehicleRepository.Delete(vehicleId);
        }

        public async Task<bool> Update(VehicleModel model)
        {
            var validator = new VehicleModelValidator();
            if(!validator.Validate(model).IsValid) {
                throw new TaskSchedulerException();
            } 
            
            return await this.vehicleRepository.UpdateIntoDatabase(this.mapper.Map<VehicleModel, Vehicle>(model));
        }
    }
}