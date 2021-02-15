using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;
using CWebService.Infrastructure.Contexts.Interfaces;

namespace CWebService.Infrastructure.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly IModelContext dbContext;

        public ModelRepository(IModelContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<IList<Model>> Get()
        {
            return await Task.Run(() => {
               return this.dbContext.Models.ToList();
            });
        }

        public async Task<Model> GetSingle(long id)
        {
            return await Task.Run(() => {
               return this.dbContext.Models.Where<Model>(model => model.Id == id).First();
            });
        }

        public async Task<bool> Delete(long id)
        {
            return await Task.Run(() => {
                var query = this.dbContext.Models.Where<Model>(model => model.Id == id).First();
                this.dbContext.Remove(query);
                this.dbContext.SaveChanges();
                return true;
            });
        }

        public async Task<Model> InsertIntoDatabase(Model model)
        {
            return await Task.Run(() => {
               var e = this.dbContext.Models.Add(model);
                this.dbContext.SaveChanges();

                return e.Entity;
            });
        }

        public async Task<Model> UpdateIntoDatabase(Model model)
        {
            return await Task.Run(() => {
               var e = this.dbContext.Models.Update(model);
                this.dbContext.SaveChanges();

                return e.Entity;
            });
        }

        public async Task<IList<Model>> GetByBrand(long brandId)
        {
            return await Task.Run(() => {
               return this.dbContext.Models.Where(b => b.BrandId == brandId).ToList();
            });
        }
    }
}