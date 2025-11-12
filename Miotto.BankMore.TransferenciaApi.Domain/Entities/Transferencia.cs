namespace Miotto.BankMore.TransferenciaApi.Domain.Entities
{
    public class Transferencia : BaseEntity
    {
        public Guid ContaCorrenteOrigemId { get; set; }
        public Guid ContaCorrenteDestinoId { get; set; }
        public DateOnly DataMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
