using BusinessObjects.Resources;
using CommonUserControls.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private  BusinessObjectsResourceManager businessObjectsResourceManager;
        private  HelperControlsTranslate _translate;
        public FormMain()
        {
            InitializeComponent();

         


            comboBoxLanguaje.DataSource = Helpers.Languaje.GetLanguajes();
            comboBoxLanguaje.ValueMember = nameof(Helpers.Languaje.Id);
            comboBoxLanguaje.DisplayMember = nameof(Helpers.Languaje.Description);
            comboBoxLanguaje.SelectedIndex = 0;

            comboBoxLanguaje.SelectedValueChanged += (sender, e) => {
                businessObjectsResourceManager = new BusinessObjectsResourceManager(comboBoxLanguaje.SelectedValue.ToString());
                translate(); ;


            };




        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItemCustome_Click(object sender, EventArgs e)
        {
            //"es-DO" espanol

      
            FormCustomer customer = new FormCustomer(businessObjectsResourceManager);
            customer.Show();

        }

        private void translate()
        {
            _translate = new HelperControlsTranslate(this, businessObjectsResourceManager);
            _translate.Translate();
        }

        private void toolStripMenuItemVendor_Click(object sender, EventArgs e)
        {
   
            FormVendor formVendor = new FormVendor(businessObjectsResourceManager);
            formVendor.Show();
        }
    }
}
