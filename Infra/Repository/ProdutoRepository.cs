using Domain.Entidades.Commands;
using Domain.Interfaces.Repository;
using Infra.Context;

namespace Infra.Repository
{
    public class ProdutoRepository: Repository<Produto>, IProdutoRepository
    {     
        public ProdutoRepository(BancoContext context) : base(context) {}
    }
  
}