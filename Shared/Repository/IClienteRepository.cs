using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Entities;

namespace ContaBancaria.Shared.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> AdicionarClienteAsync(Cliente cliente);
        Task<bool> DeletarClientePorIdAsync(Guid id);
        Task<bool> AtualizarClienteAsync(Cliente clienteupdate);
        Task<bool> AtualizarTipoDeContasAsync(Guid id, string tipoDeConta);

    }
}
