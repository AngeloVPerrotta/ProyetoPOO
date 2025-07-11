namespace ProyetoPOO
{
    partial class FormRecepciones
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
            this.btn_CargarRecepcion = new System.Windows.Forms.Button();
            this.num_cajas = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewRecepciones = new System.Windows.Forms.DataGridView();
            this.dtp_llegada = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_empleado = new System.Windows.Forms.TextBox();
            this.txt_remito = new System.Windows.Forms.TextBox();
            this.txt_proveedor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_cajas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CargarRecepcion
            // 
            this.btn_CargarRecepcion.Location = new System.Drawing.Point(64, 348);
            this.btn_CargarRecepcion.Name = "btn_CargarRecepcion";
            this.btn_CargarRecepcion.Size = new System.Drawing.Size(100, 41);
            this.btn_CargarRecepcion.TabIndex = 24;
            this.btn_CargarRecepcion.Text = "Cargar recepcion";
            this.btn_CargarRecepcion.UseVisualStyleBackColor = true;
            // 
            // num_cajas
            // 
            this.num_cajas.Location = new System.Drawing.Point(28, 254);
            this.num_cajas.Name = "num_cajas";
            this.num_cajas.Size = new System.Drawing.Size(120, 20);
            this.num_cajas.TabIndex = 23;
            // 
            // dataGridViewRecepciones
            // 
            this.dataGridViewRecepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecepciones.Location = new System.Drawing.Point(269, 84);
            this.dataGridViewRecepciones.Name = "dataGridViewRecepciones";
            this.dataGridViewRecepciones.Size = new System.Drawing.Size(507, 280);
            this.dataGridViewRecepciones.TabIndex = 22;
            // 
            // dtp_llegada
            // 
            this.dtp_llegada.Location = new System.Drawing.Point(28, 313);
            this.dtp_llegada.Name = "dtp_llegada";
            this.dtp_llegada.Size = new System.Drawing.Size(200, 20);
            this.dtp_llegada.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Hora de llegada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cantidad de cajas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Empleado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nº Remito";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Proveedor ";
            // 
            // txt_empleado
            // 
            this.txt_empleado.Location = new System.Drawing.Point(28, 189);
            this.txt_empleado.Name = "txt_empleado";
            this.txt_empleado.Size = new System.Drawing.Size(100, 20);
            this.txt_empleado.TabIndex = 15;
            // 
            // txt_remito
            // 
            this.txt_remito.Location = new System.Drawing.Point(28, 134);
            this.txt_remito.Name = "txt_remito";
            this.txt_remito.Size = new System.Drawing.Size(100, 20);
            this.txt_remito.TabIndex = 14;
            // 
            // txt_proveedor
            // 
            this.txt_proveedor.Location = new System.Drawing.Point(28, 78);
            this.txt_proveedor.Name = "txt_proveedor";
            this.txt_proveedor.Size = new System.Drawing.Size(100, 20);
            this.txt_proveedor.TabIndex = 13;
            // 
            // FormRecepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_CargarRecepcion);
            this.Controls.Add(this.num_cajas);
            this.Controls.Add(this.dataGridViewRecepciones);
            this.Controls.Add(this.dtp_llegada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_empleado);
            this.Controls.Add(this.txt_remito);
            this.Controls.Add(this.txt_proveedor);
            this.Name = "FormRecepciones";
            this.Text = "FormRecepciones";
            ((System.ComponentModel.ISupportInitialize)(this.num_cajas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecepciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CargarRecepcion;
        private System.Windows.Forms.NumericUpDown num_cajas;
        private System.Windows.Forms.DataGridView dataGridViewRecepciones;
        private System.Windows.Forms.DateTimePicker dtp_llegada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_empleado;
        private System.Windows.Forms.TextBox txt_remito;
        private System.Windows.Forms.TextBox txt_proveedor;
    }
}