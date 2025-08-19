using FluentValidation;
using MercadoTesteAZ.Application.ViewModels.Categorias;

namespace MercadoTesteAZ.Presentation.Validators
{
    public class CategoriaValidator : AbstractValidator<CategoriaAdminViewModel>
    {
        public CategoriaValidator() 
        {
            RuleFor(c => c.Nome).NotNull().NotEmpty().WithMessage("O nome da categoria não pode ser nula ou vazia");
        }
    }
}
