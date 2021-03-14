using BusinessObjects.Interfaces;
using System;
using System.Windows.Forms;
using BusinessObjects.Models;
using BusinessObjects.Presenters;

namespace WinFormsAppBindings
{
    public partial class FormCustomer : Form,  ICustomer
    {


        private readonly CustomerPresenter _customerPresenter;
        private readonly CustomerTypePresenter _customerTypePresenter;
        private readonly BindingSource _bindingSourceCustomer = new BindingSource();
        private readonly ICustomerType _customerType = new CustomerType();

        public FormCustomer()
        {
            InitializeComponent();

            _customerPresenter = new CustomerPresenter(this);

            _customerTypePresenter = new CustomerTypePresenter(_customerType);

            setDataBinds();

            this.FormClosed += (sender, e) => {

                _customerPresenter.Dispose();

                _customerTypePresenter.Dispose();

            };
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
                                  "Id", true, DataSourceUpdateMode.OnPropertyChanged));


            this.textBoxNombre.DataBindings.Add(new Binding("Text",
                                   _bindingSourceCustomer,
                                   "CustName",
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.textBoxDireccion.DataBindings.Add(new Binding("Text",
                                   _bindingSourceCustomer,
                                   "Adress",
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.checkBoxActivo.DataBindings.Add(new Binding("Checked",
                                  _bindingSourceCustomer,
                                  "Status",
                                   true, DataSourceUpdateMode.OnPropertyChanged));

           this.comboBoxCustomerType.DataBindings.Add(new Binding("SelectedValue",
                                _bindingSourceCustomer,
                                "CustomerTypeId",
                                 true, DataSourceUpdateMode.OnPropertyChanged));

            this.comboBoxCustomerType.DisplayMember = nameof(CustomerType.Description);
            this.comboBoxCustomerType.ValueMember = nameof(CustomerType.Id);

            fillComboBox();

            _customerPresenter.OnRefresh += () => { _bindingSourceCustomer.ResetBindings(false); };
            _customerPresenter.BeforeSave += () => { Console.WriteLine("Puedes poner algo aqui antes de salvar"); };
            _customerPresenter.AfterSave += () => { Console.WriteLine("Puedes poner algo aqui despues de salvar"); };


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

        
    }
}