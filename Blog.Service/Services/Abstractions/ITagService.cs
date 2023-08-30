using Blog.Entity.Entities;

namespace Blog.Service.Services.Abstractions
{
    public interface ITagService
    {
        Task<List<Tag>> GetAllTagsNonDeleted();
        //Task<List<Tag>> GetAllTagsDeleted();
        //Task CreateCategoryAsync(Tag tag);
        //Task<Tag> GetTagByGuid(Guid id);
        //Task<string> UpdateTagAsync(Tag tag);
        //Task<string> SafeDeleteTagAsync(Guid id);
        //Task<string> UndoDeleteTagAsync(Guid id);
    }
}
