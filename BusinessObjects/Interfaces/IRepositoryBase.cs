using BusinessObjects.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessObjects.Interfaces
{
    public interface IRepositoryBase<TInterface, TEntity>:IDisposable where TEntity : class, TInterface, new()
    {
        event Validate AfterSave;
        event Validate BeforeSave;
        event RefreshData OnRefresh;

        void Add();
        void Delete(int id);
        void FindById(int id);
        IEnumerable<TEntity> Get(string sender);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        List<TEntity> GetAll();
        void Save();

    }
}