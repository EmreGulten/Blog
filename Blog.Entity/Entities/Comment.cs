using Blog.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entity.Entities
{
    public class Comment : EntityBase
    {
        
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(300)]
        public string CommentText { get; set; }
        public int BlogRating { get; set; }

        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
