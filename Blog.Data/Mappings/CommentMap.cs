using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(new Comment
            {
                UserName = "admin",
                Email = "admin",
                CommentText = "admin",
                CommentDate = DateTime.Now,
                CommentStatus = true,
                ArticleId = Guid.Parse("C461FB49-94CC-4862-886D-5018BEB425A4")
            });
        }
    }
}
