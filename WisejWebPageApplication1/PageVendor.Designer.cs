
namespace WisejWebPageApplication1
{
    partial class PageVendor
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
            this.panel1 = new Wisej.Web.Panel();
            this.buttonSearch = new Wisej.Web.Button();
            this.textBoxSearch = new Wisej.Web.TextBox();
            this.buttonDelete = new Wisej.Web.Button();
            this.buttonSave = new Wisej.Web.Button();
            this.buttonNew = new Wisej.Web.Button();
            this.comboBoxVendorType = new Wisej.Web.ComboBox();
            this.checkBoxStatus = new Wisej.Web.CheckBox();
            this.textBoxAdress = new Wisej.Web.TextBox();
            this.textBoxVendName = new Wisej.Web.TextBox();
            this.textBoxId = new Wisej.Web.TextBox();
            this.dataGridViewCustomer = new Wisej.Web.DataGridView();
            this.dataRepeater1 = new Wisej.Web.DataRepeater();
            this.buttonClose = new Wisej.Web.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRepeater1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonNew);
            this.panel1.Controls.Add(this.comboBoxVendorType);
            this.panel1.Controls.Add(this.checkBoxStatus);
            this.panel1.Controls.Add(this.textBoxAdress);
            this.panel1.Controls.Add(this.textBoxVendName);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Dock = Wisej.Web.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 376);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(547, 325);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(100, 27);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.textBoxSearch.LabelText = "Buscar...";
            this.textBoxSearch.Location = new System.Drawing.Point(132, 325);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(389, 37);
            this.textBoxSearch.TabIndex = 8;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(399, 282);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 27);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Eliminar";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(263, 282);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 27);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(134, 283);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(100, 27);
            this.buttonNew.TabIndex = 5;
            this.buttonNew.Text = "Nuevo";
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // comboBoxVendorType
            // 
            this.comboBoxVendorType.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList;
            this.comboBoxVendorType.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.comboBoxVendorType.LabelText = "Tipo Suplidor";
            this.comboBoxVendorType.Location = new System.Drawing.Point(132, 212);
            this.comboBoxVendorType.Name = "comboBoxVendorType";
            this.comboBoxVendorType.Size = new System.Drawing.Size(389, 37);
            this.comboBoxVendorType.TabIndex = 4;
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.Location = new System.Drawing.Point(132, 177);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(75, 22);
            this.checkBoxStatus.TabIndex = 3;
            this.checkBoxStatus.Text = "Estatus";
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.textBoxAdress.LabelText = "Direccion";
            this.textBoxAdress.Location = new System.Drawing.Point(132, 123);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(394, 37);
            this.textBoxAdress.TabIndex = 2;
            // 
            // textBoxVendName
            // 
            this.textBoxVendName.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.textBoxVendName.LabelText = "Nombre";
            this.textBoxVendName.Location = new System.Drawing.Point(132, 76);
            this.textBoxVendName.Name = "textBoxVendName";
            this.textBoxVendName.Size = new System.Drawing.Size(394, 37);
            this.textBoxVendName.TabIndex = 1;
            // 
            // textBoxId
            // 
            this.textBoxId.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.textBoxId.LabelText = "Codigo";
            this.textBoxId.Location = new System.Drawing.Point(132, 33);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(394, 37);
            this.textBoxId.TabIndex = 0;
            this.textBoxId.Leave += new System.EventHandler(this.textBoxId_Leave);
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.Dock = Wisej.Web.DockStyle.Fill;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(0, 376);
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.dataGridViewCustomer.Size = new System.Drawing.Size(1027, 363);
            this.dataGridViewCustomer.TabIndex = 1;
            this.dataGridViewCustomer.DoubleClick += new System.EventHandler(this.dataGridViewCustomer_DoubleClick);
            // 
            // dataRepeater1
            // 
            this.dataRepeater1.ItemSize = new System.Drawing.Size(200, 100);
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(200, 100);
            this.dataRepeater1.Location = new System.Drawing.Point(0, 0);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(200, 100);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(547, 282);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 27);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // PageVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewCustomer);
            this.Controls.Add(this.panel1);
            this.Name = "PageVendor";
            this.Size = new System.Drawing.Size(1027, 739);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRepeater1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Panel panel1;
        private Wisej.Web.DataGridView dataGridViewCustomer;
        private Wisej.Web.DataRepeater dataRepeater1;
        private Wisej.Web.TextBox textBoxAdress;
        private Wisej.Web.TextBox textBoxVendName;
        private Wisej.Web.TextBox textBoxId;
        private Wisej.Web.TextBox textBoxSearch;
        private Wisej.Web.Button buttonDelete;
        private Wisej.Web.Button buttonSave;
        private Wisej.Web.Button buttonNew;
        private Wisej.Web.ComboBox comboBoxVendorType;
        private Wisej.Web.CheckBox checkBoxStatus;
        private Wisej.Web.Button buttonSearch;
        private Wisej.Web.Button buttonClose;
    }
}
