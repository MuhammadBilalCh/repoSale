using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Utill;
using DataAccess.Helper;

namespace DataAccess.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    /// <remarks></remarks>
	public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null,
                                     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>
                                         orderBy = null,
                                     string includeProperties = "");
        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
	//	IQueryable<TEntity> GetQuery();

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
		IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		/// <summary>
		/// Finds the entity based on the id.
		/// </summary>
		/// <param name="predicate">The primary id.</param>
		/// <returns></returns>
		/// <remarks></remarks>
		TEntity Find(decimal id);
        /// <summary>
        /// Finds the distinct.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IEnumerable<TEntity> FindDistinct(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		PagedList<TEntity> GetPagedList(int pageIndex, int pageSize);
        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		PagedList<TEntity> GetPagedList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="sort">The sort.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		PagedList<TEntity> GetPagedList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, bool>> sort);
        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		PagedList<TEntity> GetPagedList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, bool>> sort, SortDirection direction);

        /// <summary>
        /// Singles the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		TEntity Single(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Firsts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		TEntity First(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        //IEnumerable<TEntity> ExcecuteSqlQuery(string sqlQuery);

        //int ExecuteSqlCommand(string sqlQuery);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <remarks></remarks>
		void Add(TEntity entity);

        void AddMany(IEnumerable<TEntity> entities);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <remarks></remarks>
        void Update(TEntity entity);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <remarks></remarks>
		void Delete(TEntity entity);

        void DeleteMany(IEnumerable<TEntity> entities);
        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <remarks></remarks>
		void Attach(TEntity entity);

        void ReLoadEntity(TEntity entity);

        void AttachWithState(TEntity entity, EntityState entityState);

        void CommitChanges();

    }

}
