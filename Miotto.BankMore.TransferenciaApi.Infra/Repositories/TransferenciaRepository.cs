using Microsoft.EntityFrameworkCore;
using Miotto.BankMore.TransferenciaApi.Domain.Entities;
using Miotto.BankMore.TransferenciaApi.Domain.Interfaces;
using Miotto.BankMore.TransferenciaApi.Infra.Contexts;

namespace Miotto.BankMore.TransferenciaApi.Infra.Repositories
{
    public class TransferenciaRepository : RepositoryBase<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(BankMoreTransferenciaContext tasksContext) : base(tasksContext)
        {
        }
    }
}
