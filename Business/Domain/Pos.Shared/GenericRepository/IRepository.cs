using HRMaster.SharedKernel.Extensions.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Shared.GenericRepository
{
    public interface IRepository<TEntity,IModel,T>

        where TEntity:class,IEntity,new()
        where IModel:class, IVm,new()

        where T:IEquatable<T>
    {
        Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes);
        public Task<IModel> GetById(T id); Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate);
        Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes);
        Task<Paging<TResult>> GetPageAsync<TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes);

        public Task<IEnumerable<IModel>> GetList();
        Task<List<IModel>> GetAllAsyncd(Expression<Func<TEntity, bool>> predicate,
 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
 params Expression<Func<TEntity, object>>[] includes);
        public Task Delete(T id);

        public Task<IModel> Update(T id, TEntity entity);


        public Task<IModel> Add(TEntity entity);



    }
}




