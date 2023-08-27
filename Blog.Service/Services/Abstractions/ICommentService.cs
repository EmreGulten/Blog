using Blog.Entity.DTOs.Comments;
using Blog.Entity.Entities;

namespace Blog.Service.Services.Abstractions
{
    public interface ICommentService
    {
        Task<List<CommentsDto>> GetAllCommentsNonDeleted();
        Task<List<CommentsDto>> GetAllCommentsDeleted();
        Task<Comment> GetProductyByGuid(Guid id);
        Task CreateCommentAsync(CommentsAddDto commentsAdd);
        Task<string> UpdateCommentAsync(CommentsUpdateDto commentsUpdate);
        Task<string> SafeDeleteCommentAsync(Guid commentId);
        Task<string> UndoDeleteCommentAsync(Guid commentId);
    }
}
