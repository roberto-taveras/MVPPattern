﻿using System;
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
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItemCustome_Click(object sender, EventArgs e)
        {
            //"es-DO" espanol
            FormCustomer customer = new FormCustomer("en-US");
            customer.Show();

        }

        private void toolStripMenuItemVendor_Click(object sender, EventArgs e)
        {
            FormVendor formVendor = new FormVendor("en-US");
            formVendor.Show();
        }
    }
}
