using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OrderManagement.Domain.Contracts.Models
{
    public class OrderItemModel
    {
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина названия должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите количество")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Укажите единицы")]
        public string Unit { get; set; }
    }
}