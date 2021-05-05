using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIOApplicationMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill the Description field.")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}