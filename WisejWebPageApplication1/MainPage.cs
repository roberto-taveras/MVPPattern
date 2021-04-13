
using System;
using BusinessObjects.Resources;
using CommonUserControls.Helpers;
using WisejWebPageApplicationProject.Helpers;
using Wisej.Web;

namespace WisejWebPageApplication1
{
    public partial class MainPage : Page
    {
        private BusinessObjectsResourceManager businessObjectsResourceManager;
        private HelperControlsTranslate _translate;
        public MainPage()
        {
            InitializeComponent();




            comboBoxLanguaje.DataSource = WisejWebPageApplicationProject.Helpers.Singleton.Instance;
            comboBoxLanguaje.ValueMember = nameof(WisejWebPageApplicationProject.Helpers.Languaje.Id);
            comboBoxLanguaje.DisplayMember = nameof(WisejWebPageApplicationProject.Helpers.Languaje.Description);
            comboBoxLanguaje.SelectedIndex = 0;

            comboBoxLanguaje.SelectedValueChanged += (sender, e) =>
            {              
                if (comboBoxLanguaje.SelectedValue != null)
                    translate();


            };

            translate();


        }

        private void menuItemFile_Click(object sender, EventArgs e)
        {
            
        }

       
        private void translate()
        {
            businessObjectsResourceManager = new BusinessObjectsResourceManager(comboBoxLanguaje.SelectedValue.ToString());
            _translate = new HelperControlsTranslate(this, businessObjectsResourceManager);
            _translate.Translate();
        }

        private void comboBoxLanguaje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuBar1_MenuItemClicked(object sender, MenuItemEventArgs e)
        {
            
            switch (e.MenuItem.Name)
            {
                case "menuItemCustomer":
                    businessObjectsResourceManager = new BusinessObjectsResourceManager(comboBoxLanguaje.SelectedValue.ToString());
                    PageCustomer pageCustomer = new PageCustomer(this,businessObjectsResourceManager);
                    pageCustomer.Show();
                    break;

                case "menuItemVendor":
                    businessObjectsResourceManager = new BusinessObjectsResourceManager(comboBoxLanguaje.SelectedValue.ToString());
                    PageVendor pageVendor = new PageVendor(this,businessObjectsResourceManager);
                    pageVendor.Show();
                    break;

                default:
                    break;
            }
        }
    }
}       
    
