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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public async Task<Pedido> ObterPorIdAsync(Guid id)
        {
            return await _context.Pedidos
                .Include(p => p.ItensPedido)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarItemAsync(ItemPedido itemPedido)
        {
            await _context.ItensPedidos.AddAsync(itemPedido);
        }

        public void AtualizarItem(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Update(itemPedido);
        }

        public void RemoverItem(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Remove(itemPedido);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
