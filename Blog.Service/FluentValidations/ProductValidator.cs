using Blog.Entity.Entities;
using FluentValidation;

namespace Blog.Service.FluentValidations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
