using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NurgulSandalye.DataAccess.Abstract;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.DataAccess.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IAsyncRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext, new()
    {

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            using (var context = new TContext())
            {
                var evaluator = new SpecificationEvaluator<TEntity>();
                return await evaluator.GetQuery(context.Set<TEntity>().AsQueryable(), spec).CountAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> FirstAsync(ISpecification<TEntity> spec)
        {
            using (var context = new TContext())
            {
                var evaluator = new SpecificationEvaluator<TEntity>();
                return await evaluator.GetQuery(context.Set<TEntity>().AsQueryable(), spec).FirstAsync();
            }
        }

        public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            using (var context = new TContext())
            {
                var evaluator = new SpecificationEvaluator<TEntity>();
                return await evaluator.GetQuery(context.Set<TEntity>().AsQueryable(), spec).FirstOrDefaultAsync();
            };
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task<List<TEntity>> ListAllAsync()
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<List<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            using (var context = new TContext())
            {
                var evaluator = new SpecificationEvaluator<TEntity>();
                return await evaluator.GetQuery(context.Set<TEntity>().AsQueryable(), spec).ToListAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        //private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        //{
        //    using (var context = new TContext())
        //    {
        //        var evaluator = new SpecificationEvaluator<TEntity>();
        //        return evaluator.GetQuery(context.Set<TEntity>().AsQueryable(), spec).ToListAsync();
        //    }
        //}
    }
}
