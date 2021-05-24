

using AutoMapper;
using Domain.DTO;
using Domain.DTO.Equipe;
using Domain.DTO.Produto;
using Domain.Entidades.Commands;

namespace Domain.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
       public DomainToDtoMappingProfile(){   
               
                CreateMap<Pedido,PedidoDTO>();
                 CreateMap<Produto,ProdutoDTO>();
                  CreateMap<Encomenda,EncomendaDTO>();
                     CreateMap<Equipe,EquipeDTO>();
       }     
    }
}