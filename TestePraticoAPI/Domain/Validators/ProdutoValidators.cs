using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class ProdutoValidators : AbstractValidator<Produto>
    {
        public ProdutoValidators()
        {
            RuleFor(c => c.Descricao)
                   .NotEmpty().WithMessage("Por favor é necessário o preenchimento do campo Descrição.")
                   .NotNull().WithMessage("Por favor é necessário o preenchimento do campo Descrição.");

            RuleFor(c => c.DataFabricacao)
                   .LessThan(c => c.DataValidade).WithMessage("A data de fabricação do produto não pode ser igual ou posterior a data de validade.");
        }
    }
}
