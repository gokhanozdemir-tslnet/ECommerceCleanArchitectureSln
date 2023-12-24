
using ECommerce.Core.DTOs.Request;
using FluentValidation;

namespace ECommerce.Core.Helpers.Validations
{
    public class ProductAdderValidator : AbstractValidator<AddProductRequest>
    {
        public ProductAdderValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(nameof(AddProductRequest))
                .WithState(
                x =>
                {
                    throw new ArgumentNullException($"{nameof(x)} request cannot be null");
                }
                );

            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .NotEqual("")
                .WithMessage(nameof(AddProductRequest))
                .WithState(
                    x =>
                    {
                        throw new ArgumentException($"{nameof(x.Title)} cannot be null or blank");
                    }
                );

        }
    }
}
