using TestTask.Business.Models;
using TestTask.Data.Interfaces;
using TestTask.Data;
using TestTask.Business.Interfaces;

namespace TestTask.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> RegisterAsync(UserData userDto)
        {
            User user = await _uow.Users.FindByEmailAsync(userDto.Email);

            if (user == null)
            {
                user = new User { Email = userDto.Email, Password = userDto.Password, Username = userDto.Username };

                await _uow.Users.CreateAsync(user);
                await _uow.SaveAsync();
            }

            return user;
        }

        public async Task<User> LoginAsync(UserData userDto)
        {
            User user = await _uow.Users.FindByEmailPasswordAsync(userDto.Email, userDto.Password);
            return user;
        }

    }
}
