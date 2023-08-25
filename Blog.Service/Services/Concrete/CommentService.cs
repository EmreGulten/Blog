using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Comments;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Service.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, ClaimsPrincipal user)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateCommentAsync(CommentsAddDto commentsAdd)
        {
            var comment = mapper.Map<Comment>(commentsAdd);
            await unitOfWork.GetRepository<Comment>().AddAsync(comment);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CommentsDto>> GetAllCommentsDeleted()
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAllAsync(x => x.IsDeleted);
            return mapper.Map<List<CommentsDto>>(comment);
        }

        public async Task<List<CommentsDto>> GetAllCommentsNonDeleted()
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAllAsync(x => !x.IsDeleted);
            return mapper.Map<List<CommentsDto>>(comment);
        }

        public async Task<string> SafeDeleteCommentAsync(Guid commentId)
        {
            var userId = _user.GetLoggedInUserId();
            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);

            comment.IsDeleted = true;
            comment.DeletedDate = DateTime.Now;
            comment.DeletedBy = userId.ToString();

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.UserName;
        }

        public async Task<string> UndoDeleteCommentAsync(Guid commentId)
        {
            var userId = _user.GetLoggedInUserId();
            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);

            comment.IsDeleted = false;
            comment.DeletedDate = null;
            comment.DeletedBy = null;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.UserName;
        }

        public async Task<string> UpdateCommentAsync(CommentsUpdateDto commentsUpdate)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x => !x.IsDeleted && x.Id == commentsUpdate.Id);

            comment.CommentText= commentsUpdate.CommentText;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.UserName;
        }
    }
}
