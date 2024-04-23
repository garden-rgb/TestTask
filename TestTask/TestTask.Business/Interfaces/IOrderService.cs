using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Business.Models;

namespace TestTask.Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderData> GetByIdAsync(int orderId);
        Task<IEnumerable<OrderData>> GetAllAsync();
        Task CreateOrderAsync(OrderData orderData);
        Task DeleteOrderAsync(int id);
    }
}
