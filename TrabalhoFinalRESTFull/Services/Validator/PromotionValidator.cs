using FluentValidation;
using TrabalhoFinalRESTFull.BaseDados.Models;

namespace TrabalhoFinalRESTFull.Services.Validate
{
    public class PromotionValidator : AbstractValidator<TbPromotion>
    {
        public PromotionValidator()
        {
            RuleFor(p => p.Startdate)
                .NotEmpty().WithMessage("Startdate é obrigatório.")
                .LessThan(p => p.Enddate).WithMessage("Startdate deve ser menor que Enddate.");

            RuleFor(p => p.Enddate)
                .NotEmpty().WithMessage("Enddate é obrigatório.");

            RuleFor(p => p.Promotiontype)
                .Must(CheckAValidPromotionType).WithMessage("Tipo de promoção inválida para a gravação.");

            RuleFor(p => p.Productid)
                .NotEmpty().WithMessage("Productid é obrigatório.");

            RuleFor(p => p.Value)
                .GreaterThan(0).WithMessage("Value deve ser maior que zero.");
        }

        private bool CheckAValidPromotionType(int promotiontype)
        {
            return promotiontype == 0 || promotiontype == 1;
        }
    }
}