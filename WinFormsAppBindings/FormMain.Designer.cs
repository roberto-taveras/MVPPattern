
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemCustome = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVendor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCustome,
            this.toolStripMenuItemVendor});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItemCustome
            // 
            this.toolStripMenuItemCustome.Name = "toolStripMenuItemCustome";
            this.toolStripMenuItemCustome.Size = new System.Drawing.Size(86, 24);
            this.toolStripMenuItemCustome.Text = "Customer";
            this.toolStripMenuItemCustome.Click += new System.EventHandler(this.toolStripMenuItemCustome_Click);
            // 
            // toolStripMenuItemVendor
            // 
            this.toolStripMenuItemVendor.Name = "toolStripMenuItemVendor";
            this.toolStripMenuItemVendor.Size = new System.Drawing.Size(70, 24);
            this.toolStripMenuItemVendor.Text = "Vendor";
            this.toolStripMenuItemVendor.Click += new System.EventHandler(this.toolStripMenuItemVendor_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Invoice System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCustome;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVendor;
    }
}