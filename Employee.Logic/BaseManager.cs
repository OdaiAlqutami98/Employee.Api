using Employee.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Logic
{
    public abstract class BaseManager<TEntity, DbContext> where TEntity : class where DbContext : EmployeeDbContext
    {
        public EmployeeDbContext _context;
        public BaseManager(EmployeeDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Entity
        {
            get { return _context.Set<TEntity>(); }
        }
        public virtual async Task<TEntity?>GetById(Guid id)
        {
            return await Entity.FindAsync(id);
        }
        public virtual IQueryable<TEntity>Get(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return Entity.Where(expression);
            }
            else
            {
                return Entity;
            }
        }
        public virtual IQueryable<TEntity>GetAll(Expression<Func<TEntity,bool>>expression=null)
        {
            if (expression!=null)
            {
                return Entity.Where(expression);
            }
            else
            {
                return Entity;
            }
        }
        public virtual async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public virtual Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        } 
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
    

