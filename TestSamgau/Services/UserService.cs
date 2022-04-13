using TestSamgau.Contracts.Dtos;
using TestSamgau.Contracts.Parameters;
using TestSamgau.DataAccess.EntityProvider;
using TestSamgau.Models;

namespace TestSamgau.Services
{
    public class UserService
    {
        private readonly IUserProvider _provider;

        public UserService(IUserProvider provider)
        {
            _provider = provider;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _provider.GetAll();
            return users;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var users = await _provider.GetById(id);
            return users;
        }

        public async Task AddUser(UserCreationDto userCreationDto)
        {
            await _provider.Add(userCreationDto);
        }

   
    }
}
