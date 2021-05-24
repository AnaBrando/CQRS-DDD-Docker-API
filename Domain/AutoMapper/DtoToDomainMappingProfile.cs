using AutoMapper;
using Domain.DTO;
using Domain.DTO.Encomenda;
using Domain.DTO.Equipe;
using Domain.DTO.Pedido;
using Domain.DTO.Produto;
using Domain.Entidades.Commands;

namespace Domain.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile(){

               //Pedido
               CreateMap<PedidoDTO, Pedido>();
                CreateMap<CadastroPedidoDTO, Pedido>();
         
              CreateMap<CadastroPedidoDTO, RegistrarPedidoCommand>()
                .ConstructUsing(add => new RegistrarPedidoCommand(add.Endereco,add.DataEntrega));
        
              CreateMap<PedidoDTO, EditarPedidoCommand>()
                .ConstructUsing(edicao => new EditarPedidoCommand(edicao.Endereco,edicao.DataEntrega,edicao.Id));

              CreateMap<PedidoDTO, ExcluirPedidoCommand>()
                .ConstructUsing(exclusao => new ExcluirPedidoCommand(exclusao.Id));     

                //Produto
                CreateMap<RegistrarProdutoCommand, AdicionaProdutoDTO>();
                   CreateMap<RegistrarProdutoCommand, Produto>();
               CreateMap<AdicionaProdutoDTO, RegistrarProdutoCommand>();
                CreateMap<ProdutoDTO, Produto>();
                     CreateMap<AdicionaProdutoDTO, RegistrarProdutoCommand>()
                .ConstructUsing(add => new RegistrarProdutoCommand(add.Descricao,add.Valor));

                 CreateMap<ProdutoDTO, Produto>();
                     CreateMap<ProdutoDTO, EditarProdutoCommand>()
                .ConstructUsing(edit => new EditarProdutoCommand(edit.Descricao,edit.Valor,edit.Id));
        
                     CreateMap<Produto, EditarProdutoCommand>();
        
               CreateMap<EditarProdutoCommand,Produto>();
        



               CreateMap<ProdutoDTO, Produto>();
                     CreateMap<ProdutoDTO, ExcluirProdutoCommand>()
                .ConstructUsing(excluir => new ExcluirProdutoCommand(excluir.Id));
                
                //Encomenda

                 CreateMap<RegistrarEncomendaCommand, Encomenda>();

                CreateMap<CadastrarEncomendaDTO, Encomenda>();
                     CreateMap<CadastrarEncomendaDTO, RegistrarEncomendaCommand>()
                .ConstructUsing(add => new RegistrarEncomendaCommand());
               CreateMap<EncomendaDTO, Encomenda>();
                     CreateMap<EncomendaDTO, EditarEncomendaCommand>()
                .ConstructUsing(edit => new EditarEncomendaCommand());
                
            CreateMap<CadastrarEncomendaDTO, Encomenda>();
                     CreateMap<EncomendaDTO, ExcluirEncomendaCommand>()
                .ConstructUsing(excluir => new ExcluirEncomendaCommand(excluir.Id));
         

               CreateMap<RegistrarEquipeCommand, Equipe>().ForAllOtherMembers(x=>x.Ignore());

                CreateMap<EquipeDTO, Equipe>();
                     CreateMap<AdicionaEquipeDTO, RegistrarEquipeCommand>()
                .ConstructUsing(add => new RegistrarEquipeCommand());
               CreateMap<EquipeDTO, Equipe>();
                     CreateMap<EquipeDTO, EditarEquipeCommand>()
                .ConstructUsing(edit => new EditarEquipeCommand());
            CreateMap<AdicionaEquipeDTO, Equipe>();
                     CreateMap<EquipeDTO, ExcluirEquipeCommand>()
                .ConstructUsing(excluir => new ExcluirEquipeCommand(excluir.Id));
        }
    }
}