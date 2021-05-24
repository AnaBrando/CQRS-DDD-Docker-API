using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using API.Core.Entity;
using Domain.Intefaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        private bool disposed = false;
        protected BancoContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(BancoContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            obj.Atualizar();
            DbSet.Update(obj);

        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(entity => entity.Ativo).Where(predicate);
        }

        public void Dispose()
        {
             Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Excluir(TEntity obj)
        {
            obj.Excluir();
            obj.Atualizar();
            DbSet.Update(obj);
        }
        protected virtual void Dispose(bool disposing)
                {
                    if (!this.disposed)
                    {
                        if (disposing)
                        {
                            Db.Dispose();
                        }
                    }
                    this.disposed = true;
                }
        public TEntity ObterPorId(Guid id)
        {
        return DbSet.FirstOrDefault(entity => entity.Ativo && entity.Id == id);
        }

        public TEntity ObterPorIdCompleto(Guid id)
        {
             return DbSet.FirstOrDefault(entity => entity.Ativo && entity.Id == id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
             return DbSet.Where(entity => entity.Ativo).ToList();
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}