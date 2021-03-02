using AutoMapper;
using BlueModas.Domain;
using BlueModas.WebApi.ViewModels;

namespace BlueModas.WebApi.Automapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}
