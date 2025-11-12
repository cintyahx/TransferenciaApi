using Microsoft.EntityFrameworkCore;

namespace Miotto.BankMore.TransferenciaApi.Infra.Contexts
{
    public class BankMoreContaContext : DbContext
    {
        protected BankMoreContaContext() { }

        public BankMoreContaContext(DbContextOptions<BankMoreContaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ContaCorrenteMapping());
            //modelBuilder.ApplyConfiguration(new MovimentoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
