using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miotto.BankMore.TransferenciaApi.Domain.Entities;

namespace Miotto.BankMore.TransferenciaApi.Infra.Mappings
{
    public class TransferenciaMapping : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ContaCorrenteOrigemId).IsRequired();
            builder.Property(x => x.ContaCorrenteDestinoId).IsRequired();
            builder.Property(x => x.DataMovimento).IsRequired();
            builder.Property(x => x.Valor).IsRequired().HasPrecision(2);
        }
    }
}
