
using ContaBancaria.Data;
using ContaBancaria.Entities;
using ContaBancaria.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContaBancaria.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly AppDbContext _context;
        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AtualizarClienteAsync(Cliente cliente)
        {
             _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
            
        }

        public async Task AtualizarContaAsync(Conta conta)
        {
             _context.Contas.Update(conta);
        await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> ObterClientePorChavePixAsync(string chavePix)
        {
            return await _context.Clientes
            .Include(c => c.Contas)
            .FirstOrDefaultAsync(c => c.Contas.Any(x => x.Pix == chavePix));
        }

        public async Task<Cliente?> ObterClientePorContaAsync(string numeroConta)
        {
           return await _context.Clientes
            .Include(c => c.Contas)
            .FirstOrDefaultAsync(c => c.Contas.Any(x => x.Numero == numeroConta));
        }

        public async Task<Cliente?> ObterClientePorIdAsync(Guid id)
        {
            return await _context.Clientes
            .Include(c => c.Contas)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Conta?> ObterContaPorNumeroAsync(string numeroConta)
        {
             return await _context.Contas.FirstOrDefaultAsync(c => c.Numero == numeroConta);
    }
        }
    }
