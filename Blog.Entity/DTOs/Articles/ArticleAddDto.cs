using Blog.Entity.DTOs.Categories;
using Microsoft.AspNetCore.Http;


namespace Blog.Entity.DTOs.Articles
{
    public class ArticleAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Tag { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }

        public IFormFile Photo { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }
}
