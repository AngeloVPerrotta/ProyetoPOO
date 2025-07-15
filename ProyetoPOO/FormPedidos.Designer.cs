namespace UI
{
    partial class FormPedidos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerPedido = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEntrega = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonGenerarpedido = new System.Windows.Forms.Button();
            this.txt_costo = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.txt_codproducto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_proveedor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewPedidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Realizar pedido";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad solicitada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código del producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha del pedido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha estimada de entrega";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Costo";
            // 
            // dateTimePickerPedido
            // 
            this.dateTimePickerPedido.Location = new System.Drawing.Point(415, 126);
            this.dateTimePickerPedido.Name = "dateTimePickerPedido";
            this.dateTimePickerPedido.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPedido.TabIndex = 6;
            // 
            // dateTimePickerEntrega
            // 
            this.dateTimePickerEntrega.Location = new System.Drawing.Point(415, 162);
            this.dateTimePickerEntrega.Name = "dateTimePickerEntrega";
            this.dateTimePickerEntrega.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEntrega.TabIndex = 7;
            // 
            // buttonGenerarpedido
            // 
            this.buttonGenerarpedido.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGenerarpedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarpedido.ForeColor = System.Drawing.Color.White;
            this.buttonGenerarpedido.Location = new System.Drawing.Point(662, 127);
            this.buttonGenerarpedido.Name = "buttonGenerarpedido";
            this.buttonGenerarpedido.Size = new System.Drawing.Size(111, 66);
            this.buttonGenerarpedido.TabIndex = 8;
            this.buttonGenerarpedido.Text = "Generar pedido";
            this.buttonGenerarpedido.UseVisualStyleBackColor = false;
            this.buttonGenerarpedido.Click += new System.EventHandler(this.buttonGenerarpedido_Click);
            // 
            // txt_costo
            // 
            this.txt_costo.Location = new System.Drawing.Point(415, 198);
            this.txt_costo.Name = "txt_costo";
            this.txt_costo.Size = new System.Drawing.Size(200, 20);
            this.txt_costo.TabIndex = 9;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(415, 61);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(200, 20);
            this.txt_cantidad.TabIndex = 10;
            // 
            // txt_codproducto
            // 
            this.txt_codproducto.Location = new System.Drawing.Point(415, 93);
            this.txt_codproducto.Name = "txt_codproducto";
            this.txt_codproducto.Size = new System.Drawing.Size(200, 20);
            this.txt_codproducto.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(664, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 66);
            this.button1.TabIndex = 15;
            this.button1.Text = "Modificar pedido";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_proveedor
            // 
            this.txt_proveedor.Location = new System.Drawing.Point(415, 19);
            this.txt_proveedor.Name = "txt_proveedor";
            this.txt_proveedor.Size = new System.Drawing.Size(200, 20);
            this.txt_proveedor.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Proveedor";
            // 
            // dataGridViewPedidos
            // 
            this.dataGridViewPedidos.AllowUserToAddRows = false;
            this.dataGridViewPedidos.AllowUserToDeleteRows = false;
            this.dataGridViewPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPedidos.Location = new System.Drawing.Point(40, 269);
            this.dataGridViewPedidos.Name = "dataGridViewPedidos";
            this.dataGridViewPedidos.ReadOnly = true;
            this.dataGridViewPedidos.Size = new System.Drawing.Size(733, 178);
            this.dataGridViewPedidos.TabIndex = 13;
            this.dataGridViewPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPedidos_CellClick);
            this.dataGridViewPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPedidos_CellContentClick);
            // 
            // FormPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 477);
            this.Controls.Add(this.dataGridViewPedidos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGenerarpedido);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_proveedor);
            this.Controls.Add(this.dateTimePickerPedido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_costo);
            this.Controls.Add(this.dateTimePickerEntrega);
            this.Controls.Add(this.txt_codproducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormPedidos";
            this.Text = "PEDIDOS";
            this.Load += new System.EventHandler(this.FormPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerPedido;
        private System.Windows.Forms.DateTimePicker dateTimePickerEntrega;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonGenerarpedido;
        private System.Windows.Forms.TextBox txt_costo;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.TextBox txt_codproducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_proveedor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;
    }
}