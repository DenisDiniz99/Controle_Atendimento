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

            //Validação do camppo Matricula
            RuleFor(colaborador => colaborador.Matricula)
                .NotNull()
                .WithMessage("A Matrícula não pode ser nula.");

            RuleFor(colaborador => colaborador.Matricula)
                .NotEmpty()
                .WithMessage("A Matrícula não pode ser vazia.");

            RuleFor(colaborador => colaborador.Matricula)
                .Length(12)
                .WithMessage("A Matrícula deve conter 12 caracteres.");
        }
    }
}
