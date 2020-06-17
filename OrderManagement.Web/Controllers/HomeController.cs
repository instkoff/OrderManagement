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
        public ActionResult Index()
        {
            var ordersCollection = _orderService.GetAll();
            var orderNames = ordersCollection.Select(o => o.Name).Distinct();
            var orderDates = ordersCollection.Select(o => o.Date).Distinct();
            var orderOrderProviderId = ordersCollection.Select(o => o.Provider.Id);
            var orderItems = _orderItemService.GetAllDistinct();
            var orderItemNames = orderItems.Select(i => i.ItemName).Distinct();
            var orderItemUnits = orderItems.Select(i => i.Unit).Distinct();
            var orderProviderNames = ordersCollection.Select(o => o.Provider.Name);
            ViewBag.OrderNames = new SelectList(orderNames);
            ViewBag.OrderDates = new SelectList(orderDates);
            ViewBag.OrderProviderIds = new SelectList(orderOrderProviderId);
            ViewBag.OrderItemNames = new SelectList(orderItemNames);
            ViewBag.OrderItemUnits = new SelectList(orderItemUnits);
            ViewBag.OrderProviderNames = new SelectList(orderProviderNames);
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