using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please do not leave the product name blank.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Please enter the product name between 2 and 150 characters.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please do not leave stock information blank.")
                .Must(s => s >= 0)
                    .WithMessage("Stock information cannot be negative!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Please do not leave the price information blank.")
                .Must(s => s >= 0)
                    .WithMessage("Price information cannot be negative!");
        }
    }
}
