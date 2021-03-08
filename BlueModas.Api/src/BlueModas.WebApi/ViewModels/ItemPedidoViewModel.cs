using System;

namespace BlueModas.WebApi.ViewModels
{
    public class ItemPedidoViewModel
    {
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
    }
}
