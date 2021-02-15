using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;
using CWebService.Infrastructure.Contexts.Interfaces;

namespace CWebService.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IBrandContext dbContext;

        public BrandRepository(IBrandContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Brand> InsertIntoDatabase(Brand brand)
        {
            return await Task.Run(() => {
                var e = this.dbContext.Brands.Add(brand);
                this.dbContext.SaveChanges();

                return e.Entity;
            });
        }

        public async Task<IList<Brand>> Get()
        {
            return await Task.Run(() => {
               return this.dbContext.Brands.ToList();
            });
        }

        public async Task<Brand> UpdateIntoDatabase(Brand brand)
        {
            return await Task.Run(() => {
               var e = this.dbContext.Brands.Update(brand);
                this.dbContext.SaveChanges();

                return e.Entity;
            });
        }

        public async Task<Brand> GetSingle(long id)
        {
            return await Task.Run(() => {
                return this.dbContext.Brands.Where<Brand>(brand => brand.Id == id).First();
            });
        }

        public async Task<bool> Delete(long id)
        {
            return await Task.Run(() => {
                try {
                    var query = this.dbContext.Brands.Where<Brand>(brand => brand.Id == id).First();
                    this.dbContext.Remove(query);
                    this.dbContext.SaveChanges();
                } catch {
                    return false;
                }

                return true;
            });
        }
    }
}