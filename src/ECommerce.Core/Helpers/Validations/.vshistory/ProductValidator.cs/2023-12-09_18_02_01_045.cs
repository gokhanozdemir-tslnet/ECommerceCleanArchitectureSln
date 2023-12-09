
using ECommerce.Core.DTOs.Request;
using FluentValidation;

namespace ECommerce.Core.Helpers.Validations
{
    public class ProductGetterValidator:AbstractValidator<GetProductRequest>
    {
        public ProductGetterValidator()
        {
            RuleFor(x => x.Id)
            .NotNull().WithMessage("Product Id cannot be null")
            .GreaterThan(0).WithMessage("Product Id caanot be zero");
        }
    }
}
