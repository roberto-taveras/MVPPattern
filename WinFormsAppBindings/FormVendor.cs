using BusinessObjects;
using BusinessObjects.Interfaces;
using System;
using System.Windows.Forms;
using BusinessObjects.Models;
using BusinessObjects.Presenters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommonUserControls.Helpers;
using BusinessObjects.Context;
using System.Globalization;
using System.Threading;
using System.Resources;
using BusinessObjects.Resources;

namespace WinFormsAppBindings
{
    public partial class FormVendor : Form,  IVendor ,INotifyUI
    {

        private readonly VendorPresenter _vendorPresenter;
        private readonly BindingSource _bindingSourceVendor = new BindingSource();
        private readonly IVendorType _vendorType = new VendorType();
        private readonly VendorTypePresenter _vendorTypePresenter;
        private readonly CourseContext<Vendor> vendorContext;
        private readonly CourseContext<VendorType> vendorTypeContext;
        private readonly HelperControlsToValidate _validator;
        private readonly HelperControlsTranslate _translate;
        public FormVendor(string cultureName)
        {
            InitializeComponent();

            BusinessObjectsResourceManager resourceManager = new BusinessObjectsResourceManager(cultureName);

            vendorContext = CourseContext<Vendor>.Factory();

            vendorTypeContext = CourseContext<VendorType>.Factory();

            _vendorPresenter = new VendorPresenter(vendorContext,this);

            _vendorTypePresenter = new VendorTypePresenter(vendorTypeContext,_vendorType);

            setDataBinds();

            this.FormClosed += (sender, e) => {

                _vendorPresenter.Dispose();

                _vendorTypePresenter.Dispose();

            };

            _validator = new HelperControlsToValidate(this);
            _translate = new HelperControlsTranslate(this, resourceManager);
            _translate.Translate();

        }


        #region Properties
        public int Id { get; set; }
        public string VendName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; } = true;
        public int VendorTypeId { get; set; }
        public VendorType VendorType { get; set; }
        #endregion

        private void setDataBinds()
        {
            _bindingSourceVendor.DataSource = this;

            this.textBoxId.DataBindings.Add(new Binding("Text",
                                  _bindingSourceVendor,
                                  "Id", true, DataSourceUpdateMode.OnPropertyChanged));


            this.textBoxNombre.DataBindings.Add(new Binding("Text",
                                   _bindingSourceVendor,
                                   "VendName",
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.textBoxDireccion.DataBindings.Add(new Binding("Text",
                                   _bindingSourceVendor,
                                   "Adress",
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.checkBoxStatus.DataBindings.Add(new Binding("Checked",
                                  _bindingSourceVendor,
                                  "Status",
                                   true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxVendorType.DataBindings.Add(new Binding("SelectedValue",
                                _bindingSourceVendor,
                                "VendorTypeId",
                                 true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxVendorType.DisplayMember = nameof(VendorType.Description);
            this.comboBoxVendorType.ValueMember = nameof(VendorType.Id);

            fillComboBox();

            _vendorPresenter.OnRefresh += () => { _bindingSourceVendor.ResetBindings(false); };
            _vendorPresenter.BeforeSave += () => { Console.WriteLine("Puedes poner algo aqui antes de salvar"); };
            _vendorPresenter.AfterSave += () => { Console.WriteLine("Puedes poner algo aqui despues de salvar"); };

            setTags();
        }

        private void setTags()
        {
            this.textBoxNombre.Tag = nameof(Vendor.VendName);
            this.textBoxDireccion.Tag = nameof(Vendor.Adress);
            this.comboBoxVendorType.Tag = nameof(Vendor.VendorTypeId);
        }

        private void fillComboBox()
        {
            try
            {
                comboBoxVendorType.DataSource = _vendorTypePresenter.GetAll();
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
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            _vendorPresenter.Add();

        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _vendorPresenter.Save();
            }
            catch (Exception ex)
            {

                showException(ex);
            }
           
        }

        private void RefreshData()
        {
            _bindingSourceVendor.ResetBindings(false);
        }



        private void textBoxId_Leave(object sender, EventArgs e)
        {
            try
            {
                _vendorPresenter.FindById(this.Id);
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
                _vendorPresenter.Delete(this.Id);
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}