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
        private readonly IProviderService _providerService;

        public HomeController(IOrderService orderService, IProviderService providerService)
        {
            _orderService = orderService;
            _providerService = providerService;
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
            ViewBag.OrderNames = new SelectList(orderNames);
            var orderDates = ordersCollection.Select(o => o.Date).Distinct();
            ViewBag.OrderDates = new SelectList(orderDates);
            var orderOrderProviderId = ordersCollection.Select(o => o.Provider.Id);
            ViewBag.OrderProviderId = new SelectList(orderDates);
            return PartialView("_FilterForm", new FilterModel());
        }

        [HttpPost]
        public PartialViewResult AcceptFilter(FilterModel filter)
        {

            return PartialView("_OrdersTable");
        }
    }
}