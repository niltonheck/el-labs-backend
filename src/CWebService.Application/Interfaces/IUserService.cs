using System.Threading.Tasks;
using CWebService.Application.Models;
using CWebService.Domain.Entities;

namespace CWebService.Application.Interfaces {
    public interface IUserService {
        Task<User> Get(long id);
        Task<User> Create(UserModel user);
        Task<User> Authenticate(string username, string password);
    }
}