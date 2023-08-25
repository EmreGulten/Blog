using Blog.Entity.Entities;

namespace Blog.Entity.DTOs.Comments
{
    public class CommentsListDto
    {
        public IList<Comment> Comments { get; set; }
    }
}
