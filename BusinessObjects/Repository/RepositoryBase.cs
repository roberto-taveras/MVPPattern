using BusinessObjects.Context;
using BusinessObjects.Helpers;
using BusinessObjects.Interfaces;
using BusinessObjects.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessObjects.Repository
{

    public class RepositoryBase<TInterface, TEntity> : IDisposable, IRepositoryBase<TInterface, TEntity> where TEntity : class, TInterface, new()
    {
        public event RefreshData OnRefresh = null;
        public event Validate BeforeSave = null;
        public event Validate AfterSave = null;
        protected DbSet<TEntity> _dbSet;
        protected readonly HelperValidateEntity _helperValidateEntity;
        protected TEntity _entity = new TEntity();
        protected ICollection<ValidationResult> _validationResult;
        protected readonly CourseContext<TEntity> _context = CourseContext<TEntity>.Factory();
        private readonly TInterface _interfaceInstance;
        private readonly HelperAssignProperty<TInterface, TInterface> _helperAssignProperty = new HelperAssignProperty<TInterface, TInterface>();
        private bool _isDisposed = false;
        protected readonly BusinessObjectsResourceManager _businessObjectsResourceManager;



        public RepositoryBase(CourseContext<TEntity> context, TInterface interfaceInstance, BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            _context = context;

            _dbSet = _context.Set<TEntity>();

            _interfaceInstance = interfaceInstance;

            _helperValidateEntity = new HelperValidateEntity();

            _businessObjectsResourceManager = businessObjectsResourceManager;

            Add();
        }
        /// <summary>
        /// Implemente este contructor deberia por ejemplo hacerlo de la siguiente forma:
        /// </summary>
        /// <param name="interfaceInstance">Esta es la instacia de la interface implementada en el View</param>
        /// <param name="businessObjectsResourceManager">esta deberia ser una instacia unica de BusinessObjectsResourceManager</param>
        /// <example>
        /// <code>
        /// public CustomerPresenter(ICustomer customer, BusinessObjectsResourceManager businessObjectsResourceManager) : base( customer, businessObjectsResourceManager)
        /// {
        ///      _validator = new CustomerValidator(businessObjectsResourceManager);
        ///      _dbSet = _context.Set<Customer>();
        ///      Add();
        /// }
        /// </code>
        /// </example>
        public RepositoryBase(TInterface interfaceInstance, BusinessObjectsResourceManager businessObjectsResourceManager)
        {

            _interfaceInstance = interfaceInstance;

            _helperValidateEntity = new HelperValidateEntity();

            _businessObjectsResourceManager = businessObjectsResourceManager;


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

            _helperAssignProperty.AssingnProperty("entity_gather", "from_interface", _entity, _interfaceInstance);

            OnRefresh?.Invoke();
        }

        private void scatter()
        {

            _helperAssignProperty.AssingnProperty("interface_scatter", "from_entity", _interfaceInstance, _entity);

            OnRefresh?.Invoke();

        }

        private void detachAllEntities()
        {

            var changedEntriesCopy = _context.ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Added ||
                           e.State == EntityState.Modified ||
                           e.State == EntityState.Deleted)
               .ToList();

            changedEntriesCopy.ForEach((a) => { a.State = EntityState.Detached; });

        }

        public void Add()
        {
            detachAllEntities();

            _entity = new TEntity();

            scatter();

            _dbSet.Add(_entity);
        }

        public virtual void Delete(int id)
        {
            if (id < 1)
                return;

            if (_context.Entry(_entity).State == EntityState.Modified)
            {

                _context.Entry(_entity).State = EntityState.Deleted;

                Save();

                Add();

                afterDelete();
            }

        }

        public virtual void FindById(int id)
        {
            detachAllEntities();

            _entity = _dbSet.Find(id);

            if (_entity != null)
            {
                scatter();

                _context.Entry(_entity).State = EntityState.Modified;

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

            if (!executeValidations())
                return;

            beforeSave();

            BeforeSave?.Invoke();

            var result = _context.SaveChanges();

            afterSave();

            AfterSave?.Invoke();

            scatter();


        }

        private bool validateService()
        {
            return _helperValidateEntity.ValidateService(_entity);
        }
        private bool executeValidations()
        {
            var _notifyUI = _interfaceInstance as INotifyUI;

            if (_notifyUI == null)
                throw new Exception("El control inyectado a este presenter debe implementar la interface INotifyUI");

            _validationResult = new List<ValidationResult>();

            _notifyUI.ClearErrorsValidations(_validationResult);

            if (!validateService())
            {
                _validationResult = _helperValidateEntity.ValidationResult;
                _notifyUI.NotifyErrors(_validationResult);
                return false;
            }



            extendedValidations();

            if (_validationResult.Count != 0)
            {
                _notifyUI.NotifyErrors(_validationResult);
                return false;
            }
            return true;
        }

        protected virtual void afterSave()
        {

        }


        protected virtual void afterDelete()
        {

        }

        public virtual void Dispose()
        {
            if (!_isDisposed && _context != null)
            {
                _isDisposed = true;
                _context.Dispose();

            }
        }

    }

}
