using System.Collections.Generic;
using System.Threading.Tasks;
using CWebService.Application.Models;

namespace CWebService.Application.Interfaces {
    public interface IBrandService {
        Task<IList<BrandModel>>      GetAll();
        Task<BrandModel>      GetSingle(long id);
        Task<BrandModel>      Create(BrandModel brand);
        Task<BrandModel>      Update(BrandModel brand);
        Task<bool>      Delete(long id);
    }
}