using JustBlog.Models.EnityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        TEntity Find(int key);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int Id);
        IList<TEntity> GetAll();
    }
}
