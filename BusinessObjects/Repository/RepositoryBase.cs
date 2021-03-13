using BusinessObjects.Context;
using BusinessObjects.Helpers;
using BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessObjects.Repository
{

    public class RepositoryBase<TInterface, TEntity> :IDisposable, IRepositoryBase<TInterface, TEntity> where TEntity : class, TInterface, new()
    {
        public event RefreshData OnRefresh = null;
        TEntity cust = new TEntity();
        private readonly CourseContext<TEntity> _context = CourseContext<TEntity>.Factory();
        private readonly TInterface _interfaceInstance;
        private readonly HelperAssignProperty<TInterface, TInterface> _helperAssignProperty = new HelperAssignProperty<TInterface, TInterface>();
        protected DbSet<TEntity> _dbSet;
        public event Validate BeforeSave;
        public event Validate AfterSave;
        private bool _isDisposed = false;
        public RepositoryBase(TInterface sender)
        {

            _dbSet = _context.Set<TEntity>();
            _interfaceInstance = sender;

            Add();
        }

        public virtual List<TEntity> GetAll()
        {
            return _dbSet.ToList<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }


            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }

        }

        private void gather()
        {

            _helperAssignProperty.AssingnProperty("entity", "interface", cust, _interfaceInstance);

            OnRefresh?.Invoke();
        }

        private void scatter()
        {

            _helperAssignProperty.AssingnProperty("interface", "entity", _interfaceInstance, cust);

            OnRefresh?.Invoke();

        }

        private void detachAllEntities()
        {

            var changedEntriesCopy = _context.ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Added ||
                           e.State == EntityState.Modified ||
                           e.State == EntityState.Deleted)
               .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public void Add()
        {
            detachAllEntities();
            cust = new TEntity();
            scatter();
            _dbSet.Add(cust);
        }

        public virtual void Delete(int id)
        {
            if (id < 1)
                return;

            if (_context.Entry(cust).State == EntityState.Modified)
            {

                _context.Entry(cust).State = EntityState.Deleted;

                Save();

                Add();

                afterDelete();
            }

        }

        public virtual void FindById(int id)
        {
            detachAllEntities();

            cust = _dbSet.Find(id);

            if (cust != null)
            {
                scatter();
                _context.Entry(cust).State = EntityState.Modified;

                return;
            }

            Add();

        }

        protected virtual void extendedValidations()
        {

        }
        protected virtual void beforeSave()
        {

        }
        public virtual void Save()
        {
            gather();
            extendedValidations();
            beforeSave();
            BeforeSave?.Invoke();
            var result = _context.SaveChanges();
            afterSave();
            AfterSave?.Invoke();
            scatter();


        }
        protected virtual void afterSave()
        {
            
        }

        
        protected virtual void afterDelete()
        {

        }

        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _context.Dispose();
                _isDisposed = true;
            }
        }
    }
}
