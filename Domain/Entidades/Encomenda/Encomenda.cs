using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Core.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Entidades.Commands
{
    public class Encomenda : Entity<Encomenda>
    {
      
            private readonly ILazyLoader _lazyLoader;

            private Encomenda(ILazyLoader lazyLoader)     
            {
                _lazyLoader = lazyLoader;
            }

        public Encomenda()
        {
        }

        public Guid EquipeId{get;set;}
        private Pedido _Pedido;

              public Pedido Pedido {
                      get => _lazyLoader.Load(this, ref _Pedido);
                        set => _Pedido = value;
              }
  }
}