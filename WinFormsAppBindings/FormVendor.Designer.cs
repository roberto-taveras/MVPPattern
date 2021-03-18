
namespace WinFormsAppBindings
{
    partial class FormVendor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelId = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelVendorTypeId = new System.Windows.Forms.Label();
            this.textBoxVendorName = new System.Windows.Forms.TextBox();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBoxVendorType = new System.Windows.Forms.ComboBox();
            this.labelAdress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.dataGridViewCustomer = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelId.Location = new System.Drawing.Point(105, 40);
            this.labelId.Name = "labelId";
            this.labelId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelId.Size = new System.Drawing.Size(58, 20);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Codigo";
            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelName.Location = new System.Drawing.Point(99, 79);
            this.labelName.Name = "labelName";
            this.labelName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelName.Size = new System.Drawing.Size(64, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVendorTypeId
            // 
            this.labelVendorTypeId.AutoSize = true;
            this.labelVendorTypeId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelVendorTypeId.Location = new System.Drawing.Point(64, 201);
            this.labelVendorTypeId.Name = "labelVendorTypeId";
            this.labelVendorTypeId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelVendorTypeId.Size = new System.Drawing.Size(99, 20);
            this.labelVendorTypeId.TabIndex = 2;
            this.labelVendorTypeId.Text = "Tipo Suplidor";
            this.labelVendorTypeId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelVendorTypeId.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxVendorName
            // 
            this.textBoxVendorName.Location = new System.Drawing.Point(167, 77);
            this.textBoxVendorName.Name = "textBoxVendorName";
            this.textBoxVendorName.Size = new System.Drawing.Size(314, 27);
            this.textBoxVendorName.TabIndex = 2;
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(167, 114);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(314, 27);
            this.textBoxAdress.TabIndex = 3;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(168, 239);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(94, 29);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "Nuevo";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(274, 239);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(167, 38);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(314, 27);
            this.textBoxId.TabIndex = 1;
            this.textBoxId.Text = "  ";
            this.textBoxId.Leave += new System.EventHandler(this.textBoxId_Leave);
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Location = new System.Drawing.Point(166, 161);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(77, 24);
            this.checkBoxStatus.TabIndex = 6;
            this.checkBoxStatus.Text = "Estatus";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(383, 239);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(94, 29);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // comboBoxVendorType
            // 
            this.comboBoxVendorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVendorType.FormattingEnabled = true;
            this.comboBoxVendorType.Location = new System.Drawing.Point(167, 199);
            this.comboBoxVendorType.Name = "comboBoxVendorType";
            this.comboBoxVendorType.Size = new System.Drawing.Size(314, 28);
            this.comboBoxVendorType.TabIndex = 8;
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelAdress.Location = new System.Drawing.Point(91, 118);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelAdress.Size = new System.Drawing.Size(72, 20);
            this.labelAdress.TabIndex = 12;
            this.labelAdress.Text = "Direccion";
            this.labelAdress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.labelSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 329);
            this.panel1.TabIndex = 13;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(166, 287);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(311, 27);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(108, 290);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(52, 20);
            this.labelSearch.TabIndex = 2;
            this.labelSearch.Text = "Buscar";
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.AllowUserToAddRows = false;
            this.dataGridViewCustomer.AllowUserToDeleteRows = false;
            this.dataGridViewCustomer.AllowUserToOrderColumns = true;
            this.dataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(0, 329);
            this.dataGridViewCustomer.MultiSelect = false;
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.dataGridViewCustomer.ReadOnly = true;
            this.dataGridViewCustomer.RowHeadersWidth = 51;
            this.dataGridViewCustomer.RowTemplate.Height = 29;
            this.dataGridViewCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustomer.Size = new System.Drawing.Size(1032, 180);
            this.dataGridViewCustomer.TabIndex = 14;
            this.dataGridViewCustomer.DoubleClick += new System.EventHandler(this.dataGridViewCustomer_DoubleClick);
            // 
            // FormVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 509);
            this.Controls.Add(this.dataGridViewCustomer);
            this.Controls.Add(this.labelAdress);
            this.Controls.Add(this.comboBoxVendorType);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.checkBoxStatus);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.textBoxAdress);
            this.Controls.Add(this.textBoxVendorName);
            this.Controls.Add(this.labelVendorTypeId);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.panel1);
            this.Name = "FormVendor";
            this.Text = "Suplidores";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelVendorTypeId;
        private System.Windows.Forms.TextBox textBoxVendorName;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxVendorType;
        private System.Windows.Forms.Label labelAdress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.DataGridView dataGridViewCustomer;
    }
}

