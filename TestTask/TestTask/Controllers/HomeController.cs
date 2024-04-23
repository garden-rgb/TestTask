using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.Business.Interfaces;
using TestTask.Business.Models;
using TestTask.Data;
using TestTask.Models.ViewModel;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public HomeController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<OrderData> orderData = await _orderService.GetAllAsync();

            var orders = _mapper.Map<IEnumerable<OrderData>, List<OrderViewModel>>(orderData);

            return View(orders);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(Order order)
        {
            if (ModelState.IsValid)
            {
                var orderData = _mapper.Map<OrderData>(order);

                await _orderService.CreateOrderAsync(orderData);

                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            OrderData orderData = await _orderService.GetByIdAsync(id);

            var book = new OrderViewModel { Id = orderData.Id };

            if (book == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}
