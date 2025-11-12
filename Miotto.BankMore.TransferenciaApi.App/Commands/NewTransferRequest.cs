using MediatR;

namespace Miotto.BankMore.TransferenciaApi.App.Commands
{
    public record NewTransferRequest(int NumeroContaDestino, decimal Valor) : IRequest;
}
