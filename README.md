# MVP Pattern
- Example project using:
- MVP design pattern (Model-View-Presenter)
- Reflection
- Delegates
- Events
- Generic Repository
- Dependency injection
- Databindings in Windows Forms
- Translations
- Model validations
- Fluent Validations
- Globalization (es-DO (Spanish), en-US (English))

<p align="center">
  <img width="460" height="460" src="/WinFormsAppBindings/Assets/MVP.png">
</p>
(https://medium.com/android-news/mvp-depp-dive-c6bb1903ace1)

# The BusinessObjects has the following parts:
 
In essence it has a generic repository, with which the presenters are developed, 
these presenters validate the entities with the information of the model but it can also be extended,
using Fluent Validation if it is required to add Rules, as it is used in the project.

# Introduction

The project shows how to reduce code when creating Windows Forms applications using generic repositories, 
helpers using the provider error so as not to have to apply it manually in each validation, 
if not to do it automatically as CRUD works in MVC applications.

# Parts of BusinessObjetcs & Dependencies
- EntityFramework.6.4.4
- Fluent Validation 9.0.0.0: https://fluentvalidation.net/
- The BusinessObjects library uses Standard Net (4.8)
- WinFormsAppBindings has as dependency .Net 5.0
- https://wisej.com

# The BusinessObjects has the following parts:

1. `Context => CourseContext`: which is responsible for mapping some of the models that are linked to each table.
```csharp
using BusinessObjects.Models;
using BusinessObjects.Resources;
using System.Data.Entity;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace BusinessObjects.Context
{
    public class CourseContext<TEntity> : DbContext
    {
       
        private string cultureName { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
        public static CourseContext<TEntity> Factory()
        { 
          
            return new CourseContext<TEntity>("Curso");

        }

        protected CourseContext(string nameOrConnectionString, string cultureName = "es-DO") :base(nameOrConnectionString)
        {
            this.cultureName = cultureName;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.Database.CommandTimeout = 180;

        }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Vendor>().ToTable("Vendors");
            modelBuilder.Entity<CustomerType>().ToTable("CustomerTypes");
            modelBuilder.Entity<VendorType>().ToTable("VendorTypes");
            base.OnModelCreating(modelBuilder);

        }
       
    }
}
```
2. `HelperAssignProperty`: Its function is to assign getters and setters (between the interface that is injected from the view and the model that is instantiated in the presenter).
```csharp
using System;
using System.Linq;

namespace BusinessObjects.Helpers 
{
    public class HelperAssignProperty<T,U>  
    {
           public void AssingnProperty(string instanceToSet,string instanceFrom, T toSet, U fromSet) {
            var propertiestToSet = typeof(T).GetProperties();
            var propertiestFromSet = typeof(U).GetProperties();

            foreach (var p in propertiestToSet)
            {
                //Veficando si p tiene get and set publicos
                bool isPublic = p.GetSetMethod() != null;
                if (!isPublic)
                    continue;

                var result = propertiestFromSet.Where(k => k.Name == p.Name ).FirstOrDefault();
                if (result == null)
                    throw new InvalidCastException($"La propiedad {p.Name} de {instanceToSet} no existe en {instanceFrom} ..!!");

                if(p.GetType() !=  result.GetType())
                    throw new InvalidCastException($"La propiedad {p.Name} {instanceToSet} tiene un tipo de dato { p.GetType()} y {instanceFrom} tiene un tipo de dato {result.GetType()}  {instanceFrom} ..!!");

                try
                {
                    p.SetValue(toSet, result.GetValue(fromSet,null), null);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Hay un error de tipos con la propiedad {p.Name}  verifique {instanceToSet} y {instanceFrom} Exception {ex.Message}" );
                }
              
            }
        }

    }
}

```

3. `HelperValidateEntity`: It is in charge of the validations of the model based on the restrictions that are placed in each validation of the fields of the Bit that each table represents.

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessObjects.Helpers
{
    public class HelperValidateEntity
    {
        public ICollection<ValidationResult> ValidationResult { get; set; }
        public  bool ValidateService(object sender)
        {
            ValidationContext validationContext = new ValidationContext(sender);
            ValidationResult = new List<ValidationResult>();
            return Validator.TryValidateObject(sender, validationContext, ValidationResult, true);
        }
    }
}
```
4. `Interfaces` : It contains the interfaces related to some of the models of each table and a special interface called INofitify that is injected from the view to the presenter to establish the entire validation mechanism.
```csharp
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BusinessObjects.Interfaces
{
    public interface INotifyUI
    {
        void ClearErrorsValidations(ICollection<ValidationResult> sender);
        void NotifyErrors(ICollection<ValidationResult> sender);
    }
}

using BusinessObjects.Models;

namespace BusinessObjects.Interfaces
{
    public interface ICustomer
    {        
        int Id { get; set; }
        string CustName { get; set; }
        string Adress { get; set; }
        bool Status { get; set; }
        int CustomerTypeId { get; set; }
        CustomerType CustomerType { get; set; }

    }
}
```
5. `Models`: It contains the few of each class, these implement interfaces that have to have exactly the same properties as the models so that the getters and setters are executed correctly in the helper (HelperAssignProperty).
```csharp
using BusinessObjects.Interfaces;
using BusinessObjects.Resources;
using System.ComponentModel.DataAnnotations;


namespace BusinessObjects.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        [MaxLength(70, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string CustName { get; set; }
        [MaxLength(120, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

    }
}
```
6 `Repository` It contains the few of each class, these implement interfaces that have to have exactly the same properties as the models so that the getters and setters are executed correctly in the helper (HelperAssignProperty).Contiene un repositorio gen??rico `RespositoryBase` e implementa `IRepositoryBase` cuya funci??n es reutilizar el c??digo, y evitar tener que hacer lo mismo una y otra vez, se implementa en cada presentador y cuenta con m??todos y eventos virtuales que se pueden utilizar para aumentar su flexibilidad:
```csharp
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

    public abstract class RepositoryBase<TInterface, TEntity> : IDisposable, IRepositoryBase<TInterface, TEntity> where TEntity : class, TInterface, new()
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
        private readonly INotifyUI _notifyUI;



        public RepositoryBase(CourseContext<TEntity> context, TInterface interfaceInstance, BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            _context = context;

            _dbSet = _context.Set<TEntity>();

            _interfaceInstance = interfaceInstance;

            _notifyUI = _interfaceInstance as INotifyUI;

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


            _notifyUI = _interfaceInstance as INotifyUI;


            _helperValidateEntity = new HelperValidateEntity();

            _businessObjectsResourceManager = businessObjectsResourceManager;


        }
        public virtual List<TEntity> GetAll()
        {
            return _dbSet.ToList<TEntity>();
        }

        public abstract IEnumerable<TEntity>  Get(string sender);

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int top = 50)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);

            }

            query.Take(top);


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
```

7. `Presenters`: They implement RepositoryBase and they can be overwritten and extended with Fluent Validations.
```csharp
/*CustomerPresenter implementando CustomerValidator*/

using BusinessObjects.Context;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Repository;
using BusinessObjects.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;

namespace BusinessObjects.Presenters
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
       
       
        public CustomerValidator(BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            RuleFor(x => x.CustomerTypeId).GreaterThan(0).WithMessage(businessObjectsResourceManager.Translate("RequiredErrorMessage") ?? ($"El campo {nameof(Customer.CustomerTypeId)} es requerido")); 

        }

    }

    public class CustomerPresenter : RepositoryBase<ICustomer,Customer>
    {
        private readonly CustomerValidator _validator;
        public CustomerPresenter(ICustomer customer, BusinessObjectsResourceManager businessObjectsResourceManager) : base( customer, businessObjectsResourceManager)
        {
            _validator = new CustomerValidator(businessObjectsResourceManager);

            _dbSet = _context.Set<Customer>();

            Add();


        }
        protected override void extendedValidations()
        {
            var  validations = _validator.Validate(this._entity);
            if (!validations.IsValid)
            {
                foreach (var item in validations.Errors)
                {
                    var fields = new List<string>();
                    fields.Add(item.PropertyName);
                    ValidationResult validation = new ValidationResult(item.ErrorMessage, fields);
                    this._validationResult.Add(validation);

                }
            }
           
        }

        public  override IEnumerable<Customer> Get(string sender) 
        {
            Expression<Func<Customer, bool>> filter = (customer) => customer.CustName.ToLower().Contains(sender) || customer.Adress.ToLower().Contains(sender);
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderFunc = orderByName => orderByName.OrderBy(cust => cust.CustName);
            return this.Get(filter, orderFunc).Select(a => new  Customer {Id=  a.Id, CustName= a.CustName,Adress=  a.Adress, CustomerType = a.CustomerType,Status=  a.Status }).ToList();
        }

    }    
}


```
8. `Resources`: Contains resource files and a `BusinessObjectsResourceManager` Helper for the English and Spanish translation of the user interface and the text returned by validations.
```xml
?xml version="1.0" encoding="utf-8"?>
<root>
  <!-- 
    Microsoft ResX Schema 
    
    Version 2.0
    
    The primary goals of this format is to allow a simple XML format 
    that is mostly human readable. The generation and parsing of the 
    various data types are done through the TypeConverter classes 
    associated with the data types.
    
    Example:
    
    ... ado.net/XML headers & schema ...
    <resheader name="resmimetype">text/microsoft-resx</resheader>
    <resheader name="version">2.0</resheader>
    <resheader name="reader">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>
    <resheader name="writer">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>
    <data name="Name1"><value>this is my long string</value><comment>this is a comment</comment></data>
    <data name="Color1" type="System.Drawing.Color, System.Drawing">Blue</data>
    <data name="Bitmap1" mimetype="application/x-microsoft.net.object.binary.base64">
        <value>[base64 mime encoded serialized .NET Framework object]</value>
    </data>
    <data name="Icon1" type="System.Drawing.Icon, System.Drawing" mimetype="application/x-microsoft.net.object.bytearray.base64">
        <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>
        <comment>This is a comment</comment>
    </data>
                
    There are any number of "resheader" rows that contain simple 
    name/value pairs.
    
    Each data row contains a name, and value. The row also contains a 
    type or mimetype. Type corresponds to a .NET class that support 
    text/value conversion through the TypeConverter architecture. 
    Classes that don't support this are serialized and stored with the 
    mimetype set.
    
    The mimetype is used for serialized objects, and tells the 
    ResXResourceReader how to depersist the object. This is currently not 
    extensible. For a given mimetype the value must be set accordingly:
    
    Note - application/x-microsoft.net.object.binary.base64 is the format 
    that the ResXResourceWriter will generate, however the reader can 
    read any of the formats listed below.
    
    mimetype: application/x-microsoft.net.object.binary.base64
    value   : The object must be serialized with 
            : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            : and then encoded with base64 encoding.
    
    mimetype: application/x-microsoft.net.object.soap.base64
    value   : The object must be serialized with 
            : System.Runtime.Serialization.Formatters.Soap.SoapFormatter
            : and then encoded with base64 encoding.
    mimetype: application/x-microsoft.net.object.bytearray.base64
    value   : The object must be serialized into a byte array 
            : using a System.ComponentModel.TypeConverter
            : and then encoded with base64 encoding.
    -->
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Adress" xml:space="preserve">
    <value>Direccion</value>
  </data>
  <data name="buttonDelete" xml:space="preserve">
    <value>Eliminar</value>
  </data>
  <data name="buttonNew" xml:space="preserve">
    <value>Nuevo</value>
  </data>
  <data name="buttonSave" xml:space="preserve">
    <value>Salvar</value>
  </data>
  <data name="checkBoxStatus" xml:space="preserve">
    <value>Estatus</value>
  </data>
  <data name="CustName" xml:space="preserve">
    <value>Nombre</value>
  </data>
  <data name="CustomerTypeId" xml:space="preserve">
    <value>Tipo Cliente</value>
  </data>
  <data name="Description" xml:space="preserve">
    <value>Descripcion</value>
  </data>
  <data name="FormCustomer" xml:space="preserve">
    <value>Clientes</value>
  </data>
  <data name="FormMain" xml:space="preserve">
    <value>Sistema de Facturacion</value>
  </data>
  <data name="FormVendor" xml:space="preserve">
    <value>Suplidores</value>
  </data>
  <data name="Id" xml:space="preserve">
    <value>Id</value>
  </data>
  <data name="labelAdress" xml:space="preserve">
    <value>Direccion</value>
  </data>
  <data name="labelCustomerTypeId" xml:space="preserve">
    <value>Tipo Cliente</value>
  </data>
  <data name="labelDescription" xml:space="preserve">
    <value>Descripcion</value>
  </data>
  <data name="labelId" xml:space="preserve">
    <value>Codigo</value>
  </data>
  <data name="labelLanguaje" xml:space="preserve">
    <value>Seleccione Idioma</value>
  </data>
  <data name="labelName" xml:space="preserve">
    <value>Nombre</value>
  </data>
  <data name="labelSearch" xml:space="preserve">
    <value>Buscar</value>
  </data>
  <data name="labelVendorTypeId" xml:space="preserve">
    <value>Tipo Suplidor</value>
  </data>
  <data name="MaxLengthErrorMessage" xml:space="preserve">
    <value>Ha excedido la longitud maxima del campo</value>
  </data>
  <data name="MenuItem" xml:space="preserve">
    <value>Ficheros</value>
  </data>
  <data name="Name" xml:space="preserve">
    <value>Nombre</value>
  </data>
  <data name="RequiredErrorMessage" xml:space="preserve">
    <value>El campo es requerido</value>
  </data>
  <data name="toolStripMenuItemCustomer" xml:space="preserve">
    <value>Clientes</value>
  </data>
  <data name="toolStripMenuItemVendor" xml:space="preserve">
    <value>Suplidores</value>
  </data>
  <data name="VendName" xml:space="preserve">
    <value>Nombre</value>
  </data>
  <data name="VendorTypeId" xml:space="preserve">
    <value>Tipo Suplidor</value>
  </data>
</root>
```
# Finally we have the WinFormsAppBindings project:

Este proyecto es un proyecto de Windows Forms y utiliza Data Bindings, e inyecci??n de dependencias, b??sicamente se implementa la interfaz de uno o m??s modelos y se inyecta en el presentador, Contiene todo el c??digo de gesti??n de la capa de datos.
```csharp

/* Codigo fuente de FormCustomer */

using BusinessObjects.Interfaces;
using System;
using System.Windows.Forms;
using BusinessObjects.Models;
using BusinessObjects.Presenters;
using CommonUserControls.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BusinessObjects.Context;
using System.Globalization;
using System.Threading;
using System.Resources;
using BusinessObjects.Resources;
using System.Linq.Expressions;
using System.Linq;

namespace WinFormsAppBindings
{
    public partial class FormCustomer : Form,ICustomer,INotifyUI
    {


        private readonly CustomerPresenter _customerPresenter;
        private readonly CustomerTypePresenter _customerTypePresenter;
        private readonly BindingSource _bindingSourceCustomer = new BindingSource();
        private readonly ICustomerType _customerType = new CustomerType();
        private readonly HelperControlsToValidate _validator;
        private readonly HelperControlsTranslate _translate;

        public FormCustomer(BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            InitializeComponent();
       
            _customerPresenter = new CustomerPresenter(this, businessObjectsResourceManager);

            _customerTypePresenter = new CustomerTypePresenter(_customerType, businessObjectsResourceManager);

            setDataBinds();

            this.FormClosed += (sender, e) => {

                _customerPresenter.Dispose();

                _customerTypePresenter.Dispose();

            };

            _validator = new HelperControlsToValidate(this);
            _translate = new HelperControlsTranslate(this, businessObjectsResourceManager);
            _translate.Translate();

        }

        #region Properties
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; } = true;
        public int CustomerTypeId { get; set ; }
        public CustomerType CustomerType { get; set ; }
        #endregion

        private void setDataBinds()
        {
            _bindingSourceCustomer.DataSource = this;

            this.textBoxId.DataBindings.Add(new Binding("Text",
                                  _bindingSourceCustomer,
                                  nameof(Customer.Id), true, DataSourceUpdateMode.OnPropertyChanged));


            this.textBoxCustName.DataBindings.Add(new Binding("Text",
                                   _bindingSourceCustomer,
                                   nameof(Customer.CustName),
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.textBoxAdress.DataBindings.Add(new Binding("Text",
                                   _bindingSourceCustomer,
                                   nameof(Customer.Adress),
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.checkBoxStatus.DataBindings.Add(new Binding("Checked",
                                  _bindingSourceCustomer,
                                  nameof(Customer.Status),
                                   true, DataSourceUpdateMode.OnPropertyChanged));

           this.comboBoxCustomerType.DataBindings.Add(new Binding("SelectedValue",
                                _bindingSourceCustomer,
                                nameof(Customer.CustomerTypeId),
                                 true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxCustomerType.DisplayMember = nameof(CustomerType.Description);
            this.comboBoxCustomerType.ValueMember = nameof(CustomerType.Id);

            fillComboBox();

            _customerPresenter.OnRefresh += () => { _bindingSourceCustomer.ResetBindings(false); };
            _customerPresenter.BeforeSave += () => { Console.WriteLine("Puedes poner algo aqui antes de salvar"); };
            _customerPresenter.AfterSave += () => { Console.WriteLine("Puedes poner algo aqui despues de salvar"); };

            setTags();
        }

        private void setTags()
        {
            this.textBoxCustName.Tag = nameof(Customer.CustName);
            this.textBoxAdress.Tag = nameof(Customer.Adress);
            this.comboBoxCustomerType.Tag = nameof(Customer.CustomerTypeId);
        }

        private void fillComboBox()
        {
            try
            {
                this.comboBoxCustomerType.DataSource = _customerTypePresenter.GetAll();
            }
            catch (Exception ex)
            {
                showException(ex);
            }

        }

        private  void showException(Exception ex)
        {
            MessageBox.Show($"Se produjo una excepcion {ex.Message}", "Aviso..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _customerPresenter.Add();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _customerPresenter.Save();
            }
            catch (Exception ex)
            {

                showException(ex);
            }
           
        }

        private void RefreshData()
        {
            _bindingSourceCustomer.ResetBindings(false);
        }



        private void textBoxId_Leave(object sender, EventArgs e)
        {

            try
            {
                _customerPresenter.FindById(this.Id);
            }
            catch (Exception ex)
            {

                showException(ex);
            }
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _customerPresenter.Delete(this.Id);
            }
            catch (Exception ex)
            {

                showException(ex);
            }
           
        }

        public void NotifyErrors(ICollection<ValidationResult> sender)
        {
           
            _validator.ValidateMembers(sender);
        }

        public void  ClearErrorsValidations(ICollection<ValidationResult> sender)
        {
            _validator.ClearErrors(sender);
        }

        private void dataGridViewCustomer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                findById();
            }
            catch (Exception ex)
            {

                showException(ex);
            }
            
        }

        private void findById()
        {
            var row = this.dataGridViewCustomer.CurrentRow;
            if (row != null)
            {
                _customerPresenter.FindById((int)row.Cells[0].Value);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (Exception ex)
            {

                showException(ex);
            }
           

        }

        private void search()
        {
            var valueToSearch = textBoxSearch.Text.ToLower();
            var result = _customerPresenter.Get(valueToSearch).Select ( a=> new { a.Id,a.CustName,a.Adress,a.CustomerType.Description,a.Status });
            this.dataGridViewCustomer.DataSource = result.ToList();
        }
    }
} 

```
# Added a Wisej implementation below the example

```csharp
/*
MIT License
Copyright (c) [2020] [Jose Roberto Taveras Galvan]
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using Wisej.Web;
using BusinessObjects.Models;
using BusinessObjects.Presenters;
using CommonUserControls.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BusinessObjects.Interfaces;
using BusinessObjects.Resources;
using System.Linq;


namespace WisejWebPageApplication1
{
    public partial class PageCustomer : Page, ICustomer, INotifyUI
    {

        private readonly CustomerPresenter _customerPresenter;
        private readonly CustomerTypePresenter _customerTypePresenter;
        private readonly BindingSource _bindingSourceCustomer = new BindingSource();
        private readonly ICustomerType _customerType = new CustomerType();
        private readonly HelperControlsToValidate _validator;
        private readonly HelperControlsTranslate _translate;
        private readonly Page _mainPage;
        public PageCustomer(Page mainPage,BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            InitializeComponent();

            _mainPage = mainPage;

            _customerPresenter = new CustomerPresenter(this, businessObjectsResourceManager);

            _customerTypePresenter = new CustomerTypePresenter(_customerType, businessObjectsResourceManager);

            setDataBinds();
                        
            _validator = new HelperControlsToValidate(this);
            _translate = new HelperControlsTranslate(this, businessObjectsResourceManager);
            _translate.Translate();

        }

        #region Properties
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; } = true;
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
        #endregion

        private void setDataBinds()
        {
            _bindingSourceCustomer.DataSource = this;

            this.textBoxId.DataBindings.Add(new Binding("Text",
                                  _bindingSourceCustomer,
                                  nameof(Customer.Id), true, DataSourceUpdateMode.OnPropertyChanged));


            this.textBoxCustName.DataBindings.Add(new Binding("Text",
                                   _bindingSourceCustomer,
                                   nameof(Customer.CustName),
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.textBoxAdress.DataBindings.Add(new Binding("Text",
                                   _bindingSourceCustomer,
                                   nameof(Customer.Adress),
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.checkBoxStatus.DataBindings.Add(new Binding("Checked",
                                  _bindingSourceCustomer,
                                  nameof(Customer.Status),
                                   true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxCustomerType.DataBindings.Add(new Binding("SelectedValue",
                                 _bindingSourceCustomer,
                                 nameof(Customer.CustomerTypeId),
                                  true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxCustomerType.DisplayMember = nameof(CustomerType.Description);
            this.comboBoxCustomerType.ValueMember = nameof(CustomerType.Id);

            fillComboBox();

            _customerPresenter.OnRefresh += () => { _bindingSourceCustomer.ResetBindings(false); };
            _customerPresenter.BeforeSave += () => { Console.WriteLine("Puedes poner algo aqui antes de salvar"); };
            _customerPresenter.AfterSave += () => { Console.WriteLine("Puedes poner algo aqui despues de salvar"); };

            setTags();

            search();
        }

        private void setTags()
        {
            this.textBoxCustName.Tag = nameof(Customer.CustName);
            this.textBoxAdress.Tag = nameof(Customer.Adress);
            this.comboBoxCustomerType.Tag = nameof(Customer.CustomerTypeId);
        }

        private void fillComboBox()
        {
            try
            {
                this.comboBoxCustomerType.DataSource = _customerTypePresenter.GetAll();
            }
            catch (Exception ex)
            {
                showException(ex);
            }

        }

        private void showException(Exception ex)
        {
            MessageBox.Show($"Se produjo una excepcion {ex.Message}", "Aviso..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _customerPresenter.Add();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _customerPresenter.Save();
            }
            catch (Exception ex)
            {

                showException(ex);
            }

        }

        private void RefreshData()
        {
            _bindingSourceCustomer.ResetBindings(false);
        }



        private void textBoxId_Leave(object sender, EventArgs e)
        {

            try
            {
                _customerPresenter.FindById(this.Id);
            }
            catch (Exception ex)
            {

                showException(ex);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _customerPresenter.Delete(this.Id);
            }
            catch (Exception ex)
            {

                showException(ex);
            }

        }

        public void NotifyErrors(ICollection<ValidationResult> sender)
        {

            _validator.ValidateMembers(sender);
        }

        public void ClearErrorsValidations(ICollection<ValidationResult> sender)
        {
            _validator.ClearErrors(sender);
        }

        private void dataGridViewCustomer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                findById();
            }
            catch (Exception ex)
            {

                showException(ex);
            }

        }

        private void findById()
        {
            var row = this.dataGridViewCustomer.CurrentRow;
            if (row != null)
            {
                _customerPresenter.FindById((int)row.Cells[0].Value);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (Exception ex)
            {

                showException(ex);
            }


        }

        private void search()
        {
            var valueToSearch = textBoxSearch.Text.ToLower();
            var result = _customerPresenter.Get(valueToSearch).Select(a => new { a.Id, a.CustName, a.Adress, a.CustomerType.Description, a.Status });
            this.dataGridViewCustomer.DataSource = result.ToList();
        }

        private void textBoxSearch_TextChanged_1(object sender, EventArgs e)
        {
            search();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            search();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            _mainPage.Show();
            _customerPresenter.Dispose();
            _customerPresenter.Dispose();
            this.Dispose();
        }
    }
}

```
# Helpers de traduccion y validacion de la interface de usuarios
```csharp
using BusinessObjects.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CommonUserControls.Helpers
{
    // Aqui comienza la clase de traduccion de los controles
    public class HelperControlsTranslate
    {
        Control _control;
        BusinessObjectsResourceManager _resourceManager;
        public HelperControlsTranslate(Control control, BusinessObjectsResourceManager resourceManager)
        {
            _control = control;
            _resourceManager = resourceManager;

          

        }

        public void Translate()
        {
            Form form = _control as Form;
            if (form != null)
            {
                form.Text = _resourceManager.Translate(form.Name) ?? form.Text;

            }
            translate(_control);
        }



        void translate(MenuStrip control) 
        {
            foreach (ToolStripItem item in control.Items)
            {
                if (item != null)
                {
                    item.Text = _resourceManager.Translate(item.Name) ?? item.Text;
                }
            }
        }



        void translate(Control control)
        {

            foreach (Control item in control.Controls)
            {
                if (item != null)
                {



                    MenuStrip menuStrip = item as MenuStrip;
                    if (menuStrip != null)
                    {
                        menuStrip.Text = _resourceManager.Translate(menuStrip.Name) ?? menuStrip.Text;
                        translate(menuStrip);
                        continue;
                    }

                    Label label = item as Label;
                    if (label != null)
                    {
                        label.Text = _resourceManager.Translate(label.Name) ?? label.Text;
                        continue;
                    }

                    CheckBox checBox = item as CheckBox;
                    if (checBox != null)
                    {
                        checBox.Text = _resourceManager.Translate(checBox.Name) ?? checBox.Text;
                        continue;

                    }

                    Button button = item as Button;
                    if (button != null)
                    {
                        button.Text = _resourceManager.Translate(button.Name) ?? button.Text;
                        continue;
                    }
                    else
                    {
                        translate(item);
                    }

                }

            }
        }
    }
    
    // Aqui comienza la clase de validacion de los controles
    
    public class HelperControlsToValidate
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public Dictionary<string,Control> dic = new Dictionary<string,Control>();

        public  HelperControlsToValidate(Control sender)
        {
            addControlsToDictionary(sender);
        }

        protected void addControlsToDictionary(Control sender)
        {
            foreach (Control nivelSuperior in sender.Controls)
            {
                addItemToDictionary(nivelSuperior);
                foreach (Control item in nivelSuperior.Controls)
                {
                    addItemToDictionary(item);
                    if (item.Controls != null)
                        addControlsToDictionary(item);
                }
            }
        }

        private void addItemToDictionary(Control sender)
        {
            if (sender.Tag != null)
            {

                if (!dic.ContainsKey(sender.Tag.ToString()))
                {
                    dic.Add(sender.Tag.ToString(), sender);
                }
            }
        }

        public void ValidateMembers(ICollection<ValidationResult> sender) {


            foreach (var item in sender)
            {
                foreach (var memberName in item.MemberNames)
                {
                    var found = dic.Where(a => a.Key == memberName).FirstOrDefault();
                    if (!string.IsNullOrEmpty(found.Key))
                        errorProvider1.SetError(found.Value, item.ErrorMessage);

                }

            }
        }

        public void ClearErrors(ICollection<ValidationResult> sender)
        {
            foreach (var item in dic)
            {
                 errorProvider1.SetError(item.Value, null);

            }
        }
    }
}

//Aqui esta la clase con el poco de los idiomas
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppBindings.Helpers
{
    public class Languaje
    {
        public string Id { get; set; }
        public string Description { get; set; }

    }

    public sealed class Singleton
    {
        private readonly static List<Languaje> _instance;

        static Singleton()
        {
            _instance = new List<Languaje>();
            _instance.Add(new Languaje() { Id = "es-DO", Description = "Espa??ol" });
            _instance.Add(new Languaje() { Id = "en-US", Description = "Ingles" });
        }

        public static List<Languaje> Instance
        {
            get
            {
                return _instance;
            }
        }
    }

}
```
