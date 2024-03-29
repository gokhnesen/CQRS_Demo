﻿using Application.Features.Dynamic;
using Application.Features.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAsyncRepository<TEntity,TEntityId> : IQuery<TEntity> where TEntity : Entity<TEntityId>
    {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity,bool>> predicate,Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>>? include =null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
            );

        Task<Paginate<TEntity>> GetListyAsync(
            Expression<Func<TEntity,bool>>? predicate = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
            int index =0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
            );

        Task<Paginate<TEntity>> GetListyByDynamicAsync(
            DynamicQuery dynamic,
            Expression<Func<TEntity,bool>>? predicate = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
            int index =0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
            );

        Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
            );

        Task<TEntity> AddAsync(TEntity entity);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<ICollection<TEntity>> UpdateRangeAsnyc(ICollection<TEntity> entities);

        Task<TEntity> DeleteAsync(TEntity entity, bool permament = false);

        Task<ICollection<TEntity>> DeleteRangeAsnyc(ICollection<TEntity> entity, bool permament = false);
    }
}
