using AutoMapper;
using Blog.Entity.DTOs.Comments;
using Blog.Entity.Entities;

namespace Blog.Service.AutoMapper.Comments
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentsDto,Comment>().ReverseMap();
            CreateMap<CommentsUpdateDto,Comment>().ReverseMap();
            CreateMap<CommentsUpdateDto, CommentsDto>().ReverseMap();
            CreateMap<CommentsAddDto, Comment>().ReverseMap();
        }
    }
}
