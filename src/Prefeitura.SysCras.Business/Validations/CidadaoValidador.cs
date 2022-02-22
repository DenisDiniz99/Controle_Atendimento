﻿using FluentValidation;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations.Documentos;

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

            //Validação do campo NomeSocial
            RuleFor(cidadao => cidadao.NomeSocial)
                .MaximumLength(50)
                .WithMessage("O Nome do Nome Social deve ter até 50 caracteres");

            //Validação do campo Cpf
            RuleFor(cidadao => cidadao.Cpf)
                .NotNull()
                .WithMessage("O CPF não pode ser nulo.");

            RuleFor(cidadao => cidadao.Cpf)
                .NotEmpty()
                .WithMessage("O campo CPF não pode ser vazio.");

            RuleFor(cidadao => cidadao.Cpf.Length)
                  .Equal(CpfValidation.CpfSize).WithMessage("O campo CPF deve conter 11 caracteres");

            RuleFor(cidadao => CpfValidation.Validate(cidadao.Cpf))
               .Equal(true).WithMessage("O campo Documento (CPF) não é válido");

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

            //Validação do campo EstadoCivil
            RuleFor(cidadao => cidadao.EstadoCivil)
                .NotNull()
                .WithMessage("O campo Estado Civil não pode ser vazio");

            //Validação do campo Genero
            RuleFor(cidadao => cidadao.Genero)
                .NotNull()
                .WithMessage("O campo Gênero não pode ser vazio");

            //Validação do campo Raca
            RuleFor(cidadao => cidadao.Raca)
                .NotNull()
                .WithMessage("O campo Raça não pode ser vazio");

            //Validação do campo Nacionalidade
            RuleFor(cidadao => cidadao.Nacionalidade)
                .MaximumLength(50)
                .WithMessage("O campo Nacionalidade deve ter até 50 caracteres.");

            //Validação do campo Naturalidade
            RuleFor(cidadao => cidadao.Naturalidade)
                .MaximumLength(50)
                .WithMessage("O campo Naturalidade deve ter até 50 caracteres.");

            
            //Validação do campo DataNasc
            RuleFor(cidadao => cidadao.DataNasc)
                .NotNull()
                .WithMessage("O campo Data de Nascimento não pode ser nulo.");

            RuleFor(cidadao => cidadao.DataNasc)
                .NotEmpty()
                .WithMessage("O campo Data de Nascimento não pode ser vazio.");

            //Validação do campo Celular
            RuleFor(cidadao => cidadao.Celular)
                .NotNull()
                .WithMessage("O campo Celular não pode ser nulo.");

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
