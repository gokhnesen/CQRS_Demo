using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Persistance.Dynamic;
using Persistance.Entities;
using Persistance.Paging;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class EfRepositoryBase<TEntity,TEntityId,TContext>:
        IAsyncRepository<TEntity,TEntityId>,IRepository<TEntity,TEntityId> where TEntity : Entity<TEntityId> where TContext: DbContext
    {
        protected readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                entity.CreatedDate = DateTime.UtcNow;
                await Context.AddAsync(entities);
                await Context.SaveChangesAsync();
                return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();
            if(predicate != null)
                queryable = queryable.Where(predicate);
            return await queryable.AnyAsync(cancellationToken);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool permament = false)
        {
            await SetEntityAsDeletedAsync(entity, permament);
            await Context.SaveChangesAsync();
            return entity;
        }

      

        public Task<ICollection<TEntity>> DeleteRangeAsnyc(ICollection<TEntity> entity, bool permament = false)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<TEntity>> GetListyAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<TEntity>> GetListyByDynamicAsync(DynamicQuery dynamic, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> UpdateRangeAsnyc(ICollection<TEntity> entity)
        {
            throw new NotImplementedException();
        }




        protected async Task SetEntityAsDeletedAsync(TEntity entity, bool permament)
        {
           if(!permament)
            {
                CheckHasEntityHaveOneToOneRelation(entity);
                await setEntityAsSoftDeletedAsync(entity);
            }
           else
            {
                Context.Remove(entity);
            }
        }

        protected void CheckHasEntityHaveOneToOneRelation(TEntity entity)
        {
            bool hasEntityHaveOneToOneRelation = Context.Entry(entity).Metadata.GetForeignKeys().All(
                x=>x.DependentToPrincipal?.IsCollection == true
                || x.PrincipalToDependent?.IsCollection == true
                || x.DependentToPrincipal?.ForeignKey.DeclaringEntityType.ClrType == entity.GetType()) == false;

            if (hasEntityHaveOneToOneRelation)
                throw new InvalidOperationException(
                    "Entity has one-to-one relationship. Soft delete causes problems if you try to create entry again by same foreignkey");

        }

        private async Task setEntityAsSoftDeletedAsync(IEntityTimestamps entity)
        {
            if (entity.DeletedDate.HasValue)
                return;
            entity.DeletedDate = DateTime.UtcNow;

            var navigations = Context.Entry(entity).Metadata.GetNavigations().Where(x=>x is { IsOnDependent:false, ForeignKey.DeleteBehavior:DeleteBehavior.ClientCascade or DeleteBehavior.Cascade})
                .ToList();

            foreach (INavigation? navigation in navigations)
            {
                if (navigation.TargetEntityType.IsOwned())
                    continue;
                if (navigation.PropertyInfo == null)
                    continue;

                object? navValue = navigation.PropertyInfo.GetValue(entity);
                if(navigation.IsCollection)
                {
                    if(navValue == null)
                }
            }
        }


    }
}
