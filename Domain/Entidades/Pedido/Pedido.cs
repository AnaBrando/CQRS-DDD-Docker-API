using System;
using System.Collections.Generic;
using API.Core.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Entidades.Commands
{
    public class Pedido : Entity<Pedido>
    {
        private readonly ILazyLoader _lazyLoader;
        public Pedido(){
            Produtos = new List<Produto>();
        }
        private Pedido(ILazyLoader lazyLoader)     
        {
            _lazyLoader = lazyLoader;
        }
        public string Endereco { get; set; }
 
        public DateTime DataEntrega { get; set; }
        private List<Produto> _Produtos;
         public List<Produto> Produtos {
                  get => _lazyLoader.Load(this, ref _Produtos);
                    set => _Produtos = value;
         }

         
    }
}