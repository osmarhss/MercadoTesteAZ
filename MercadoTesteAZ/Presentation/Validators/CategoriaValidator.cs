using FluentValidation;
using MercadoTesteAZ.Presentation.ViewModels;

namespace MercadoTesteAZ.Presentation.Validators
{
    public class CategoriaValidator : AbstractValidator<CategoriaViewModel>
    {
        public CategoriaValidator() 
        {
            RuleFor(c => c.Nome).NotNull().NotEmpty().WithMessage("O nome da categoria não pode ser nula ou vazia");
        }
    }
}
