using Core.Intefaces;
using Infra.Context;

namespace Infra.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BancoContext _context;

        public UnitOfWork(BancoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            if (!_context.ChangeTracker.HasChanges())
                return true;

            bool hasCommit = false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                hasCommit = _context.SaveChanges() > 0;
                transaction.Commit();
            }

            return hasCommit;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}