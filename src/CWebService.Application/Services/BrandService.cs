using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using CWebService.Application.Models.Brand;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;

namespace CWebService.Application.Services {
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }

        public async Task<IList<BrandModel>> GetAll()
        {
            return this.mapper.Map<IList<Brand>, IList<BrandModel>>(await this.brandRepository.Get());
        }

        public async Task<BrandModel> Create(BrandModel brand)
        {
            var validator = new BrandModelValidator().Validate(brand);
            if(!validator.IsValid) {
                var error = validator.Errors;
                throw new TaskSchedulerException();
            } 

            var mapping = this.mapper.Map<BrandModel, Brand>(brand);
            var add = await this.brandRepository.InsertIntoDatabase(mapping);

            return this.mapper.Map<Brand, BrandModel>(add);
        }

        public async Task<BrandModel> Update(BrandModel brand)
        {
            var mapping = this.mapper.Map<BrandModel, Brand>(brand);
            var edit = await this.brandRepository.UpdateIntoDatabase(mapping);

            return this.mapper.Map<Brand, BrandModel>(edit);
        }

        public async Task<BrandModel> GetSingle(long id)
        {
            var query = await this.brandRepository.GetSingle(id);
            return this.mapper.Map<Brand, BrandModel>(query);
        }

        public async Task<bool> Delete(long id)
        {
            return await this.brandRepository.Delete(id);
        }
    }
}