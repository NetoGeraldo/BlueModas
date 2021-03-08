using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.ViewModels
{
    public class AdicionarItemProdutoViewModel
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
