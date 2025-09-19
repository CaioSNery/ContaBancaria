using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Entities;
using ContaBancaria.Shared.Dtos;

namespace ContaBancaria.Shared.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> AdicionarClienteAsync(Cliente cliente);
        Task<bool> DeletarClientePorIdAsync(Guid id);
        Task<bool> AtualizarClienteAsync(Guid id,ClienteUpdateDTO dto);
        Task<bool> AtualizarTipoDeContasAsync(Guid id, ContaUpdateDTO contadto);

    }
}
