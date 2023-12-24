
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
                x=>
                {
                    throw new ArgumentException($"{nameof(x)} request cannot be null");
                }
                );

            /*
             * 
             * 
            RuleFor(x => x).NotEmpty().WithMessage(nameof(GetProductRequest));
                //.WithState(x =>
                //{
                //    throw new ArgumentException("dfgdfg");
                //});

            RuleFor(x => x.Id)
            .NotNull().WithMessage("Product Id cannot be null")
            .GreaterThan(0).WithMessage("Product Id caanot be zero")
            .WithState(x => { throw new ArgumentException(nameof(x.Id)); });
             */
        }
    }
}
