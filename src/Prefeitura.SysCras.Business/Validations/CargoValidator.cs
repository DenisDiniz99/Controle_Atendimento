using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class CargoValidator : AbstractValidator<Cargo>
    {
        public CargoValidator()
        {
            //Validação do campo TituloCargo
            RuleFor(cargo => cargo.TituloCargo)
                .NotNull()
                .WithMessage("O Título do Cargo não pode ser nulo.");

            RuleFor(cargo => cargo.TituloCargo)
                .NotEmpty()
                .WithMessage("O Título do Cargo não pode ser vazio.");

            RuleFor(cargo => cargo.TituloCargo)
                .MaximumLength(50)
                .WithMessage("O Título do Cargo deve ter até 50 caracteres.");

            RuleFor(cargo => cargo.TituloCargo)
                .MinimumLength(2)
                .WithMessage("O Título do Cargo deve ter ao menos 2 caracteres.");
        }
    }
}
