using System;

namespace Core.Intefaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}