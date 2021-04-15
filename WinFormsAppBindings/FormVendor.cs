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
using System.Linq;

namespace WinFormsAppBindings
{
    public partial class FormVendor : Form,  IVendor ,INotifyUI
    {

        private readonly VendorPresenter _vendorPresenter;
        private readonly BindingSource _bindingSourceVendor = new BindingSource();
        private readonly IVendorType _vendorType = new VendorType();
        private readonly VendorTypePresenter _vendorTypePresenter;
        private readonly HelperControlsToValidate _validator;
        private readonly HelperControlsTranslate _translate;
        public FormVendor(BusinessObjectsResourceManager businessObjectsResourceManager)
        {
            InitializeComponent();

            _vendorPresenter = new VendorPresenter(this, businessObjectsResourceManager);

            _vendorTypePresenter = new VendorTypePresenter(_vendorType, businessObjectsResourceManager);

            setDataBinds();

            this.FormClosed += (sender, e) => {

                _vendorPresenter.Dispose();

                _vendorTypePresenter.Dispose();

            };

            _validator = new HelperControlsToValidate(this);
            _translate = new HelperControlsTranslate(this, businessObjectsResourceManager);
            _translate.Translate();

            this.search();

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
                                  nameof(Vendor.Id), true, DataSourceUpdateMode.OnPropertyChanged));


            this.textBoxVendorName.DataBindings.Add(new Binding("Text",
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
            this.textBoxVendorName.Tag = nameof(Vendor.VendName);
            this.textBoxAdress.Tag = nameof(Vendor.Adress);
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

        private void label3_Click(object sender, EventArgs e)
        {

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
    }
}