using AutoMapper;
using HRMaster.SharedKernel.Extensions.Pagging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Shared.GenericRepository
{
    public  abstract class RepositoryBase<TEntity, IModel, T> : IRepository<TEntity, IModel, T>
    where TEntity : class, IEntity,new ()
    where IModel : class, IVm, new()
    where T : IEquatable<T>                        

    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

     

        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();
        public RepositoryBase(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<IModel>> GetAllAsyncd(Expression<Func<TEntity, bool>> predicate,
  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
  params Expression<Func<TEntity, object>>[] includes)
        {


            var query = DbSet.Where(predicate);

            // Check if orderBy is provided before applying it
            if (orderBy != null)
            {
                // Apply orderBy to get an ordered queryable
                query = orderBy(query);
            }

            // Include the specified navigation properties
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            var data = await query.ToListAsync().ConfigureAwait(false);

           // Load nested collections separately
            //foreach (var include in includes)
            //{
            //    if (include.Body is MemberExpression memberExpression && memberExpression.Member is PropertyInfo property)
            //    {
            //        if (property.PropertyType.IsGenericType &&
            //            property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
            //        {
            //            foreach (var item in data)
            //            {
            //                _dbContext.Entry(item).Collection(property.Name).Load();
            //            }
            //        }
            //    }
            //}

            return _mapper.Map<List<IModel>>(data);
        }

        public async Task<IModel> Add(TEntity entity)
        {
            
            DbSet.Add(entity);           
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<IModel>(entity);
        }

        public async Task Delete(T id)
        {
            var entity = await DbSet.FindAsync(id);
            if(entity==null)
            {
                throw new Exception("Id Not Match");
            }
            _dbContext.Remove(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task<IModel> GetById(T id)
        {
            var entity = await DbSet.FindAsync(id);
            return _mapper.Map<IModel>(entity);
        }
        public async Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            var data = await DbSet.Where(predicate).OrderByDescending(e => e.Id).PagingAsync(pageIndex, pageSize);
            return data.ToPagingModel<TEntity, IModel>(_mapper);
        }
        public async Task<IModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return _mapper.Map<IModel>(await includes.Aggregate(DbSet.AsQueryable(),
                (current, include) => current.Include(include),
                c => c.AsNoTracking().FirstOrDefaultAsync(predicate))
                .ConfigureAwait(false));
        }
      
        public async Task<IEnumerable<IModel>> GetList()
        {
            var entityList = DbSet.AsAsyncEnumerable();
            return _mapper.Map<IEnumerable<IModel>>(entityList);
        }
        public async Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = await orderBy(includes.Aggregate(DbSet.AsQueryable(),
                (current, include) => current.Include(include)))
                .PagingAsync(pageIndex, pageSize);
            return data.ToPagingModel<TEntity, IModel>(_mapper);
        }

        public async Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {

            var data = await orderBy(includes.Aggregate(DbSet.AsQueryable(),
                (current, include) => current.Include(include), c => c.Where(predicate)))
                .PagingAsync(pageIndex, pageSize);
            return data.ToPagingModel<TEntity, IModel>(_mapper);
        }
        public async Task<Paging<TResult>> GetPageAsync<TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            return await orderBy(includes.Aggregate(DbSet.AsQueryable(),
                (current, include) => current.Include(include), c => c.Where(predicate)))
                .PagingAsync(selector, pageIndex, pageSize);

        }

        public async Task<IModel> Update(T id, TEntity entity)
        {
            
            if (!id.Equals(entity.Id))
            {
                throw new Exception("Id Not Match");
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
            return _mapper.Map<IModel>(entity);
        }
    }
}
