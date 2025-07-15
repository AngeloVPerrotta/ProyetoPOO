namespace ProyetoPOO
{
    partial class FormProveedores
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
            this.dataGridViewProv = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProv = new System.Windows.Forms.TextBox();
            this.textBoxRubro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAgregarProv = new System.Windows.Forms.Button();
            this.buttonElimProv = new System.Windows.Forms.Button();
            this.textBoxContacto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProv)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProv
            // 
            this.dataGridViewProv.AllowUserToAddRows = false;
            this.dataGridViewProv.AllowUserToDeleteRows = false;
            this.dataGridViewProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProv.Location = new System.Drawing.Point(290, 99);
            this.dataGridViewProv.Name = "dataGridViewProv";
            this.dataGridViewProv.ReadOnly = true;
            this.dataGridViewProv.Size = new System.Drawing.Size(586, 245);
            this.dataGridViewProv.TabIndex = 0;
            this.dataGridViewProv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProv_CellClick);
            this.dataGridViewProv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProv_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Agregar nuevo proveedor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxProv
            // 
            this.textBoxProv.Location = new System.Drawing.Point(128, 114);
            this.textBoxProv.Name = "textBoxProv";
            this.textBoxProv.Size = new System.Drawing.Size(100, 20);
            this.textBoxProv.TabIndex = 0;
            // 
            // textBoxRubro
            // 
            this.textBoxRubro.Location = new System.Drawing.Point(128, 150);
            this.textBoxRubro.Name = "textBoxRubro";
            this.textBoxRubro.Size = new System.Drawing.Size(100, 20);
            this.textBoxRubro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rubro";
            // 
            // buttonAgregarProv
            // 
            this.buttonAgregarProv.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAgregarProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarProv.ForeColor = System.Drawing.Color.White;
            this.buttonAgregarProv.Location = new System.Drawing.Point(50, 220);
            this.buttonAgregarProv.Name = "buttonAgregarProv";
            this.buttonAgregarProv.Size = new System.Drawing.Size(178, 30);
            this.buttonAgregarProv.TabIndex = 5;
            this.buttonAgregarProv.Text = "Agregar Proveedor";
            this.buttonAgregarProv.UseVisualStyleBackColor = false;
            this.buttonAgregarProv.Click += new System.EventHandler(this.buttonAgregarProv_Click);
            // 
            // buttonElimProv
            // 
            this.buttonElimProv.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonElimProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonElimProv.ForeColor = System.Drawing.Color.White;
            this.buttonElimProv.Location = new System.Drawing.Point(50, 256);
            this.buttonElimProv.Name = "buttonElimProv";
            this.buttonElimProv.Size = new System.Drawing.Size(178, 31);
            this.buttonElimProv.TabIndex = 6;
            this.buttonElimProv.Text = "Eliminar proveedor";
            this.buttonElimProv.UseVisualStyleBackColor = false;
            this.buttonElimProv.Click += new System.EventHandler(this.buttonElimProv_Click);
            // 
            // textBoxContacto
            // 
            this.textBoxContacto.Location = new System.Drawing.Point(128, 181);
            this.textBoxContacto.Name = "textBoxContacto";
            this.textBoxContacto.Size = new System.Drawing.Size(100, 20);
            this.textBoxContacto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Contacto";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(50, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "Modificar proveedor";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 374);
            this.Controls.Add(this.dataGridViewProv);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxContacto);
            this.Controls.Add(this.buttonElimProv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAgregarProv);
            this.Controls.Add(this.textBoxProv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRubro);
            this.Controls.Add(this.label1);
            this.Name = "FormProveedores";
            this.Text = "PROVEEDORES";
            this.Load += new System.EventHandler(this.FormProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewProv;
        private System.Windows.Forms.TextBox textBoxProv;
        private System.Windows.Forms.TextBox textBoxRubro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAgregarProv;
        private System.Windows.Forms.Button buttonElimProv;
        private System.Windows.Forms.TextBox textBoxContacto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}