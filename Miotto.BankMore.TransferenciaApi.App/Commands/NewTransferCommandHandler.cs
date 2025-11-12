using MediatR;
using Miotto.BankMore.TransferenciaApi.Domain.Dtos;
using Miotto.BankMore.TransferenciaApi.Domain.Entities;
using Miotto.BankMore.TransferenciaApi.Domain.Interfaces;
using Miotto.BankMore.TransferenciaApi.Service;

namespace Miotto.BankMore.TransferenciaApi.App.Commands
{
    public class NewTransferCommandHandler : IRequestHandler<NewTransferCommand>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentoService _movimentoService;
        private readonly ITransferenciaRepository _transferenciaRepository;

        public NewTransferCommandHandler(IContaCorrenteRepository contaCorrenteRepository,
            IMovimentoService movimentoService,
            ITransferenciaRepository transferenciaRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _movimentoService = movimentoService;
            _transferenciaRepository = transferenciaRepository;
        }

        public async Task Handle(NewTransferCommand request, CancellationToken cancellationToken)
        {
            var contaDestino = await _contaCorrenteRepository.GetByNumeroAsync(request.NumeroContaDestino);

            if (contaDestino is null)
                throw new InvalidOperationException("INVALID_ACCOUNT");

            if (!contaDestino.IsActive)
                throw new InvalidOperationException("INACTIVE_ACCOUNT");

            var movimentoDto = new MovimentoDto()
            {
                NumeroContaDestino = request.NumeroContaDestino,
                Valor = request.Valor,
                Token = request.Token
            };

            var transferencia = new Transferencia()
            {
                ContaCorrenteDestinoId = contaDestino.Id,
                ContaCorrenteOrigemId = request.IdContaOrigem,
                DataMovimento = DateOnly.FromDateTime(DateTime.Now),
                Valor = request.Valor
            };

            await _movimentoService.RegistrarTransferencia(movimentoDto);
            await _transferenciaRepository.CreateAsync(transferencia);
        }
    }
}
