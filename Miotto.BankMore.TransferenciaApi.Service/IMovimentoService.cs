using Miotto.BankMore.TransferenciaApi.Domain.Dtos;

namespace Miotto.BankMore.TransferenciaApi.Service
{
    public interface IMovimentoService
    {
        Task RegistrarTransferencia(MovimentoDto movimento);
    }
}
