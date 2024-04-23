using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Business.Models;
using TestTask.Data;

namespace TestTask.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(UserData userDto);
        Task<User> LoginAsync(UserData userDto);
    }
}
