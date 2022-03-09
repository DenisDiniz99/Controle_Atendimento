using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class AtendimentoValidador : AbstractValidator<Atendimento>
    {
        public AtendimentoValidador()
        {
            //Validação do campo Descrição
            RuleFor(atendimento => atendimento.Descricao)
                .NotNull()
                .WithMessage("A Descrição deve ser informada");

            RuleFor(atendimento => atendimento.Descricao)
                .MaximumLength(500)
                .WithMessage("A Descrição deve ter até 500 caracteres");

            RuleFor(atendimento => atendimento.Descricao)
                .MinimumLength(10)
                .WithMessage("A Descrição deve ter ao menos 10 caracteres");

            //Validação do campo StatusAtendimento
            RuleFor(atendimento => atendimento.StatusAtendimento)
                .NotEmpty()
                .WithMessage("O Status do Atendimento deve ser informado");

            //Validação do campo Observacao
            RuleFor(atendimento => atendimento.Observacao)
                .MaximumLength(500)
                .WithMessage("A Observação deve ter até 200 caracteres");
        }
    }
}
