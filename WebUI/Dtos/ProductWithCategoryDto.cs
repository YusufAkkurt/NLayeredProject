namespace WebUI.Dtos
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto? Category { get; set; }
    }
}
