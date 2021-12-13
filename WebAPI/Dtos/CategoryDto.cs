using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required] public string? Name { get; set; }
    }
}
