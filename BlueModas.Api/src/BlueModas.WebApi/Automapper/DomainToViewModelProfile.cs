using AutoMapper;
using BlueModas.Domain;
using BlueModas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.Automapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();

            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(dest => dest.ItensPedidos, opt => opt.MapFrom(src => src.ItensPedido));

            CreateMap<ItemPedido, ItemPedidoViewModel>();
        }
    }
}
