using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
