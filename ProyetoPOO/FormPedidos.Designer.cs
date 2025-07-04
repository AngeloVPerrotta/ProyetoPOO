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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_proveedor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Realizar pedido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad solicitada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código del producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha del pedido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha estimada de entrega";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Costo";
            // 
            // dateTimePickerPedido
            // 
            this.dateTimePickerPedido.Location = new System.Drawing.Point(180, 137);
            this.dateTimePickerPedido.Name = "dateTimePickerPedido";
            this.dateTimePickerPedido.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPedido.TabIndex = 6;
            // 
            // dateTimePickerEntrega
            // 
            this.dateTimePickerEntrega.Location = new System.Drawing.Point(180, 161);
            this.dateTimePickerEntrega.Name = "dateTimePickerEntrega";
            this.dateTimePickerEntrega.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEntrega.TabIndex = 7;
            // 
            // buttonGenerarpedido
            // 
            this.buttonGenerarpedido.Location = new System.Drawing.Point(18, 235);
            this.buttonGenerarpedido.Name = "buttonGenerarpedido";
            this.buttonGenerarpedido.Size = new System.Drawing.Size(97, 23);
            this.buttonGenerarpedido.TabIndex = 8;
            this.buttonGenerarpedido.Text = "Generar pedido";
            this.buttonGenerarpedido.UseVisualStyleBackColor = true;
            this.buttonGenerarpedido.Click += new System.EventHandler(this.buttonGenerarpedido_Click);
            // 
            // txt_costo
            // 
            this.txt_costo.Location = new System.Drawing.Point(180, 187);
            this.txt_costo.Name = "txt_costo";
            this.txt_costo.Size = new System.Drawing.Size(100, 20);
            this.txt_costo.TabIndex = 9;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(180, 86);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(100, 20);
            this.txt_cantidad.TabIndex = 10;
            // 
            // txt_codproducto
            // 
            this.txt_codproducto.Location = new System.Drawing.Point(180, 110);
            this.txt_codproducto.Name = "txt_codproducto";
            this.txt_codproducto.Size = new System.Drawing.Size(100, 20);
            this.txt_codproducto.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_proveedor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_costo);
            this.panel1.Controls.Add(this.txt_codproducto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_cantidad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonGenerarpedido);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateTimePickerEntrega);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimePickerPedido);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 280);
            this.panel1.TabIndex = 12;
            // 
            // txt_proveedor
            // 
            this.txt_proveedor.Location = new System.Drawing.Point(180, 60);
            this.txt_proveedor.Name = "txt_proveedor";
            this.txt_proveedor.Size = new System.Drawing.Size(100, 20);
            this.txt_proveedor.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Proveedor";
            // 
            // FormPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormPedidos";
            this.Text = "PEDIDOS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_proveedor;
    }
}