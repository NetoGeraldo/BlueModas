using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Domain
{
    public class Pedido : Entity
    {
        private readonly List<ItemPedido> _itensPedido;

        public decimal ValorTotal { get; private set; }
        public IReadOnlyCollection<ItemPedido> ItensPedido => _itensPedido;
        public EStatusPedido Status { get; private set; }
        public DateTime DataFinalizacao { get; private set; }

        public Pedido()
        {
            _itensPedido = new List<ItemPedido>();
            Status = EStatusPedido.Rascunho;
        }

        public void FinalizarPedido()
        {
            DataFinalizacao = DateTime.Now;
            Status = EStatusPedido.Finalizado;
        }

        public void AdicionarItem(ItemPedido itemPedido)
        {
            bool itemPedidoExiste = ItemPedidoExistente(itemPedido);

            if (itemPedidoExiste)
            {
                var itemExistente = _itensPedido.SingleOrDefault(ip => ip.ProdutoId == itemPedido.ProdutoId);
                itemExistente.AtualizarUnidades(itemPedido.Quantidade);
            } 
            else
            {
                _itensPedido.Add(itemPedido);
            }

            CalcularPrecoTotal();
        }

        public void RemoverItem(ItemPedido itemPedido)
        {
            bool itemPedidoExiste = ItemPedidoExistente(itemPedido);

            if (itemPedidoExiste)
            {
                _itensPedido.Remove(itemPedido);
                CalcularPrecoTotal();
            }
        }

        private void CalcularPrecoTotal()
        {
            ValorTotal = _itensPedido.Sum(i => i.ValorUnitario * i.Quantidade);
        }

        public bool ItemPedidoExistente(ItemPedido itemPedido)
        {
            if (itemPedido is null)
                return false;

            return _itensPedido.Any(i => i.ProdutoId == itemPedido.ProdutoId);
        }

    }
}
