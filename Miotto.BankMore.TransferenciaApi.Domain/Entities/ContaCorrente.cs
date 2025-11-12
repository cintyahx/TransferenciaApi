namespace Miotto.BankMore.TransferenciaApi.Domain.Entities
{
    public class ContaCorrente : BaseEntity
    {
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Salt { get; set; }
        public decimal Saldo { get; set; }
    }
}
