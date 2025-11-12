using Microsoft.Extensions.Configuration;
using Miotto.BankMore.TransferenciaApi.Domain.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Miotto.BankMore.TransferenciaApi.Service
{
    public class MovimentoService : IMovimentoService
    {
        private readonly HttpClient _httpClient;

        public MovimentoService(IConfiguration configuration)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(configuration.GetConnectionString("ContaCorrenteAPI"))
            };
        }

        public async Task RegistrarTransferencia(MovimentoDto movimento)
        {
            await RegistrarDebito(movimento);
            await RegistrarCredito(movimento);
        }

        private async Task RegistrarDebito(MovimentoDto movimento)
        {
            var body = new
            {
                NumeroContaDestino = movimento.NumeroContaDestino,
                Tipo = "D",
                Valor = movimento.Valor,
            };

            await EnviarRequest(body, movimento.Token);
        }

        private async Task RegistrarCredito(MovimentoDto movimento)
        {
            var body = new
            {
                NumeroContaDestino = movimento.NumeroContaDestino,
                Tipo = "C",
                Valor = movimento.Valor,
            };

            await EnviarRequest(body, movimento.Token);
        }

        private async Task EnviarRequest(object body, string Token)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(body));

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, "")
            {
                Content = jsonContent
            };

            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            using var response = await _httpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
                throw new Exception("Erro de conexão interna");
        }
    }
}
