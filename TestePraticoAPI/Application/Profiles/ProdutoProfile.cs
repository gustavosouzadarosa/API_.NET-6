using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Response;

namespace Application.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(x => x.DtFabricacao, map => map.MapFrom(y => y.DataFabricacao))
                .ForMember(x => x.DtValidade, map => map.MapFrom(y => y.DataValidade));

            CreateMap<ProdutoDTO, Produto>()
                .ForMember(x => x.Codigo, map => map.MapFrom(y => y.Codigo > 0 ? y.Codigo : null))
                .ForMember(x => x.FornecedorCodigo, map => map.MapFrom(y => y.FornecedorCodigo > 0 ? y.FornecedorCodigo : null))
                .ForMember(x => x.DataFabricacao, map => map.MapFrom(y => y.DtFabricacao))
                .ForMember(x => x.DataValidade, map => map.MapFrom(y => y.DtValidade));
        }
    }
}
