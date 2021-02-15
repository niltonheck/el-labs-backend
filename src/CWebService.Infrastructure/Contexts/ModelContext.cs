using CWebService.Domain.Entities;
using CWebService.Infrastructure.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts {
    public class ModelContext : DbContext, IModelContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
        {
        }
        public DbSet<Model> Models { get; set; }
        void IModelContext.Remove(Model model)
        {
            this.Remove(model);
        }
        void IModelContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}