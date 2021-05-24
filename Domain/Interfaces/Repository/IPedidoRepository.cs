using System;
using Domain.Entidades;
using Domain.Entidades.Commands;
using Domain.Entidades.Produto;
using Domain.Intefaces;

namespace Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
      
    }
}