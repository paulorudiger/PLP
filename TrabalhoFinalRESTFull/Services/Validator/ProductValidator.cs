using FluentValidation;
using TrabalhoFinalRESTFull.BaseDados.Models;

namespace TrabalhoFinalRESTFull.Services.Validate
{
    public class ProductValidator : AbstractValidator<TbProduct>
    {

        public ProductValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithMessage("Description é obrigatório.");

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("Barcode é obrigatório.");

            RuleFor(p => p.Barcodetype)
                .NotEmpty().WithMessage("Barcodetype é obrigatório.");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock deve ser igual ou maior que zero.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price deve ser igual ou maior que zero.");

            RuleFor(p => p.Costprice)
                .GreaterThanOrEqualTo(0).WithMessage("Costprice deve ser igual ou maior que zero.");
        }
    }
}
