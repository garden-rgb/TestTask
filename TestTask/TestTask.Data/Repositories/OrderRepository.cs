using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.Interfaces;

namespace TestTask.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            _context.Orders.Remove(order);
        }

    }
}
