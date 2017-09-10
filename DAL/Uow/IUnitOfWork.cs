using Entities;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }        
        void Save();
    }
}