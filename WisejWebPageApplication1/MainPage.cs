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
    
