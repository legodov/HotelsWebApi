using System;
using HotelsWebApi.Models;

namespace HotelsWebApi.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;
        void SaveChanges();
    }
}
