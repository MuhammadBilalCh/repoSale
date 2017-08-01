
using System;
using System.Data;
using System.Data.Entity;


namespace DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //DbContext Context { get; set; }
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        Database GetDatabase();
        EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : class;
        void ReLoadEntity<TEntity>(TEntity entity) where TEntity : class;
        bool LazyLoadingEnabled { get; set; }
        bool ProxyCreationEnabled { get; set; }
        string ConnectionString { get; set; }
        void ChangeState(object entity, EntityState entityState);
        void Commit();

    }
}
