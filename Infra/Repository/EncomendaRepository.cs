using Domain.Entidades;
using Domain.Entidades.Commands;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repository
{
    public class EncomendaRepository: Repository<Encomenda>, IEncomendaRepository
    {     
        public EncomendaRepository(BancoContext context) : base(context) {}
    }
}