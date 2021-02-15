using System.Collections.Generic;
using System.Threading.Tasks;
using CWebService.Domain.Entities;

namespace CWebService.Domain.Repositories
{
    public interface IBrandRepository
    {
        Task<IList<Brand>>        Get();
        Task<Brand>        GetSingle(long id);
        Task<bool>        Delete(long id);
        Task<Brand>        InsertIntoDatabase(Brand brand);
        Task<Brand>        UpdateIntoDatabase(Brand brand);
    }
}