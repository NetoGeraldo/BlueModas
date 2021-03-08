using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Domain.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Pedido pedido);
        void Atualizar(Pedido pedido);

        Task AdicionarItemAsync(ItemPedido itemPedido);
        void AtualizarItem(ItemPedido itemPedido);
        void RemoverItem(ItemPedido itemPedido);
    }
}
