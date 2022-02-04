using FluentValidation;
using Prefeitura.SysCras.Business.ValueObjects;

namespace Prefeitura.SysCras.Business.Validations
{
    public class FiliacaoValidator : AbstractValidator<Filiacao>
    {
        public FiliacaoValidator()
        {
            //Validação do campo NomePai
            RuleFor(filiacao => filiacao.NomePai)
                .MaximumLength(50)
                .WithMessage("O Nome do Pai deve ter até 50 caracteres");

            //Validação do campo NomeMae
            RuleFor(filiacao => filiacao.NomeMae)
                .MaximumLength(50)
                .WithMessage("O Nome da Mãe deve ter até 50 caracteres");
        }
    }
}
