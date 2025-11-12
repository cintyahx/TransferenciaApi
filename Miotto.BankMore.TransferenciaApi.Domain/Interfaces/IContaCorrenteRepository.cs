using Miotto.BankMore.TransferenciaApi.Domain.Entities;

namespace Miotto.BankMore.TransferenciaApi.Domain.Interfaces
{
    public interface IContaCorrenteRepository : IRepository<ContaCorrente>
    {
        Task<ContaCorrente?> GetByIdAsync(Guid id);
        Task<ContaCorrente?> GetByNumeroAsync(int numero);
    }
}
