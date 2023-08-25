using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class Article : EntityBase
    {
        public Article()
        {

        }
        public Article(string title, string content,string metaTitle, string metaDescription,string tag,string author, Guid userId, string createdBy, Guid categoryId, Guid imageId)
        {
            Title = title;
            Content = content;
            MetaTitle = metaTitle;
            MetaDescription = metaDescription;
            Tag = tag;
            Author = author;
            UserId = userId;
            CategoryId = categoryId;
            ImageId = imageId;
            CreatedBy = createdBy;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Tag { get; set; }
        public string Author { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
    }
}
