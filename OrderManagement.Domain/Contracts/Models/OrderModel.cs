﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OrderManagement.Domain.Contracts.Models
{
    public class OrderModel
    {
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина названия должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите дату")]
        public DateTime Date { get; set; }
        public ProviderModel Provider { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }

        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }
    }
}