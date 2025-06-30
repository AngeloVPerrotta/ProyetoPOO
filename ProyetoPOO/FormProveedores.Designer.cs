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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewProv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonElimProv = new System.Windows.Forms.Button();
            this.buttonAgregarProv = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRubro = new System.Windows.Forms.TextBox();
            this.textBoxProv = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewProv);
            this.panel1.Location = new System.Drawing.Point(260, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 367);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewProv
            // 
            this.dataGridViewProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProv.Location = new System.Drawing.Point(18, 19);
            this.dataGridViewProv.Name = "dataGridViewProv";
            this.dataGridViewProv.Size = new System.Drawing.Size(354, 331);
            this.dataGridViewProv.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonElimProv);
            this.panel2.Controls.Add(this.buttonAgregarProv);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxRubro);
            this.panel2.Controls.Add(this.textBoxProv);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 222);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonElimProv
            // 
            this.buttonElimProv.Location = new System.Drawing.Point(35, 167);
            this.buttonElimProv.Name = "buttonElimProv";
            this.buttonElimProv.Size = new System.Drawing.Size(178, 23);
            this.buttonElimProv.TabIndex = 6;
            this.buttonElimProv.Text = "Eliminar proveedor";
            this.buttonElimProv.UseVisualStyleBackColor = true;
            // 
            // buttonAgregarProv
            // 
            this.buttonAgregarProv.Location = new System.Drawing.Point(35, 121);
            this.buttonAgregarProv.Name = "buttonAgregarProv";
            this.buttonAgregarProv.Size = new System.Drawing.Size(178, 23);
            this.buttonAgregarProv.TabIndex = 5;
            this.buttonAgregarProv.Text = "Agregar Proveedor";
            this.buttonAgregarProv.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(57, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Agregar nuevo proveedor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rubro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proveedor";
            // 
            // textBoxRubro
            // 
            this.textBoxRubro.Location = new System.Drawing.Point(113, 82);
            this.textBoxRubro.Name = "textBoxRubro";
            this.textBoxRubro.Size = new System.Drawing.Size(100, 20);
            this.textBoxRubro.TabIndex = 1;
            // 
            // textBoxProv
            // 
            this.textBoxProv.Location = new System.Drawing.Point(113, 56);
            this.textBoxProv.Name = "textBoxProv";
            this.textBoxProv.Size = new System.Drawing.Size(100, 20);
            this.textBoxProv.TabIndex = 0;
            // 
            // FormProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 402);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormProveedores";
            this.Text = "FormProveedores";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewProv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxRubro;
        private System.Windows.Forms.TextBox textBoxProv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonElimProv;
        private System.Windows.Forms.Button buttonAgregarProv;
    }
}