using MediatR;

namespace Miotto.BankMore.TransferenciaApi.App.Commands
{
    public record NewTransferCommand(Guid IdContaOrigem, int NumeroContaDestino, decimal Valor, string Token) : IRequest;
}
