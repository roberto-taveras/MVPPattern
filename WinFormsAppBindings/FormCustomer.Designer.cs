
namespace WinFormsAppBindings
{
    partial class FormCustomer
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
            this.labelCustomerTypeId = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBoxCustomerType = new System.Windows.Forms.ComboBox();
            this.labelAdress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(111, 49);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(58, 20);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Codigo";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(105, 88);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(64, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Nombre";
            // 
            // labelCustomerTypeId
            // 
            this.labelCustomerTypeId.AutoSize = true;
            this.labelCustomerTypeId.Location = new System.Drawing.Point(59, 204);
            this.labelCustomerTypeId.Name = "labelCustomerTypeId";
            this.labelCustomerTypeId.Size = new System.Drawing.Size(110, 20);
            this.labelCustomerTypeId.TabIndex = 2;
            this.labelCustomerTypeId.Text = "Tipo de Cliente";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(177, 86);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(314, 27);
            this.textBoxNombre.TabIndex = 2;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(177, 124);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(314, 27);
            this.textBoxDireccion.TabIndex = 3;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(177, 244);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(94, 29);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "Nuevo";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(287, 245);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(177, 49);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(314, 27);
            this.textBoxId.TabIndex = 1;
            this.textBoxId.Text = "  ";
            this.textBoxId.Leave += new System.EventHandler(this.textBoxId_Leave);
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Location = new System.Drawing.Point(177, 166);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(77, 24);
            this.checkBoxStatus.TabIndex = 6;
            this.checkBoxStatus.Text = "Estatus";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(399, 245);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(94, 29);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // comboBoxCustomerType
            // 
            this.comboBoxCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomerType.FormattingEnabled = true;
            this.comboBoxCustomerType.Location = new System.Drawing.Point(177, 200);
            this.comboBoxCustomerType.Name = "comboBoxCustomerType";
            this.comboBoxCustomerType.Size = new System.Drawing.Size(314, 28);
            this.comboBoxCustomerType.TabIndex = 9;
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.Location = new System.Drawing.Point(97, 128);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(72, 20);
            this.labelAdress.TabIndex = 11;
            this.labelAdress.Text = "Direccion";
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 509);
            this.Controls.Add(this.labelAdress);
            this.Controls.Add(this.comboBoxCustomerType);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.checkBoxStatus);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelCustomerTypeId);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelId);
            this.Name = "FormCustomer";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCustomerTypeId;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxCustomerType;
        private System.Windows.Forms.Label labelAdress;
    }
}

