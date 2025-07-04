namespace ProyetoPOO
{
    partial class FormMensajes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRemitente = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDestinatarioRol = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRemitente);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMensaje);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbDestinatarioRol);
            this.groupBox1.Location = new System.Drawing.Point(21, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(547, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Envia un mensaje";
            // 
            // lblRemitente
            // 
            this.lblRemitente.AutoSize = true;
            this.lblRemitente.Location = new System.Drawing.Point(349, 15);
            this.lblRemitente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemitente.Name = "lblRemitente";
            this.lblRemitente.Size = new System.Drawing.Size(104, 13);
            this.lblRemitente.TabIndex = 5;
            this.lblRemitente.Text = "USUARIO ACTUAL:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 301);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(488, 19);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enviar mensaje";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mensaje";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(40, 95);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(440, 185);
            this.txtMensaje.TabIndex = 2;
            this.txtMensaje.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Destinatario";
            // 
            // cmbDestinatarioRol
            // 
            this.cmbDestinatarioRol.FormattingEnabled = true;
            this.cmbDestinatarioRol.Location = new System.Drawing.Point(226, 50);
            this.cmbDestinatarioRol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDestinatarioRol.Name = "cmbDestinatarioRol";
            this.cmbDestinatarioRol.Size = new System.Drawing.Size(92, 21);
            this.cmbDestinatarioRol.TabIndex = 0;
            // 
            // FormMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMensajes";
            this.Text = "MENSAJES";
            this.Load += new System.EventHandler(this.FormMensajes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDestinatarioRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtMensaje;
        private System.Windows.Forms.Label lblRemitente;
    }
}

