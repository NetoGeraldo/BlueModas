using BlueModas.Data.Contexts;
using BlueModas.Domain;
using BlueModas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public Task<Cliente> ObterPorEmailAsync(string email)
        {
            return _context.Clientes.SingleOrDefaultAsync(c => 
                c.Email.Equals(email));
        }

        public Task<Cliente> ObterPorIdAsync(Guid id)
        {
            return _context.Clientes.SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
