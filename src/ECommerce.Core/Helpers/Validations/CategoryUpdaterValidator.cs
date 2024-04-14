

using ECommerce.Core.DTOs.Request;
using FluentValidation;

namespace ECommerce.Core.Helpers.Validations
{
    public class CategoryUpdaterValidator:AbstractValidator<UpdateCategoryRequest>
    {
        public CategoryUpdaterValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage($"{nameof(UpdateCategoryRequest)} cannot be null")
           .WithState(
       x =>
       {
           throw new ArgumentNullException($"{nameof(x)} request cannot be null");
       }
       );


            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage($"{nameof(UpdateCategoryRequest.Name)} cannot be null")
                .WithState(x => throw new ArgumentException($"{nameof(UpdateCategoryRequest.Name)} cannot be null"));

            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage($"{nameof(UpdateCategoryRequest.Description)} cannot be null")
               .WithState(x => throw new ArgumentException($"{nameof(UpdateCategoryRequest.Description)} cannot be null"));

            RuleFor(x => x.Tags).NotNull().NotEmpty().WithMessage($"{nameof(UpdateCategoryRequest.Tags)} cannot be null")
               .WithState(x => throw new ArgumentException($"{nameof(UpdateCategoryRequest.Tags)} cannot be null"));
        }
    }
}
