
namespace WinFormsAppBindings
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuFiles = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVendor = new System.Windows.Forms.ToolStripMenuItem();
            this.labelLanguaje = new System.Windows.Forms.Label();
            this.comboBoxLanguaje = new System.Windows.Forms.ComboBox();
            this.menuFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuFiles
            // 
            this.menuFiles.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCustomer,
            this.toolStripMenuItemVendor});
            this.menuFiles.Location = new System.Drawing.Point(0, 0);
            this.menuFiles.Name = "menuFiles";
            this.menuFiles.Size = new System.Drawing.Size(931, 28);
            this.menuFiles.TabIndex = 0;
            this.menuFiles.Text = "Ficheros";
            this.menuFiles.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItemCustomer
            // 
            this.toolStripMenuItemCustomer.Name = "toolStripMenuItemCustomer";
            this.toolStripMenuItemCustomer.Size = new System.Drawing.Size(75, 24);
            this.toolStripMenuItemCustomer.Text = "Clientes";
            this.toolStripMenuItemCustomer.Click += new System.EventHandler(this.toolStripMenuItemCustome_Click);
            // 
            // toolStripMenuItemVendor
            // 
            this.toolStripMenuItemVendor.Name = "toolStripMenuItemVendor";
            this.toolStripMenuItemVendor.Size = new System.Drawing.Size(93, 24);
            this.toolStripMenuItemVendor.Text = "Suplidores";
            this.toolStripMenuItemVendor.Click += new System.EventHandler(this.toolStripMenuItemVendor_Click);
            // 
            // labelLanguaje
            // 
            this.labelLanguaje.AutoSize = true;
            this.labelLanguaje.Location = new System.Drawing.Point(33, 132);
            this.labelLanguaje.Name = "labelLanguaje";
            this.labelLanguaje.Size = new System.Drawing.Size(147, 20);
            this.labelLanguaje.TabIndex = 1;
            this.labelLanguaje.Text = "Seleccione el Idioma";
            // 
            // comboBoxLanguaje
            // 
            this.comboBoxLanguaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguaje.FormattingEnabled = true;
            this.comboBoxLanguaje.Location = new System.Drawing.Point(186, 129);
            this.comboBoxLanguaje.Name = "comboBoxLanguaje";
            this.comboBoxLanguaje.Size = new System.Drawing.Size(282, 28);
            this.comboBoxLanguaje.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 450);
            this.Controls.Add(this.comboBoxLanguaje);
            this.Controls.Add(this.labelLanguaje);
            this.Controls.Add(this.menuFiles);
            this.MainMenuStrip = this.menuFiles;
            this.Name = "FormMain";
            this.Text = "Sistema de Facturacion";
            this.menuFiles.ResumeLayout(false);
            this.menuFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuFiles;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCustomer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVendor;
        private System.Windows.Forms.Label labelLanguaje;
        private System.Windows.Forms.ComboBox comboBoxLanguaje;
    }
}