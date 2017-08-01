using System;
using System.Data.Entity;
using DataAccess.Utill;
using DataAccess.EntityFramework;

namespace DataAccess.Core
{


    public class UnitOfWork : IUnitOfWork
    {
        internal DbContext Context { get; set; }

        public UnitOfWork()
        {
            Context = new SaleEntities();
            ConfigureCotext();
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        public Database GetDatabase()
        {
            return Context.Database;
        }

        public EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : class
        {
            return Context.Entry(entity).State;
        }

        public void ReLoadEntity<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Entry(entity).Reload();
        }
        public bool LazyLoadingEnabled
        {
            get { return Context.Configuration.LazyLoadingEnabled; }
            set { Context.Configuration.LazyLoadingEnabled = value; }
        }

        public bool ProxyCreationEnabled
        {
            get { return Context.Configuration.ProxyCreationEnabled; }
            set { Context.Configuration.ProxyCreationEnabled = value; }
        }

        public string ConnectionString
        {
            get { return Context.Database.Connection.ConnectionString; }
            set { Context.Database.Connection.ConnectionString = value; }
        }

        void ConfigureCotext()
        {
            Context.Configuration.AutoDetectChangesEnabled = false;
            Context.Configuration.ValidateOnSaveEnabled = false;
            ProxyCreationEnabled = false;
            LazyLoadingEnabled = false;
        }
        public void ChangeState(object entity, EntityState entityState)
        {
            Context.Entry(entity).State = entityState;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex) //DbUpdateConcurrencyException ex)
            {
                var category = ExceptionClassifier.Classify(ex.InnerException.InnerException);
                if (category == ExceptionType.ForeignKey)
                    throw new Exception(ex.InnerException.InnerException.Message);
                else throw;
                //throw;
                //if (ex is DbUpdateConcurrencyException )
                //{
                //    var dbCCExp = ex as DbUpdateConcurrencyException ;
                //    dbCCExp.Entries.Single().Reload();
                //    Context.SaveChanges();
                //}
                //if (ex.InnerException != null)
                //{
                //    var category = ExceptionClassifier.Classify(ex.InnerException.InnerException);
                //    switch (category)
                //    {
                //        case ExceptionType.ForeignKey:
                //            throw;
                //            break;
                //    }
                //}
            }
        }
    }
}
