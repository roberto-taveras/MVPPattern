using BusinessObjects.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppBindings
{
    public partial class FormMain : Form
    {
        BusinessObjectsResourceManager businessObjectsResourceManager;
        public FormMain()
        {
            InitializeComponent();
            
            comboBoxIdioma.DataSource = Helpers.Languaje.GetLanguajes();
            comboBoxIdioma.ValueMember = nameof(Helpers.Languaje.Id);
            comboBoxIdioma.DisplayMember = nameof(Helpers.Languaje.Description);
            comboBoxIdioma.SelectedIndex = 0;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItemCustome_Click(object sender, EventArgs e)
        {
            //"es-DO" espanol
            businessObjectsResourceManager = new BusinessObjectsResourceManager(this.comboBoxIdioma.SelectedValue.ToString());
            FormCustomer customer = new FormCustomer(businessObjectsResourceManager);
            customer.Show();

        }

        private void toolStripMenuItemVendor_Click(object sender, EventArgs e)
        {
            businessObjectsResourceManager = new BusinessObjectsResourceManager(this.comboBoxIdioma.SelectedValue.ToString());
            FormVendor formVendor = new FormVendor(businessObjectsResourceManager);
            formVendor.Show();
        }
    }
}
