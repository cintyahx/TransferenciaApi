using Microsoft.EntityFrameworkCore;
using Miotto.BankMore.TransferenciaApi.Domain.Entities;
using Miotto.BankMore.TransferenciaApi.Domain.Interfaces;
using Miotto.BankMore.TransferenciaApi.Infra.Contexts;

namespace Miotto.BankMore.TransferenciaApi.Infra.Repositories
{
    public class ContaCorrenteRepository : RepositoryBase<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(BankMoreContaContext dbContext) : base(dbContext)
        {
        }

        public Task<ContaCorrente?> GetByIdAsync(Guid id)
        {
            return Set.Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync();
        }

        public Task<ContaCorrente?> GetByNumeroAsync(int numero)
        {
            return Set.Where(x => x.Numero == numero && x.IsActive).FirstOrDefaultAsync();
        }
    }
}
