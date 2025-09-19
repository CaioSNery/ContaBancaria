using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Data;
using ContaBancaria.Entities;
using ContaBancaria.Shared.Dtos;
using ContaBancaria.Shared.Repository;

namespace ContaBancaria.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> AdicionarClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> AtualizarClienteAsync(Guid id, ClienteUpdateDTO dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            cliente.AtualizarDados(dto.PrimeiroNome, dto.Sobrenome, dto.Cpf, dto.DataNascimento);
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AtualizarTipoDeContasAsync(Guid id, ContaUpdateDTO contadto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            cliente.AtualizarTipoDeConta(contadto.TipoConta);
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarClientePorIdAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}