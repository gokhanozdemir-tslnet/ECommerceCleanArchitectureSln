
using ECommerce.Core.DTOs.Request;
using FluentValidation;

namespace ECommerce.Core.Helpers.Validations
{
    public class ProductAdderValidator : AbstractValidator<AddProductRequest>
    {
        public ProductAdderValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage(nameof(AddProductRequest))
                .WithState(
                x =>
                {
                    throw new ArgumentNullException($"{nameof(x)} request cannot be null");
                }
                );

          
        }
    }
}
