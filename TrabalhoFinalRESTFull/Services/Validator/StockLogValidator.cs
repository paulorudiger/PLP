using FluentValidation;
using TrabalhoFinalRESTFull.BaseDados.Models;

namespace TrabalhoFinalRESTFull.Services.Validate
{
    public class StockLogValidator : AbstractValidator<TbStockLog>
    {
        public StockLogValidator()
        {
            RuleFor(s => s.Productid)
                .NotEmpty().WithMessage("Productid é obrigatório.");

            RuleFor(s => s.Qty)
                .NotEmpty().WithMessage("Qty é obrigatório.")
                .NotEqual(0).WithMessage("Qty não pode ser zero.");

            RuleFor(s => s.Createdat)
                .NotEmpty().WithMessage("Createdat é obrigatório.");
        }
    }
}
