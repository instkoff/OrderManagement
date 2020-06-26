using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagement.Domain.Contracts.Exceptions;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;

namespace OrderManagement.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] OrderModel order)
        {
            if (!ModelState.IsValid)
                throw new ValidationException("Form validation error");
            var result = await _orderService.Create(order);
            if (result == 0)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult<List<OrderModel>> GetAll()
        {
            var ordersCollection = _orderService.GetAll();
            if (ordersCollection == null || !ordersCollection.Any())
                return BadRequest("Collection is empty");
            return Ok(ordersCollection);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var order = await _orderService.Get(id);
            if (order == null)
                return NotFound("Order was not found");
            return View("OrderDetailsForm", order);

        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateOrder([FromBody] OrderModel order)
        {
            var result = await _orderService.Update(order);
            if (result == 0)
                return BadRequest("Update failed");
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _orderService.Delete(id);
            return RedirectToAction("Index","Home");
        }

        [HttpGet("add-order")]
        public ActionResult AddOrderForm()
        {
            //var providers = _orderService.GetAllProviders();
            //ViewBag.Providers = new SelectList(providers, "Id", "Name", providers[0]);
            var orderModel = new OrderModel();
            orderModel.OrderItems.Add(new OrderItemModel());
            return View(orderModel);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> ShowEditOrderForm(int id)
        {
            var order = await _orderService.Get(id);
            var providers = _orderService.GetAllProviders();
            ViewBag.Providers = new SelectList(providers, "Id", "Name");
            if (order == null)
                return NotFound("Заказ не найден");
            return View("EditOrderForm", order);
        }

        [HttpGet("OrderDetails")]
        public ActionResult<List<OrderItemModel>> GetOrderDetails(int orderId)
        {
            var orderDetails = _orderService.GetOrderItems(orderId);
            return orderDetails;
        }
        [HttpGet("GetProviders")]
        public ActionResult<List<ProviderModel>> GetAllProviders()
        {
            var providers = _orderService.GetAllProviders();
            return providers;
        }
    }
}