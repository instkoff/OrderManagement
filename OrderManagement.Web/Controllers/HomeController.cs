using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

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
            return View();
        }

        [HttpGet("orders-table")]
        public PartialViewResult ShowOrdersTable()
        {
            var ordersCollection = _orderService.GetAll();
            //ToDo Сделать партиал с ошибкой
            if (ordersCollection == null || !ordersCollection.Any())
                return null;
            return PartialView("_OrdersTable", ordersCollection);
        }

        [HttpGet("filter-form")]
        public PartialViewResult ShowFilterForm()
        {
            var ordersCollection = _orderService.GetAll();
            //ToDo Сделать партиал с ошибкой
            var orderNames = ordersCollection.Select(o => o.Name).Distinct();
            var orderDates = ordersCollection.Select(o => o.Date).Distinct();
            var orderOrderProviderId = ordersCollection.Select(o => o.Provider.Id);
            var orderItems = _orderItemService.GetAllDistinct();
            var orderItemNames = orderItems.Select(i => i.ItemName);
            var orderItemUnits = orderItems.Select(i => i.Unit);
            var orderProviderNames = ordersCollection.Select(o => o.Provider.Name);
            ViewBag.OrderNames = new SelectList(orderNames);
            ViewBag.OrderDates = new SelectList(orderDates);
            ViewBag.OrderProviderIds = new SelectList(orderOrderProviderId);
            ViewBag.OrderItemNames = new SelectList(orderItemNames);
            ViewBag.OrderItemUnits = new SelectList(orderItemUnits);
            ViewBag.OrderProviderNames = new SelectList(orderProviderNames);
            return PartialView("_FilterForm", new FilterModel());
        }

        [HttpPost]
        public PartialViewResult AcceptFilter([FromForm]FilterModel filter)
        {

            return PartialView("_OrdersTable");
        }
    }
}