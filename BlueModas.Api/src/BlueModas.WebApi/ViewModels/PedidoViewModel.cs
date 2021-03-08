using BlueModas.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.ViewModels
{
    public class PedidoViewModel
    {
        public List<ItemPedidoViewModel> ItensPedidos { get; set; }
        public decimal ValorTotal { get; private set; }
    }
}
