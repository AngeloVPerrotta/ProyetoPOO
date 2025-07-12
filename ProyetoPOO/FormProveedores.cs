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
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices.ComTypes;

namespace ProyetoPOO
{
    public partial class FormProveedores : Form
    {
        private string rutacsv = "Proveedores.csv";
        private DataTable tablaProv;
        private bool okay() 
        {
            bool ok = false;
            if (textBoxProv.Text != "" && textBoxRubro.Text != "" && textBoxContacto.Text != "") 
            {
                ok = true;
            }
            return ok;
        }
        public FormProveedores()
        {
            InitializeComponent();
        }
        private void FormProveedores_Load(object sender, EventArgs e)
        {
            inicializartabla();
            cargarDesdeCSV();

            this.BackColor = Color.WhiteSmoke;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.Font = new Font("Segoe UI", 11);
            }

            // Aplica color a los botones
            foreach (Control ctrl in this.Controls.OfType<Button>())
            {
                ctrl.BackColor = Color.SteelBlue;
                ctrl.ForeColor = Color.White;
                ctrl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            }

            // Aplica color a los encabezados del DataGridView
            dataGridViewProv.EnableHeadersVisualStyles = false;
            dataGridViewProv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dataGridViewProv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewProv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void inicializartabla() 
        {
            tablaProv = new DataTable();
            tablaProv.Columns.Add("ID");
            tablaProv.Columns.Add("Nombre");
            tablaProv.Columns.Add("Rubro");
            tablaProv.Columns.Add("Contacto");
            dataGridViewProv.DataSource = tablaProv;
            dataGridViewProv.Columns["ID"].Width = 35;

            dataGridViewProv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // <-- Esta línea

            if (this.Controls.OfType<DataGridView>().Any())
            {
                var dgv = this.Controls.OfType<DataGridView>().First();
                dgv.BackgroundColor = Color.White;
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
 
                dgv.GridColor = Color.LightGray;
            }

        }
        private void escriba(string texto) 
        {
            tablaProv.Rows.Add(texto);
        }
        private void cargarDesdeCSV() 
        {
            // Usamos Path.Combine para una ruta más robusta
            string rutaCompleta = Path.Combine(Application.StartupPath, rutacsv);

            try
            {
                // Verifica si el archivo existe
                if (!File.Exists(rutaCompleta))
                {
                    MessageBox.Show("El archivo 'Proveedores.csv' no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamReader sr = new StreamReader(rutaCompleta))
                {
                    string primeralinea = sr.ReadLine();

                    // La condición correcta es "si la primera línea no es nula"
                    if (primeralinea != null)
                    {
                        // No es necesario añadir las columnas aquí, ya se hace en inicializartabla()
                        // Solo nos aseguramos de que haya datos para procesar
                    }

                    string linea;
                    // Bucle correcto para leer cada línea del archivo hasta el final
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;

                        string[] valores = linea.Split(';');

                        // Asegúrate de que la fila tenga el número correcto de valores
                        if (valores.Length >= 4)
                        {
                            // Añadimos la fila a la DataTable, no al DataGridView directamente
                            tablaProv.Rows.Add(valores);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAgregarProv_Click(object sender, EventArgs e)
        {
            if (okay())
            {
                string[] vectorlinea = new string[4];
                vectorlinea[1] = textBoxProv.Text;
                vectorlinea[2] = textBoxRubro.Text;
                vectorlinea[3] = textBoxContacto.Text;
                tablaProv.Rows.Add(vectorlinea);
                limpiarCampos();
            }
            else 
            {
                MessageBox.Show("Complete todos los campos");
            }
        }
        private void limpiarCampos()
        {
            textBoxProv.Text = "";
            textBoxRubro.Text = "";
            textBoxContacto.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private int filaselecionada = -1;
        private void dataGridViewProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Almacena el índice de la fila seleccionada en la variable de clase
                filaselecionada = e.RowIndex;

                // Obtiene la fila completa seleccionada
                DataGridViewRow fila = dataGridViewProv.Rows[e.RowIndex];

                // Carga los valores de la fila en los cuadros de texto.
                // Asegúrate de que las columnas están en el orden correcto
                // Columnas en tu DataTable: ID, Nombre, Rubro, Contacto
                textBoxProv.Text = fila.Cells["Nombre"].Value.ToString();
                textBoxRubro.Text = fila.Cells["Rubro"].Value.ToString();
                textBoxContacto.Text = fila.Cells["Contacto"].Value.ToString();
            }
        }

        private void buttonElimProv_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Deseas eliminar esta fila?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                dataGridViewProv.Rows.RemoveAt(filaselecionada);
                filaselecionada = -1;
            }
            else 
            {
                MessageBox.Show("Selecione fila a eliminar");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filaselecionada == -1)
            {
                MessageBox.Show("Seleccione una fila para modificar.");
                return;
            }

            // Usa tu método existente para verificar que los campos estén completos
            if (!okay())
            {
                MessageBox.Show("Complete todos los campos para modificar el proveedor.");
                return;
            }

            // Actualiza los datos en la fila seleccionada del DataTable
            tablaProv.Rows[filaselecionada]["Nombre"] = textBoxProv.Text;
            tablaProv.Rows[filaselecionada]["Rubro"] = textBoxRubro.Text;
            tablaProv.Rows[filaselecionada]["Contacto"] = textBoxContacto.Text;

            // Llama al método para guardar todos los datos en el archivo
            guardarEnCSV();

            // Notifica al usuario, limpia los campos y resetea el índice
            MessageBox.Show("Proveedor modificado correctamente.");
            limpiarCampos();
            filaselecionada = -1;
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        private void guardarEnCSV()
        {
            try
            {
                // Usa la ruta de tu archivo
                string rutaCompleta = Path.Combine(Application.StartupPath, rutacsv);

                // StringBuilder es más eficiente para construir cadenas grandes
                StringBuilder sb = new StringBuilder();

                // Agrega el encabezado al archivo
                sb.AppendLine("ID;Nombre;Rubro;Contacto");

                // Recorre cada fila del DataTable y la convierte a formato CSV
                foreach (DataRow fila in tablaProv.Rows)
                {
                    // El ID es la primera columna
                    string id = fila["ID"].ToString();
                    string nombre = fila["Nombre"].ToString();
                    string rubro = fila["Rubro"].ToString();
                    string contacto = fila["Contacto"].ToString();

                    sb.AppendLine($"{id};{nombre};{rubro};{contacto}");
                }

                // Escribe todo el contenido de una vez en el archivo
                File.WriteAllText(rutaCompleta, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en el archivo CSV: " + ex.Message);
            }
        }
    }
}
