using TestSamgau.Contracts.Dtos;
using TestSamgau.Contracts.Parameters;
using TestSamgau.DataAccess.Abstract;
using TestSamgau.Models;

namespace TestSamgau.DataAccess.EntityProvider
{
    public class EntityUserProvider : EntityProvider<ApplicationContext, User, Guid>, IUserProvider
    {
        private readonly ApplicationContext _context;

        public EntityUserProvider(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task Add(UserCreationDto user)
        {
            await Add(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Email = user.Email,
            });
        }
        
        public async Task Edit(User user, UserEditParameter userEdit)
        {
            if(userEdit.Password != null)
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userEdit.Password);
            if(userEdit.LastName != null)
                user.LastName = userEdit.LastName;
            if(userEdit.FirstName != null)
                user.FirstName = userEdit.FirstName;
            await Edit(user);
        }
    }
}
