using FluentValidation;
using Prefeitura.SysCras.Business.ValueObjects;

namespace Prefeitura.SysCras.Business.Validations
{
    public class EnderecoValidador : AbstractValidator<Endereco>
    { 
        public EnderecoValidador()
        {
            //Validação do campo Rua
            RuleFor(endereco => endereco.Rua)
                .NotNull()
                .WithMessage("A Rua não pode ser nula.");

            RuleFor(endereco => endereco.Rua)
                .NotEmpty()
                .WithMessage("A Rua não pode ser vazia.");

            RuleFor(endereco => endereco.Rua)
                .MaximumLength(50)
                .WithMessage("A Rua deve ter até 50 caracteres.");

            //Validação do campo Numero
            RuleFor(endereco => endereco.Numero)
                .MaximumLength(10);

            //Validação do campo Bairro
            RuleFor(endereco => endereco.Bairro)
                .NotNull()
                .WithMessage("O Bairro não pode ser nulo.");

            RuleFor(endereco => endereco.Bairro)
                .NotEmpty()
                .WithMessage("O Bairro não pode ser vazio.");

            RuleFor(endereco => endereco.Bairro)
                .MaximumLength(50)
                .WithMessage("O Bairro deve ter até 50 caracteres.");

            RuleFor(endereco => endereco.Bairro)
                .MinimumLength(2)
                .WithMessage("O Bairro deve ter ao menos 2 caracteres.");

            //Validação do campo Cidade
            RuleFor(endereco => endereco.Cidade)
                .NotNull()
                .WithMessage("A Cidade não pode ser nula.");

            RuleFor(endereco => endereco.Cidade)
                .NotEmpty()
                .WithMessage("A Cidade não pode ser vazia.");

            RuleFor(endereco => endereco.Cidade)
                .MaximumLength(50)
                .WithMessage("A Cidade deve ter até 50 caracteres.");

            RuleFor(endereco => endereco.Cidade)
                .MinimumLength(2)
                .WithMessage("A Cidade deve ter ao menos 2 caracteres.");

            //Validação do campo CEP
            RuleFor(endereco => endereco.Cep)
                .Length(8)
                .WithMessage("O CEP deve ter 8 caracteres.");

            //Validação do campo Estado
            RuleFor(endereco => endereco.Estado)
                .Length(2)
                .WithMessage("O Estado deve ter 2 caracteres.");
        }
    }
}
