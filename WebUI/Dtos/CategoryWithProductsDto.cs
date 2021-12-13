namespace WebUI.Dtos
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public IEnumerable<ProductDto>? Products { get; set; }
    }
}
