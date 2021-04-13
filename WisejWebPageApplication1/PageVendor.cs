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
    public partial class PageVendor : Page, IVendor, INotifyUI
    {

        private readonly VendorPresenter _vendorPresenter;
        private readonly VendorTypePresenter _vendorTypePresenter;
        private readonly BindingSource _bindingSourceVendor = new BindingSource();
        private readonly IVendorType _vendorType = new VendorType();
        private readonly HelperControlsToValidate _validator;
        private readonly HelperControlsTranslate _translate;
        private readonly Page _mainPage;
        public PageVendor(Page mainPage,BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            InitializeComponent();

            _mainPage = mainPage;

            _vendorPresenter = new VendorPresenter(this, businessObjectsResourceManager);

            _vendorTypePresenter = new VendorTypePresenter(_vendorType, businessObjectsResourceManager);

            setDataBinds();
                        
            _validator = new HelperControlsToValidate(this);
            _translate = new HelperControlsTranslate(this, businessObjectsResourceManager);
            _translate.Translate();

        }

        #region Properties
        public int Id { get; set; }
        public string VendName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; } = true;
        public int VendorTypeId { get; set; }
        public  VendorType VendorType { get; set; }
        #endregion

        private void setDataBinds()
        {
            _bindingSourceVendor.DataSource = this;

            this.textBoxId.DataBindings.Add(new Binding("Text",
                                  _bindingSourceVendor,
                                  nameof(Vendor.Id), true, DataSourceUpdateMode.OnPropertyChanged));


            this.textBoxVendName.DataBindings.Add(new Binding("Text",
                                   _bindingSourceVendor,
                                   nameof(Vendor.VendName),
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.textBoxAdress.DataBindings.Add(new Binding("Text",
                                   _bindingSourceVendor,
                                   nameof(Vendor.Adress),
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.checkBoxStatus.DataBindings.Add(new Binding("Checked",
                                  _bindingSourceVendor,
                                  nameof(Vendor.Status),
                                   true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxVendorType.DataBindings.Add(new Binding("SelectedValue",
                                 _bindingSourceVendor,
                                 nameof(Vendor.VendorTypeId),
                                  true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxVendorType.DisplayMember = nameof(BusinessObjects.Models.VendorType.Description);
            this.comboBoxVendorType.ValueMember = nameof(BusinessObjects.Models.VendorType.Id);

            fillComboBox();

            _vendorPresenter.OnRefresh += () => { _bindingSourceVendor.ResetBindings(false); };
            _vendorPresenter.BeforeSave += () => { Console.WriteLine("Puedes poner algo aqui antes de salvar"); };
            _vendorPresenter.AfterSave += () => { Console.WriteLine("Puedes poner algo aqui despues de salvar"); };

            setTags();

            search();
        }

        private void setTags()
        {
            this.textBoxVendName.Tag = nameof(Vendor.VendName);
            this.textBoxAdress.Tag = nameof(Vendor.Adress);
            this.comboBoxVendorType.Tag = nameof(Vendor.VendorTypeId);
        }

        private void fillComboBox()
        {
            try
            {
                this.comboBoxVendorType.DataSource = _vendorTypePresenter.GetAll();
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
            _vendorPresenter.Add();

        }

        private void buttonSave_Click(object sender, EventArgs e)
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

        private void buttonDelete_Click(object sender, EventArgs e)
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
                _vendorPresenter.FindById((int)row.Cells[0].Value);
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
            var result = _vendorPresenter.Get(valueToSearch).Select(a => new { a.Id, a.VendName, a.Adress, a.VendorType.Description, a.Status });
            this.dataGridViewCustomer.DataSource = result.ToList();
        }

        

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            search();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            _mainPage.Show();
            _vendorPresenter.Dispose();
            _vendorTypePresenter.Dispose();
            this.Dispose();
        }
    }
}
