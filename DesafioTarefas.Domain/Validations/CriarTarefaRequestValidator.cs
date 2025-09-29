using DesafioTarefas.Application.DTOs.Requests;
using FluentValidation;

namespace DesafioTarefas.Domain.Validations
{
    public class CriarTarefaRequestValidator : AbstractValidator<CriarTarefaRequest>
    {

        public CriarTarefaRequestValidator()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(t => t.Descricao)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");
        }
    }
}
