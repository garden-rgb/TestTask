using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Business.Interfaces;
using TestTask.Business.Models;
using TestTask.Data;
using TestTask.Data.Interfaces;

namespace TestTask.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<OrderData> GetByIdAsync(int orderId)
        {
            var order = await _uow.Orders.GetById(orderId);
            var orderData = _mapper.Map<OrderData>(order);

            return orderData;
        }

        public async Task<IEnumerable<OrderData>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Order>, List<OrderData>>(await _uow.Orders.GetAllAsync());
        }

        public async Task CreateOrderAsync(OrderData orderData)
        {
            var order = _mapper.Map<Order>(orderData);

            await _uow.Orders.CreateAsync(order);
            await _uow.SaveAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _uow.Orders.DeleteAsync(id);

            await _uow.SaveAsync();
        }
    }
}
