
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
                .WithMessage($"{nameof(AddProductRequest)} cannot be null" )
                .WithState(
                x =>
                {
                    throw new ArgumentNullException($"{nameof(x)} request cannot be null");
                }
                );

            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage(nameof(AddProductRequest))
                .WithState(
                    x =>
                    {
                        throw new ArgumentException($"{nameof(x.Title)} cannot be null or blank");
                    }
                );

            RuleFor(x=>x.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage($"{nameof(AddProductRequest.Price)} cannot be zero or null")
                .WithState(x =>
                {
                    throw new ArgumentException($"{nameof(x.Title)} cannot be null or blank");
                });

        }
    }
}
