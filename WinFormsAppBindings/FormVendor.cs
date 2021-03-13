using BusinessObjects;
using BusinessObjects.Interfaces;
using System;
using System.Windows.Forms;
using BusinessObjects.Models;
using BusinessObjects.Presenters;

namespace WinFormsAppBindings
{
    public partial class FormVendor : Form,  IVendor
    {

        private readonly VendorPresenter _vendorPresenter;
        private readonly BindingSource _bindingSourceVendor = new BindingSource();
        private readonly IVendorType _vendorType = new VendorType();
        private readonly VendorTypePresenter _vendorTypePresenter;
        public FormVendor()
        {
            InitializeComponent();

            _vendorPresenter = new VendorPresenter(this);

            _vendorTypePresenter = new VendorTypePresenter(_vendorType);

            setDataBinds();

            this.FormClosed += (sender, e) => {

                _vendorPresenter.Dispose();

                _vendorTypePresenter.Dispose();

            };
        }

        #region Properties

        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; } = true;
        public int VendorTypeId { get; set; }
        #endregion
        private void setDataBinds()
        {
            _bindingSourceVendor.DataSource = this;

            this.textBoxId.DataBindings.Add(new Binding("Text",
                                  _bindingSourceVendor,
                                  "Id", true, DataSourceUpdateMode.OnPropertyChanged));


            this.textBoxNombre.DataBindings.Add(new Binding("Text",
                                   _bindingSourceVendor,
                                   "CustName",
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.textBoxDireccion.DataBindings.Add(new Binding("Text",
                                   _bindingSourceVendor,
                                   "Adress",
                                    true, DataSourceUpdateMode.OnPropertyChanged));

            this.checkBoxActivo.DataBindings.Add(new Binding("Checked",
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

        }

        private void fillComboBox()
        {
            try
            {
                comboBoxVendorType.DataSource = _vendorTypePresenter.GetAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Se produjo una excepcion {ex.Message}", "Aviso..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void numericUpDownCodigo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _vendorPresenter.FindById(this.Id);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Se produjo una excepcion {ex.Message}", "Aviso..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

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

                MessageBox.Show($"Se produjo una excepcion {ex.Message}", "Aviso..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show($"Se produjo una excepcion {ex.Message}", "Aviso..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           ;

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

                MessageBox.Show($"Se produjo una excepcion {ex.Message}", "Aviso..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}