using Blog.Entity.DTOs.Categories;

namespace Blog.Entity.DTOs.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public List<CategoryDto> Category { get; set; }
        public List<string> Tags { get; set; }
        public int StockQuantity { get; set; }
        public bool IsFeatured { get; set; }

        public List<string> RelatedProducts { get; set; }
    }
}
