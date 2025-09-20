
using ContaBancaria.Entities;

namespace ContaBancaria.Shared.Repository
{
    public interface IContaRepository
    {
        Task<Cliente?> ObterClientePorIdAsync(Guid id);
        Task<Cliente?> ObterClientePorContaAsync(string numeroConta);
        Task<Cliente?> ObterClientePorChavePixAsync(string chavePix);
        Task AtualizarClienteAsync(Cliente cliente);
        Task<Conta?> ObterContaPorNumeroAsync(string numeroConta);
        Task AtualizarContaAsync(Conta conta);
    }
}