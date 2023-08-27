using Blog.Entity.Entities;
using FluentValidation;

namespace Blog.Service.FluentValidations
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(comment => comment.CommentText).NotEmpty().WithMessage("Comment is required.");
        }
    }
}
