using CWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts.Interfaces {
    public interface IModelContext {
        DbSet<Model> Models { get; set; }
        void SaveChanges();
        void Remove(Model model);
    }
}
