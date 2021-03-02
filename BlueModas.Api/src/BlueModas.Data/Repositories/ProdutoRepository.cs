using BlueModas.Data.Contexts;
using BlueModas.Domain;
using BlueModas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.AddAsync(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Update(produto);
        }

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos
                .AsNoTracking()
                .ToListAsync();
        }

        public void Remover(Produto produto)
        {
            _context.Remove(produto);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
