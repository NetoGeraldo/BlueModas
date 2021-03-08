using System;

namespace BlueModas.Domain
{
    public class ItemPedido
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public Pedido Pedido { get; set; }

        public ItemPedido(Guid pedidoId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public void AdicionarUnidades(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void AtualizarUnidades(int quantidade)
        {
            Quantidade = quantidade;
        }

    }
}
