

using ECommerce.Core.DTOs.Request;
using FluentValidation;

namespace ECommerce.Core.Helpers.Validations
{
    public class CategoryAdderValidator: AbstractValidator<AddCategoryRequest>
    {
        public CategoryAdderValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage($"{nameof(AddProductRequest)} cannot be null")
                .WithState(
            x =>
            {
                throw new ArgumentNullException($"{nameof(x)} request cannot be null");
            }
            );


            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(AddCategoryRequest.Name)} cannot be null")
                .WithState(x => throw new ArgumentException($"{nameof(AddCategoryRequest.Name)} cannot be null"));

            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage($"{nameof(AddCategoryRequest.Description)} cannot be null")
               .WithState(x => throw new ArgumentException($"{nameof(AddCategoryRequest.Description)} cannot be null"));

            RuleFor(x => x.Tags).NotNull().NotEmpty().WithMessage($"{nameof(AddCategoryRequest.Tags)} cannot be null")
               .WithState(x => throw new ArgumentException($"{nameof(AddCategoryRequest.Tags)} cannot be null"));
        }
    }
}
