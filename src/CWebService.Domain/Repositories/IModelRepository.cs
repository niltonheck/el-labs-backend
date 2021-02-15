using System.Collections.Generic;
using System.Threading.Tasks;
using CWebService.Domain.Entities;

namespace CWebService.Domain.Repositories
{
    public interface IModelRepository
    {
        Task<IList<Model>>        Get();
        Task<Model>        InsertIntoDatabase(Model model);
        Task<Model>        UpdateIntoDatabase(Model model);
        Task<IList<Model>>        GetByBrand(long brandId);
        Task<Model>        GetSingle(long id);
        Task<bool>        Delete(long id);
    }
}