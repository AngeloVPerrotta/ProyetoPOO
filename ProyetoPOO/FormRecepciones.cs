using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyetoPOO
{
    public partial class FormRecepciones : Form, IObserver
    {

        private string rutaCsv = Path.Combine(Application.StartupPath, "recepciones.csv");

        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);
        }

        public FormRecepciones()
        {
            InitializeComponent();

            dataGridViewRecepciones.Columns.Add("Proveedor", "Proveedor");
            dataGridViewRecepciones.Columns.Add("Remito", "N° Remito");
            dataGridViewRecepciones.Columns.Add("Empleado", "Empleado");
            dataGridViewRecepciones.Columns.Add("Cajas", "Cantidad de cajas");
            dataGridViewRecepciones.Columns.Add("Hora", "Hora de llegada");

            this.BackColor = Color.WhiteSmoke; 
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Font = new Font("Segoe UI", 11); 
            }
            if (this.Controls.OfType<DataGridView>().Any())
            {
                var dgv = this.Controls.OfType<DataGridView>().First();
                dgv.BackgroundColor = Color.White;
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dgv.EnableHeadersVisualStyles = false;
                dgv.GridColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            foreach (Control ctrl in this.Controls.OfType<Button>())
            {
                ctrl.BackColor = Color.SteelBlue; 
                ctrl.ForeColor = Color.White;            

                ctrl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            }

            Label lblTitulo = new Label
            {
                Text = "Recepciones",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.SteelBlue,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((this.Width - 200) / 2, 20) 
            };



            this.Controls.Add(lblTitulo);

        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }



        private void btn_CargarRecepcion_Click_1(object sender, EventArgs e)
        {
            if (txt_proveedor.Text == "" || txt_remito.Text == "" || txt_empleado.Text == "")
            {
                MessageBox.Show("Completá todos los campos.");
                return;
            }

            string nuevaLinea = $"{txt_proveedor.Text};{txt_remito.Text};{txt_empleado.Text};{num_cajas.Value};{dtp_llegada.Value:yyyy-MM-dd HH:mm:ss}";

            File.AppendAllText(rutaCsv, nuevaLinea + Environment.NewLine);

            dataGridViewRecepciones.Rows.Add(txt_proveedor.Text, txt_remito.Text, txt_empleado.Text, num_cajas.Value, dtp_llegada.Value.ToString("HH:mm"));

            txt_proveedor.Text = "";
            txt_remito.Text = "";
            txt_empleado.Text = "";
            num_cajas.Value = 0;
            dtp_llegada.Value = DateTime.Now;
        }

        private void FormRecepciones_Load_1(object sender, EventArgs e)
        {

            Idioma.Agregar(this); ;
            Idioma.Notificar(Idioma.idiomaActual);

            try
            {
                if (!File.Exists(rutaCsv))
                {
                    File.WriteAllText(rutaCsv, "Proveedor;Remito;Empleado;Cajas;HoraLlegada" + Environment.NewLine);
                }

                var lineas = File.ReadAllLines(rutaCsv).Skip(1);

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] valores = linea.Split(';');

                    if (valores.Length >= 5)
                    {
                        dataGridViewRecepciones.Rows.Add(valores[0], valores[1], valores[2], valores[3], valores[4]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el archivo de recepciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}