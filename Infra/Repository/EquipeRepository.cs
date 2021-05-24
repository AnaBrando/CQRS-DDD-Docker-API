using Domain.Entidades.Commands;
using Domain.Interfaces.Repository;
using Infra.Context;

namespace Infra.Repository
{
    public class EquipeRepository: Repository<Equipe>, IEquipeRepository
    {     
        public EquipeRepository(BancoContext context) : base(context) {}
    }
}