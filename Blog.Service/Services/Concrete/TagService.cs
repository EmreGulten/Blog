using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Service.Services.Concrete
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClaimsPrincipal _user;

        public TagService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<Tag>> GetAllTagsNonDeleted()
        {
            var tags = await unitOfWork.GetRepository<Tag>().GetAllAsync();
            if (tags.Count == 0)
                return new List<Tag>();
            
            return tags;
        }
    }
}
