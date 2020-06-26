using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;

namespace OrderManagement.Web.Controllers
{
    /// <summary>
    /// Контроллер для отображения форм 
    /// </summary>
    public class HomeController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public HomeController(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        /// <summary>
        /// Отображение основного окна
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("orders-table")]
        public IActionResult ShowOrdersTable()
        {
            var ordersCollection = _orderService.GetAll();
            //ToDo Сделать партиал с ошибкой
            return PartialView("_OrdersTable", ordersCollection);
        }

        [HttpPost]
        public IActionResult AcceptFilter([FromForm]FilterModel filter)
        {
            var ordersCollection = _orderService.GetFilteredOrders(filter);

            return PartialView("_OrdersTable", ordersCollection);
        }
    }
}