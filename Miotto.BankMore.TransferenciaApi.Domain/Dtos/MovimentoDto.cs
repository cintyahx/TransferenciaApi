namespace Miotto.BankMore.TransferenciaApi.Domain.Dtos
{
    public class MovimentoDto
    {
        public int NumeroContaDestino { get; set; }
        public decimal Valor { get; set; }
        public string Token { get; set; }
    }
}
