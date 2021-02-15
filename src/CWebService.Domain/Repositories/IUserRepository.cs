using System.Threading.Tasks;
using CWebService.Domain.Entities;

namespace CWebService.Domain.Repositories {
    public interface IUserRepository {
        Task<User> Get(long id);
        Task<User> GetByUsernamse(string username);
        Task<User> Create(User user);
    }
}