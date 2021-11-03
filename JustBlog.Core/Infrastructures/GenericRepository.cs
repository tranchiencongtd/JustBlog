using JustBlog.Models.EnityBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Infrastructures
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly AppDbContext context;
        protected DbSet<TEntity> dbSet;
       
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Find(int key)
        {
            return this.dbSet.Find(key);
        }

        public virtual void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            //this.DbSet.Update(entity);

        }

        public virtual void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public virtual void Delete(int Id)
        {
            this.dbSet.Remove(dbSet.Find(Id));
        }

        public virtual IList<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

      
    }
}
