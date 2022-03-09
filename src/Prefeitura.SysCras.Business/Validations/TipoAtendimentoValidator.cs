using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class TipoAtendimentoValidator : AbstractValidator<TipoAtendimento>
    {
        public TipoAtendimentoValidator()
        {
            RuleFor(t => t.Tipo)
                .NotNull().WithMessage("A Descrição deve ser informada informado");
        }
    }
}
