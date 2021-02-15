using System.Threading.Tasks;
using AutoMapper;
using CWebService.Application.Helpers;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using CWebService.Domain.Entities;
using CWebService.Domain.Enums;
using CWebService.Domain.Repositories;

namespace CWebService.Application.Services {
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(
            IUserRepository userRepository,
            IMapper mapper
        ) {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<User> Get(long id)
        {
            return await this.userRepository.Get(id);
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await this.userRepository.GetByUsernamse(username);
            var (verify, needUpgrade) = new PasswordHasher().Check(user.Password, password);

            if(!verify) {
                throw new TaskSchedulerException();
            } else {
                return user;
            }
        }

        public async Task<User> Create(UserModel model)
        {
            var mapping = this.mapper.Map<UserModel, User>(model);
            mapping.Password = new PasswordHasher().Hash(model.Password);
            
            return await this.userRepository.Create(mapping);
        }
    }
}