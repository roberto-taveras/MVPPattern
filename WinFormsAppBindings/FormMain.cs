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

         


            comboBoxLanguaje.DataSource = Helpers.Singleton.Instance;
            comboBoxLanguaje.ValueMember = nameof(Helpers.Languaje.Id);
            comboBoxLanguaje.DisplayMember = nameof(Helpers.Languaje.Description);
            comboBoxLanguaje.SelectedIndex = 0;

            comboBoxLanguaje.SelectedValueChanged += (sender, e) => {
               
                if(comboBoxLanguaje.SelectedValue != null)
                    translate(); 


            };




        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void toolStripMenuItemCustome_Click(object sender, EventArgs e)
        {
            //"es-DO" espanol

            businessObjectsResourceManager = new BusinessObjectsResourceManager(comboBoxLanguaje.SelectedValue.ToString());
            FormCustomer customer = new FormCustomer(businessObjectsResourceManager);
            customer.Show();

        }

        private void translate()
        {
            businessObjectsResourceManager = new BusinessObjectsResourceManager(comboBoxLanguaje.SelectedValue.ToString());
            _translate = new HelperControlsTranslate(this, businessObjectsResourceManager);
            _translate.Translate();
        }

        private void toolStripMenuItemVendor_Click(object sender, EventArgs e)
        {

            businessObjectsResourceManager = new BusinessObjectsResourceManager(comboBoxLanguaje.SelectedValue.ToString());
            FormVendor formVendor = new FormVendor(businessObjectsResourceManager);
            formVendor.Show();
        }
    }
}
