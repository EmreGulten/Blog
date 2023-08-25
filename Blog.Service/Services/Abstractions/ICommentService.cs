using Blog.Entity.DTOs.Comments;

namespace Blog.Service.Services.Abstractions
{
    public interface ICommentService
    {
        Task<List<CommentsDto>> GetAllCommentsNonDeleted();
        Task<List<CommentsDto>> GetAllCommentsDeleted();
        Task CreateCommentAsync(CommentsAddDto commentsAdd);
        Task<string> UpdateCommentAsync(CommentsUpdateDto commentsUpdate);
        Task<string> SafeDeleteCommentAsync(Guid commentId);
        Task<string> UndoDeleteCommentAsync(Guid commentId);
    }
}
