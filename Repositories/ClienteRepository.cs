using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContaBancaria.Data;
using ContaBancaria.Entities;
using ContaBancaria.Shared.Dtos;
using ContaBancaria.Shared.Repository;

namespace ContaBancaria.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Cliente> AdicionarClienteAsync(ClienteCreateDTO clientedto)
        {
            var cliente = _mapper.Map<Cliente>(clientedto);
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteUpdateDTO?> AtualizarClienteAsync(Guid id, ClienteUpdateDTO dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return null;

            _mapper.Map(dto, cliente);
            
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteUpdateDTO>(cliente);
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