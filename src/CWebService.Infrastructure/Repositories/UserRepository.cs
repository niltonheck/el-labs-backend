using System.Linq;
using System.Threading.Tasks;
using CWebService.Domain.Entities;
using CWebService.Domain.Enums;
using CWebService.Domain.Repositories;

namespace CWebService.Infrastructure.Repositories {
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext dbContext;

        public UserRepository(ApplicationContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<User> Create(User user)
        {
            return await Task.Run(() => {
                var userEntity = this.dbContext.Users.Add(user);
                this.dbContext.SaveChanges();

                return userEntity.Entity;
            });
        }

        public async Task<User> Get(long id)
        {
            return await Task.Run(() => {
                var userEntity = this.dbContext.Users.Find(id);
                return userEntity;
            });
        }

        public async Task<User> GetByUsernamse(string username)
        {
            return await Task.Run(() => {
                var userEntity = this.dbContext.Users.Where(user => user.Username == username).First();
                return userEntity;
            });
        }
    }
}