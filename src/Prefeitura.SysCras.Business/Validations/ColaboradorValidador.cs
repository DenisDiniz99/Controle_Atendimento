using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class ColaboradorValidador : AbstractValidator<Colaborador>
    {
        public ColaboradorValidador()
        {
            //Validação do campo Nome
            RuleFor(colaborador => colaborador.Nome)
                .NotNull()
                .WithMessage("O Nome do Colaborador não pode ser nulo.");

            RuleFor(colaborador => colaborador.Nome)
                .NotEmpty()
                .WithMessage("O Nome do Colaborador não pode ser vazio.");

            RuleFor(colaborador => colaborador.Nome)
                .MaximumLength(50)
                .WithMessage("O Nome do Colaborador deve ter até 50 caracteres.");

            RuleFor(colaborador => colaborador.Nome)
                .MinimumLength(2)
                .WithMessage("O Nome do Colaborador deve ter ao menos 2 caracteres.");

            //Validação do campo Sexo (Gênero)
            RuleFor(colaborador => colaborador.Sexo)
                .NotNull()
                .WithMessage("O Gênero do Colaborador não pode ser vazio.");

            //Validação do campo CargoId
            RuleFor(colaborador => colaborador.CargoId)
                .NotNull()
                .WithMessage("O Cargo do Colaborador precisa ser informado.");

            
        }
    }
}
