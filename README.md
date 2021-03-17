# MVP Pattern
- Proyecto de ejemplo usando:
- Patrón de diseño MVP(Model-View-Presenter)
- Reflection
- Delegates
- Events 
- Repositorio Generico
- Inyección de dependencias
- Databindings en Windows Forms
- Traducciones
- Validaciones del modelo
- Fluent Validations
- Globalizacion (es-DO (Español),en-US (Ingles))

<p align="center">
  <img width="460" height="300" src="/WinFormsAppBindings/Assets/MVP.png">
</p>
(https://medium.com/android-news/mvp-depp-dive-c6bb1903ace1)

# El BusinessObjects tiene las siguientes partes:
 
Basicamente voy a dejar el link a github para que puedan desacargar el proyecto, que en escencia tiene un repositorio generico, con el cual se desarrollan los presenters, estos presenters validan las entidades con la informacion del modelo pero tambien se puede extender usando Fluent Validation si se requiere agregar Reglas, como es utilizado en el proyecto.

# Introduccion

El proyecto muestra cómo reducir código al crear aplicaciones de Windows Forms al usar repositorios genéricos, helpers usando el error provider para no tener que aplicarlo manualmente en cada validación, si no para hacerlo automáticamente como funciona el CRUD en aplicaciones MVC.

# Partes del BusinessObjetcs & Dependencias
- EntityFramework.6.4.4
- Fluent Validation 9.0.0.0: https://fluentvalidation.net/
- La librería BusinessObjects usa Standard Net (4.8)
- WinFormsAppBindings Tiene como dependencia .Net 5.0

# El BusinessObjects tiene las siguientes partes:

1. `Context => CourseContext`: que se encarga de mapear algunos de los modelos que están vinculados a cada tabla.

2. `HelperAssignProperty`: El cual es la función de getters y setters (entre la interfaz que se inyecta desde la vista y el modelo que se instancia en el presentador).

3. `HelperValidateEntity`: El cual se encarga de las validaciones del modelo en base a las restricciones que se colocan en cada bit que representa cada tabla.

4. `Interfaces` : Contiene las interfaces relacionadas con algunos de los modelos de cada tabla y una interfaz especial llamada INofitify que se inyecta desde la vista al presentador para establecer todo el mecanismo de validación.

5. `Models`: Contiene los pocos de cada clase, estos implementan interfaces que tienen que tener exactamente las mismas propiedades que los modelos para que los getters y setters se ejecuten correctamente en el helper (HelperAssignProperty).

6. `Repository`: Contiene un repositorio genérico `RepositoryBase` cuya función es reutilizar el código, y evitar tener que hacer lo mismo una y otra vez, se implementa en cada presentador y cuenta con métodos y eventos virtuales que se pueden utilizar para aumentar su flexibilidad:

7. `Presenters`: que implementan RepositoryBase y que pueden sobrescribirse y extender sus validaciones con Fluent Validations.

8. `Resources`: Contiene archivos de recursos y un Helper `BusinessObjectsResourceManager` para la traducción al inglés y al español de la interfaz de usuario y el texto devuelto por las validaciones.

# Finalmente tenemos el proyecto WinFormsAppBindings:

Este proyecto es un proyecto de Windows Forms y utiliza Data Bindings, e inyección de dependencias, básicamente se implementa la interfaz de uno o más modelos y se inyecta en el presentador, Contiene todo el código de gestión de la capa de datos.
```csharp
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


            this.textBoxNombre.DataBindings.Add(new Binding("Text",
                                   _bindingSourceCustomer,
                                   nameof(Customer.CustName),
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.textBoxDireccion.DataBindings.Add(new Binding("Text",
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
            this.textBoxNombre.Tag = nameof(Customer.CustName);
            this.textBoxDireccion.Tag = nameof(Customer.Adress);
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

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            _customerPresenter.Add();

        }

        private void buttonSalvar_Click(object sender, EventArgs e)
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

        private void buttonBorrar_Click(object sender, EventArgs e)
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

        public void NotifyErrors(ICollection<validationresult> sender)
        {
           
            _validator.ValidateMembers(sender);
        }

        public void  ClearErrorsValidations(ICollection<validationresult> sender)
        {
            _validator.ClearErrors(sender);
        }
    }
}
```
