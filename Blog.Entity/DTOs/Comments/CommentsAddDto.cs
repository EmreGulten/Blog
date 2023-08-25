using Blog.Entity.DTOs.Articles;

namespace Blog.Entity.DTOs.Comments
{
    public class CommentsAddDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public Guid ArticleId { get; set; }
        public virtual ArticleDto Article { get; set; }
    }
}
