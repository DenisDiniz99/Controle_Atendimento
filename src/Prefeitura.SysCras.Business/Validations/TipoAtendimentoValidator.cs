using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class TipoAtendimentoValidator : AbstractValidator<TipoAtendimento>
    {
        public TipoAtendimentoValidator()
        {
            RuleFor(t => t.Tipo)
                .NotEmpty().WithMessage("O campo Tipo de Atendimento não pode ser vazio");
        }
    }
}
