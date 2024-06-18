using FluentValidation;
using TrabalhoFinalRESTFull.BaseDados.Models;

namespace TrabalhoFinalRESTFull.Services.Validate
{
    public class SaleValidator : AbstractValidator<TbSale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.Code)
                .NotEmpty().WithMessage("Code é obrigatório.");

            RuleFor(s => s.Createat)
                .NotEmpty().WithMessage("Createat é obrigatório.");

            RuleFor(s => s.Productid)
                .NotEmpty().WithMessage("Productid é obrigatório.");

            RuleFor(s => s.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price deve ser igual ou maior que zero.");

            RuleFor(s => s.Qty)
                .GreaterThan(0).WithMessage("Qty deve ser maior que zero.");

            RuleFor(s => s.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount deve ser igual ou maior que zero.");
        }
    }
}
