using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.ViewModels
{
    public class PedidoFinalizadoViewModel
    {
        public string NumeroPedido { get; set; }
        public List<ItemPedidoViewModel> ItensPedidos { get; set; }
        public decimal ValorTotal { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
