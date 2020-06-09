using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Exceptions;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> Create([FromForm][Bind("Name,Date,Provider,OrderItems")] OrderModel order)
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
        [HttpGet("add-order-form")]
        public ActionResult AddOrderForm()
        {
            var providers = _orderService.GetAllProviders();
            ViewBag.Providers = new SelectList(providers, "Id", "Name");
            var orderModel = new OrderModel();
            orderModel.OrderItems.Add(new OrderItemModel());
            return View(orderModel);
        }

        [HttpPost("add-order-item")]
        public ActionResult AddOrderItem([FromForm] OrderModel order)
        {
            order.OrderItems.Add(new OrderItemModel());
            return PartialView("_OrderItems", order);
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
        public async Task<ActionResult<OrderModel>> GetOrder(int id)
        {
            var order = await _orderService.Get(id);
            if (order == null)
                return NotFound("Order was not found");
            return Ok(order);

        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateOrder([FromBody] OrderModel order)
        {
            var result = await _orderService.Update(order);
            if (result == 0)
                return BadRequest("Update failed");
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.Delete(id);
            return Ok();

        }
    }
}