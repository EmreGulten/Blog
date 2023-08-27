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
        //public string CategoryName { get; set; }
        public int StockQuantity { get; set; }
        public bool IsFeatured { get; set; }

        public string Slug { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        public string CanonicalUrl { get; set; }
        public string OpenGraphImage { get; set; }
        public string TwitterCardImage { get; set; }
        public virtual bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<RelatedProductDto> RelatedProducts { get; set; }
    }

    public class RelatedProductDto
    {
        public int Id { get; set; }
        public string RelatedProducts { get; set; }
    }
}
