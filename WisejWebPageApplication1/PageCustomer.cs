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
            _customerTypePresenter.Dispose();
            this.Dispose();
        }
    }
}
