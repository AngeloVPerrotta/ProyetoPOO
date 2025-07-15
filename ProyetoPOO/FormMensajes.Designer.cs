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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDestinatarioRol = new System.Windows.Forms.ComboBox();
            this.lblRemitente = new System.Windows.Forms.Label();
            this.dgvMensajes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(35, 145);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(488, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enviar mensaje";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mensaje";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(54, 78);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(2);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(440, 63);
            this.txtMensaje.TabIndex = 2;
            this.txtMensaje.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Destinatario";
            // 
            // cmbDestinatarioRol
            // 
            this.cmbDestinatarioRol.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbDestinatarioRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestinatarioRol.ForeColor = System.Drawing.Color.White;
            this.cmbDestinatarioRol.FormattingEnabled = true;
            this.cmbDestinatarioRol.Location = new System.Drawing.Point(240, 33);
            this.cmbDestinatarioRol.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDestinatarioRol.Name = "cmbDestinatarioRol";
            this.cmbDestinatarioRol.Size = new System.Drawing.Size(92, 21);
            this.cmbDestinatarioRol.TabIndex = 0;
            // 
            // lblRemitente
            // 
            this.lblRemitente.AutoSize = true;
            this.lblRemitente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRemitente.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRemitente.Location = new System.Drawing.Point(11, 9);
            this.lblRemitente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemitente.Name = "lblRemitente";
            this.lblRemitente.Size = new System.Drawing.Size(150, 21);
            this.lblRemitente.TabIndex = 5;
            this.lblRemitente.Text = "USUARIO ACTUAL:";
            // 
            // dgvMensajes
            // 
            this.dgvMensajes.AllowUserToAddRows = false;
            this.dgvMensajes.AllowUserToDeleteRows = false;
            this.dgvMensajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMensajes.Location = new System.Drawing.Point(29, 230);
            this.dgvMensajes.Name = "dgvMensajes";
            this.dgvMensajes.Size = new System.Drawing.Size(513, 244);
            this.dgvMensajes.TabIndex = 1;
            // 
            // FormMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvMensajes);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.lblRemitente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDestinatarioRol);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMensajes";
            this.Text = "MENSAJES";
            this.Load += new System.EventHandler(this.FormMensajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDestinatarioRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtMensaje;
        private System.Windows.Forms.Label lblRemitente;
        private System.Windows.Forms.DataGridView dgvMensajes;
    }
}

