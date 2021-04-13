
namespace WisejWebPageApplication1
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuBar1 = new Wisej.Web.MenuBar();
            this.menuItemFile = new Wisej.Web.MenuItem();
            this.menuItemCustomer = new Wisej.Web.MenuItem();
            this.menuItemVendor = new Wisej.Web.MenuItem();
            this.comboBoxLanguaje = new Wisej.Web.ComboBox();
            this.SuspendLayout();
            // 
            // menuBar1
            // 
            this.menuBar1.Dock = Wisej.Web.DockStyle.Top;
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItemFile});
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(1210, 28);
            this.menuBar1.TabIndex = 0;
            this.menuBar1.TabStop = false;
            this.menuBar1.MenuItemClicked += new Wisej.Web.MenuItemEventHandler(this.menuBar1_MenuItemClicked);
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItemCustomer,
            this.menuItemVendor});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Text = "Ficheros";
            this.menuItemFile.Click += new System.EventHandler(this.menuItemFile_Click);
            // 
            // menuItemCustomer
            // 
            this.menuItemCustomer.Index = 0;
            this.menuItemCustomer.Name = "menuItemCustomer";
            this.menuItemCustomer.Text = "Clientes";
            // 
            // menuItemVendor
            // 
            this.menuItemVendor.Index = 1;
            this.menuItemVendor.Name = "menuItemVendor";
            this.menuItemVendor.Text = "Suplidores";
            // 
            // comboBoxLanguaje
            // 
            this.comboBoxLanguaje.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList;
            this.comboBoxLanguaje.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.comboBoxLanguaje.LabelText = "Seleccione el Idioma";
            this.comboBoxLanguaje.Location = new System.Drawing.Point(438, 280);
            this.comboBoxLanguaje.Name = "comboBoxLanguaje";
            this.comboBoxLanguaje.Size = new System.Drawing.Size(493, 37);
            this.comboBoxLanguaje.TabIndex = 1;
            this.comboBoxLanguaje.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguaje_SelectedIndexChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxLanguaje);
            this.Controls.Add(this.menuBar1);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1210, 428);
            this.Text = "Page1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.MenuBar menuBar1;
        private Wisej.Web.MenuItem menuItemFile;
        private Wisej.Web.MenuItem menuItemCustomer;
        private Wisej.Web.MenuItem menuItemVendor;
        private Wisej.Web.ComboBox comboBoxLanguaje;
    }
}

