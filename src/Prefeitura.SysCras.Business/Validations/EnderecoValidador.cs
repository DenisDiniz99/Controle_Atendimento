using FluentValidation;
using Prefeitura.SysCras.Business.ValueObjects;

namespace Prefeitura.SysCras.Business.Validations
{
    public class EnderecoValidador : AbstractValidator<Endereco>
    { 
        public EnderecoValidador()
        {
            //Validação do campo Logradouro
            RuleFor(endereco => endereco.Logradouro)
                .MaximumLength(50)
                .WithMessage("A Logradouro deve ter até 50 caracteres.");

            //Validação do campo Numero
            RuleFor(endereco => endereco.Numero)
                .MaximumLength(10);

            //Validação do campo Bairro
            RuleFor(endereco => endereco.Bairro)
                .MaximumLength(50)
                .WithMessage("O Bairro deve ter até 50 caracteres.");

            //Validação do campo Cidade
            RuleFor(endereco => endereco.Cidade)
                .MaximumLength(50)
                .WithMessage("A Cidade deve ter até 50 caracteres.");

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
