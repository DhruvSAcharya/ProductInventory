using System.ComponentModel.DataAnnotations;

namespace ProductInventory.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Name is Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Name is Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Name is Price")]
        public decimal Price { get; set; }
    }
}
