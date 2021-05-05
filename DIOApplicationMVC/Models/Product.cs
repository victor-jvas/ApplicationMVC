using System;
using System.ComponentModel.DataAnnotations;

namespace DIOApplicationMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [Range( 0.0, 10.0, ErrorMessage = "Quantity must be between 0 and 10")]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}