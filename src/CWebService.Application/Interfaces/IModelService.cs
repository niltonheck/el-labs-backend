using System.Collections.Generic;
using System.Threading.Tasks;
using CWebService.Application.Models;

namespace CWebService.Application.Interfaces {
    public interface IModelService {
        Task<IList<ModelModel>>      GetAll();
        Task<ModelModel>      Create(ModelModel model);
        Task<ModelModel>      Update(ModelModel model);
        Task<IList<ModelModel>>      GetByBrand(long id);
        Task<ModelModel>      GetSingle(long id);
        Task<bool>      Delete(long id);
    }
}