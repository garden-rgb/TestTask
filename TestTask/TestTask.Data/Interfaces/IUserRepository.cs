using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<User> GetByIdAsync(int? id);
        Task<User> FindByEmailPasswordAsync(string email, string password);
        Task CreateAsync(User user);
    }
}
