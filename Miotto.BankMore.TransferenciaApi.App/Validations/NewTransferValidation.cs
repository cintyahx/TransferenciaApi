using FluentValidation;
using Miotto.BankMore.TransferenciaApi.App.Commands;
using Miotto.BankMore.TransferenciaApi.Domain.Interfaces;

namespace Miotto.BankMore.TransferenciaApi.App.Validations
{
    public class NewTransferValidation : AbstractValidator<NewTransferCommand>
    {
        public NewTransferValidation(IContaCorrenteRepository contaCorrenteRepository)
        {
            RuleFor(x => x.NumeroContaDestino)
                .NotEmpty().WithMessage(string.Format(ValidationResource.RequiredField, FieldResource.IdContaDestino))
                .NotNull().WithMessage(string.Format(ValidationResource.MustBeValid, FieldResource.IdContaDestino))
                .MustAsync(async (x, _) => await contaCorrenteRepository.GetByNumeroAsync(x) is not null)
                    .WithMessage(string.Format(ValidationResource.NotFound, FieldResource.ContaDestino));

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage(string.Format(ValidationResource.MustBeValid, FieldResource.Valor));
        }
    }
}
