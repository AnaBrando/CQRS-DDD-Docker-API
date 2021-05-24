using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using API.Core.Entity;

namespace Domain.Intefaces
{
     public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        TEntity ObterPorIdCompleto(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}