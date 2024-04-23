using Microsoft.EntityFrameworkCore;
using TestTask.Data.Interfaces;

namespace TestTask.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) 
        {      
            _context = context;
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> FindByEmailPasswordAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

    }
}
