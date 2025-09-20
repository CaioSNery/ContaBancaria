

namespace ContaBancaria.Shared.Services
{
    public interface IContaService
    {
        Task<bool> FazerDepositoAsync(string numeroConta, decimal valor);
        Task<bool> FazerTransferenciaAsync(string numeroContaOrigem, string numeroContaDestino, decimal valor);
        Task<bool> FazerTransferenciaPixAsync(string chavePixOrigem, string chavePixDestino, decimal valor);
        Task<bool> FazerSaqueAsync(string numeroConta, decimal valor);
    
    
    }
}