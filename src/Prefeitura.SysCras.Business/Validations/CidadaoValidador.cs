using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class CidadaoValidador : AbstractValidator<Cidadao>
    {
        public CidadaoValidador()
        {
            //Validação do campo Nome
            RuleFor(cidadao => cidadao.Nome)
                .NotNull()
                .WithMessage("O Nome do Cidadão não pode ser nulo");

            RuleFor(cidadao => cidadao.Nome)
                .NotEmpty()
                .WithMessage("O Nome do Cidadão não pode ser vazio");

            RuleFor(cidadao => cidadao.Nome)
                .MaximumLength(50)
                .WithMessage("O Nome do Cidadão deve ter até 50 caracteres");

            RuleFor(cidadao => cidadao.Nome)
                .MinimumLength(2)
                .WithMessage("O Nome do Cidadão deve ter ao menos 2 caracteres");

            //Validação do campo Cpf
            RuleFor(cidadao => cidadao.Cpf)
                .NotNull()
                .WithMessage("O CPF não pode ser nulo.");

            RuleFor(cidadao => cidadao.Cpf)
                .NotEmpty()
                .WithMessage("O campo CPF não pode ser vazio.");

            RuleFor(cidadao => cidadao.Cpf)
                .MaximumLength(11)
                .WithMessage("O campo CPF deve ter até 11 caracteres.");

            //Validação do campo Rg
            RuleFor(cidadao => cidadao.Rg)
                .NotNull()
                .WithMessage("O campo RG não pode ser nulo.");

            RuleFor(cidadao => cidadao.Rg)
                .NotEmpty()
                .WithMessage("O campo RG não pode ser vazio.");

            RuleFor(cidadao => cidadao.Rg)
                .MaximumLength(11)
                .WithMessage("O campo RG deve ter até 11 caracteres.");

            //Validação do campo Sexo
            RuleFor(cidadao => cidadao.Sexo)
                .Length(1)
                .WithMessage("O campo Sexo deve ter 1 caracter: M ou F.");

            //Validação do campo DataNasc
            RuleFor(cidadao => cidadao.DataNasc)
                .NotNull()
                .WithMessage("O campo Data de Nascimento não pode ser nulo.");

            RuleFor(cidadao => cidadao.DataNasc)
                .NotEmpty()
                .WithMessage("O campo Data de Nascimento não pode ser vazio.");

            //Validação do campo E-mail
            RuleFor(cidadao => cidadao.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("E-mail em formato incorreto.");

            //Validação do campo Endereco
            RuleFor(cidadao => cidadao.Endereco)
                .SetValidator(new EnderecoValidador());
        }
    }
}
