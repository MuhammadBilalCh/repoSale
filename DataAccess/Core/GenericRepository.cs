using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Utill;
using DataAccess.Helper;

namespace DataAccess.Core
{
    /// <summary>
    /// A generic repository for working with data in the database
    /// </summary>
    /// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
    public class GenericRepository<TEntity> : BaseRepository, IRepository<TEntity> where TEntity : class 
    {   
        /// <summary>
        /// The _dbSet that represents the current entity.
        /// </summary>
        private DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the GenericRepository class
        /// </summary>
        /// <param name="contextType"></param>
        public GenericRepository()
        {
            _dbSet = _unitOfWork.GetDbSet<TEntity>();
        }

        /// <summary>
        /// Initializes a new instance of the GenericRepository class
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork to instanciate Entity Framework DbContext</param>
        public GenericRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbSet = _unitOfWork.GetDbSet<TEntity>();
        }

        public IEnumerable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                                       IOrderedQueryable<TEntity>> orderBy = null,
                                       string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (
                var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy != null ? orderBy(query).ToList() : query.ToList();

        }
        /// <summary>
        /// Gets all records as an IQueryable
        /// </summary>
        /// <returns>An IQueryable object containing the results of the query</returns>
        private  IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Gets all records as an IEnumberable
        /// </summary>
        /// <returns>An IEnumberable object containing the results of the query</returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetQuery().AsEnumerable();
        }

        /// <summary>
        /// Finds a record with the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A collection containing the results of the query</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where<TEntity>(predicate);
        }

        /// <summary>
        /// Finds a record with the specified id
        /// </summary>
        /// <param name="id">id to match on</param>
        /// <returns>Finds entity by primary key</returns>
        public TEntity Find(decimal id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> FindDistinct(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Distinct().Where<TEntity>(predicate);
        }
        
        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Single(predicate);
        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = _dbSet.FirstOrDefault(predicate) ?? (TEntity)Activator.CreateInstance(typeof(TEntity));

            return entity;
        }

      

        /// <summary>
        /// Adds the specified entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public virtual void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Add(entity);
        }

        public virtual void AddMany(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.AddRange(entities);
        }

        /// <summary>
        /// Updates the specified entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            AttachWithState(entity, EntityState.Modified);
        }

        /// <summary>
        /// Deletes the specified entitiy
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (_unitOfWork.GetEntityState(entity) == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
        public virtual void  DeleteMany(IEnumerable<TEntity> entities)
        {

            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            foreach (var entity in entities)
            {
                if (_unitOfWork.GetEntityState(entity) == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
            }
          
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Attaches the specified entity
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        public void Attach(TEntity entity)
        {
            _dbSet.Attach(entity);
        }

        /// <summary>
        /// Attaches the specified entity with its State
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        /// <param name="entityState">Entity current State</param>
        public virtual void AttachWithState(TEntity entity, EntityState entityState)
        {
            _dbSet.Attach(entity);
            _unitOfWork.ChangeState(entity, entityState);
        }

        public void ReLoadEntity(TEntity entity)
        {
            _unitOfWork.ReLoadEntity(entity);
        }

        public virtual void CommitChanges()
        {
            _unitOfWork.Commit();
            //foreach (var entity in _dbSet)
            //{
            //    if (UnitOfWork.Context.Entry(entity).State == EntityState.Added)
            //        UnitOfWork.Context.Entry(entity).Reload();
            //}

        }

        public PagedList<TEntity> GetPagedList(int pageIndex, int pageSize)
        {
            return GetQuery().ToPagedList(pageIndex, pageSize);
        }

        public PagedList<TEntity> GetPagedList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter)
        {
            return GetQuery().Where(filter).ToPagedList(pageIndex, pageSize);
        }

        public PagedList<TEntity> GetPagedList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, bool>> sort)
        {
            return GetQuery().Where(filter).OrderBy(sort).ToPagedList(pageIndex, pageSize);
        }

        public PagedList<TEntity> GetPagedList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, bool>> sort, SortDirection direction)
        {
            if (direction == SortDirection.Ascending)
                return GetQuery().Where(filter).OrderBy(sort).ToPagedList(pageIndex, pageSize);
            else
                return GetQuery().Where(filter).OrderByDescending(sort).ToPagedList(pageIndex, pageSize);
        }

        //For DDL Queries
        public IEnumerable<TEntity> ExcecuteSqlQuery(string sqlQuery)
        {
            return _unitOfWork.GetDatabase().SqlQuery<TEntity>(sqlQuery);
        }

      //For DML Queries
        public int ExecuteSqlCommand(string sqlQuery)
        {
            return _unitOfWork.GetDatabase().ExecuteSqlCommand(sqlQuery);
        }
        
    }
}
