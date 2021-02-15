using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using CWebService.Application.Models.Brand;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;

namespace CWebService.Application.Services {
    public class ModelService : IModelService
    {
        private readonly IModelRepository modelRepository;
        private readonly IMapper mapper;

        public ModelService(IModelRepository modelRepository, IMapper mapper)
        {
            this.modelRepository = modelRepository;
            this.mapper = mapper;
        }

        public async Task<ModelModel> Create(ModelModel model)
        {
            var validator = new ModelModelValidator();
            if(!validator.Validate(model).IsValid) {
                throw new TaskSchedulerException();
            } 

            var query = await this.modelRepository.InsertIntoDatabase(this.mapper.Map<ModelModel, Model>(model));
            return this.mapper.Map<Model, ModelModel>(query);
        }

        public async Task<ModelModel> Update(ModelModel model)
        {
            var validator = new ModelModelValidator();
            if(!validator.Validate(model).IsValid) {
                throw new TaskSchedulerException();
            } 
            
            var query = await this.modelRepository.UpdateIntoDatabase(this.mapper.Map<ModelModel, Model>(model));
            return this.mapper.Map<Model, ModelModel>(query);
        }

        public async Task<IList<ModelModel>> GetAll()
        {
            return this.mapper.Map<IList<Model>, IList<ModelModel>>(await this.modelRepository.Get());
        }
        public async Task<IList<ModelModel>> GetModels(long brandId)
        {
            var list = await this.modelRepository.GetByBrand(brandId);
            return this.mapper.Map<IList<Model>, IList<ModelModel>>(list);
        }

        public async Task<ModelModel> GetSingle(long modelId)
        {
            var list = await this.modelRepository.GetSingle(modelId);
            return this.mapper.Map<Model, ModelModel>(list);
        }

        public async Task<bool> Delete(long modelId)
        {
            var list = await this.modelRepository.Delete(modelId);
            return true;
        }

        public async Task<IList<ModelModel>> GetByBrand(long id)
        {
            var list = await this.modelRepository.GetByBrand(id);
            return this.mapper.Map<IList<Model>, IList<ModelModel>>(list);
        }
    }
}