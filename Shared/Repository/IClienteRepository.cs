
using ContaBancaria.Entities;
using ContaBancaria.Shared.Dtos;

namespace ContaBancaria.Shared.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> AdicionarClienteAsync(ClienteCreateDTO clientedto);
        Task<bool> DeletarClientePorIdAsync(Guid id);
        Task<ClienteUpdateDTO?> AtualizarClienteAsync(Guid id,ClienteUpdateDTO dto);
        Task<bool> AtualizarTipoDeContasAsync(Guid id, ContaUpdateDTO contadto);

    }
}
