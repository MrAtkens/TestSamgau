using TestSamgau.Contracts.Dtos;
using TestSamgau.Contracts.Parameters;
using TestSamgau.DataAccess.Abstract;
using TestSamgau.Models;

namespace TestSamgau.DataAccess.EntityProvider
{
    public interface IUserProvider : IProvider<User, Guid>
    {
        Task Add(UserCreationDto user);
        Task Edit(User user, UserEditParameter userEdit);
    }
}