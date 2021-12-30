using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class SetorValidador : AbstractValidator<Setor>
    {
        public SetorValidador()
        {
            //Validação do campo TituloSetor
            RuleFor(setor => setor.TituloSetor)
                .NotNull()
                .WithMessage("O Título do Setor não pode ser nulo.");

            RuleFor(setor => setor.TituloSetor)
                .NotEmpty()
                .WithMessage("O Título do Setor não pode ser vazio.");

            RuleFor(setor => setor.TituloSetor)
                .MaximumLength(50)
                .WithMessage("O Título do Setor deve ter até 50 caracteres.");

            RuleFor(setor => setor.TituloSetor)
                .MinimumLength(2)
                .WithMessage("O Título do Setor deve ter ao menos 2 caracteres.");
        }
    }
}
