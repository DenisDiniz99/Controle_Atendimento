using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class AssuntoAtendimentoValidator : AbstractValidator<AssuntoAtendimento>
    {
        public AssuntoAtendimentoValidator()
        {
            //Validação do campo TituloAssunto
            RuleFor(cargo => cargo.TituloAssunto)
                .NotNull()
                .WithMessage("O Título do Assunto não pode ser nulo.");

            RuleFor(cargo => cargo.TituloAssunto)
                .NotEmpty()
                .WithMessage("O Título do Assunto não pode ser vazio.");

            RuleFor(cargo => cargo.TituloAssunto)
                .MaximumLength(50)
                .WithMessage("O Título do Assunto deve ter até 50 caracteres.");

            RuleFor(cargo => cargo.TituloAssunto)
                .MinimumLength(2)
                .WithMessage("O Título do Assunto deve ter ao menos 2 caracteres.");
        }
    }
}
