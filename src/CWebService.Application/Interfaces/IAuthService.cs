using CWebService.Domain.Entities;

namespace CWebService.Application.Interfaces {
    public interface IAuthService
    {
         string GenerateToken(User user);
    }
}