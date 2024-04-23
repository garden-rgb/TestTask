using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task CreateAsync(Order order);
        Task DeleteAsync(int id);

    }
}
