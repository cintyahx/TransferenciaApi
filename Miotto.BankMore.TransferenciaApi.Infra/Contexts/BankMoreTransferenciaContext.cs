using Microsoft.EntityFrameworkCore;
using Miotto.BankMore.TransferenciaApi.Infra.Mappings;

namespace Miotto.BankMore.TransferenciaApi.Infra.Contexts
{
    public class BankMoreTransferenciaContext : DbContext
    {
        protected BankMoreTransferenciaContext() { }

        public BankMoreTransferenciaContext(DbContextOptions<BankMoreTransferenciaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransferenciaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
