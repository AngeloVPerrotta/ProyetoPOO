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
    public partial class FormRecepciones : Form
    {

        private string rutaCsv = Path.Combine(Application.StartupPath, "recepciones.csv");

        public FormRecepciones()
        {
            InitializeComponent();

            dataGridViewRecepciones.Columns.Add("Proveedor", "Proveedor");
            dataGridViewRecepciones.Columns.Add("Remito", "N° Remito");
            dataGridViewRecepciones.Columns.Add("Empleado", "Empleado");
            dataGridViewRecepciones.Columns.Add("Cajas", "Cantidad de cajas");
            dataGridViewRecepciones.Columns.Add("Hora", "Hora de llegada");
        }

        private void btn_CargarRecepcion_Click_1(object sender, EventArgs e)
        {
            if (txt_proveedor.Text == "" || txt_remito.Text == "" || txt_empleado.Text == "")
            {
                MessageBox.Show("Completá todos los campos.");
                return;
            }

            // Aquí creas la línea CSV para el nuevo registro
            string nuevaLinea = $"{txt_proveedor.Text};{txt_remito.Text};{txt_empleado.Text};{num_cajas.Value};{dtp_llegada.Value:yyyy-MM-dd HH:mm:ss}";

            // Agrega la nueva línea al archivo CSV local
            File.AppendAllText(rutaCsv, nuevaLinea + Environment.NewLine);

            // Agrega la nueva fila al DataGridView
            dataGridViewRecepciones.Rows.Add(txt_proveedor.Text, txt_remito.Text, txt_empleado.Text, num_cajas.Value, dtp_llegada.Value.ToString("HH:mm"));

            // Limpia los campos para el siguiente registro
            txt_proveedor.Text = "";
            txt_remito.Text = "";
            txt_empleado.Text = "";
            num_cajas.Value = 0;
            dtp_llegada.Value = DateTime.Now;
        }

        private void FormRecepciones_Load_1(object sender, EventArgs e)
        {



            try
            {
                // Verifica si el archivo existe. Si no, lo crea con la cabecera.
                if (!File.Exists(rutaCsv))
                {
                    File.WriteAllText(rutaCsv, "Proveedor;Remito;Empleado;Cajas;HoraLlegada" + Environment.NewLine);
                }

                // Lee todas las líneas del archivo CSV local
                var lineas = File.ReadAllLines(rutaCsv).Skip(1);

                foreach (string linea in lineas)
                {
                    // Si el archivo tiene líneas vacías, las ignora
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] valores = linea.Split(';');
                    // Aquí debes asegurarte de que el método Recepcion.FromCsv use ';' como separador
                    // O bien, adaptar este código para que use la clase Recepcion

                    // Ejemplo de cómo llenar la tabla directamente:
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