
using ContaBancaria.Data;
using ContaBancaria.Shared.Repository;
using ContaBancaria.Shared.Services;

namespace ContaBancaria.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;

        }

        public async Task<bool> FazerDepositoAsync(string numeroConta, decimal valor)
        {
            var conta = await _contaRepository.ObterContaPorNumeroAsync(numeroConta);
            if (conta == null)
                return false;

            conta.Saldo += valor;
            await _contaRepository.AtualizarContaAsync(conta);
            return true;
        }

        public async Task<bool> FazerSaqueAsync(string numeroConta, decimal valor)
        {
            var conta = await _contaRepository.ObterContaPorNumeroAsync(numeroConta);
            if (conta == null || conta.Saldo < valor)
                return false;

            conta.Saldo -= valor;
            await _contaRepository.AtualizarContaAsync(conta);
            return true;
        }

        public async Task<bool> FazerTransferenciaAsync(string numeroContaOrigem, string numeroContaDestino, decimal valor)
        {
            var origem = await _contaRepository.ObterContaPorNumeroAsync(numeroContaOrigem);
            var destino = await _contaRepository.ObterContaPorNumeroAsync(numeroContaDestino);

            if (origem == null || destino == null || origem.Saldo < valor)
                return false;

            origem.Saldo -= valor;
            destino.Saldo += valor;

            await _contaRepository.AtualizarContaAsync(origem);
            await _contaRepository.AtualizarContaAsync(destino);

            return true;
        }

        public async Task<bool> FazerTransferenciaPixAsync(string chavePixOrigem, string chavePixDestino, decimal valor)
        {
            var clienteOrigem = await _contaRepository.ObterClientePorChavePixAsync(chavePixOrigem);
            var clienteDestino = await _contaRepository.ObterClientePorChavePixAsync(chavePixDestino);

            var contaOrigem = clienteOrigem?.Contas.FirstOrDefault(c => c.Pix == chavePixOrigem);
            var contaDestino = clienteDestino?.Contas.FirstOrDefault(c => c.Pix == chavePixDestino);

            if (contaOrigem == null || contaDestino == null || contaOrigem.Saldo < valor)
                return false;

            contaOrigem.Saldo -= valor;
            contaDestino.Saldo += valor;

            await _contaRepository.AtualizarContaAsync(contaOrigem);
            await _contaRepository.AtualizarContaAsync(contaDestino);

            return true;
        }
    }
}