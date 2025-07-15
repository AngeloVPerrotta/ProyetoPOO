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
    public partial class FormProveedores : Form, IObserver
    {
        private string rutacsv = "Proveedores.csv";
        private DataTable tablaProv;

        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);
        }
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
            Idioma.Agregar(this); ;
            Idioma.Notificar(Idioma.idiomaActual);

            this.BackColor = Color.WhiteSmoke;

       
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
            string rutaCompleta = Path.Combine(Application.StartupPath, rutacsv);

            try
            {
                if (!File.Exists(rutaCompleta))
                {
                    MessageBox.Show(
                        Idioma.ObtenerTexto("FormProveedores.MessageBox.NoArchivoCSV"),
                        Idioma.ObtenerTexto("FormProveedores.MessageBox.NoArchivoCSV.Titulo"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                using (StreamReader sr = new StreamReader(rutaCompleta))
                {
                    string primeralinea = sr.ReadLine();

                    

                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;

                        string[] valores = linea.Split(';');

                        if (valores.Length >= 4)
                        {
                            tablaProv.Rows.Add(valores);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Idioma.ObtenerTexto("FormProveedores.MessageBox.ErrorCargarCSV"), ex.Message),
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.ErrorCargarCSV.Titulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonAgregarProv_Click(object sender, EventArgs e)
        {
            if (okay())
            {
                int nuevoID = ObtenerSiguienteID();

                tablaProv.Rows.Add(
                    nuevoID.ToString(),
                    textBoxProv.Text,
                    textBoxRubro.Text,
                    textBoxContacto.Text
                );

                guardarEnCSV();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.CompletarCampos"),
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.CompletarCampos.Titulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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
        }

        private void buttonElimProv_Click(object sender, EventArgs e)
        {
            if (filaselecionada == -1)
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.SeleccionarFilaEliminar"),
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.SeleccionarFilaEliminar.Titulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var confirm = MessageBox.Show(
                Idioma.ObtenerTexto("FormProveedores.MessageBox.ConfirmarEliminacion"),
                Idioma.ObtenerTexto("FormProveedores.MessageBox.ConfirmarEliminacion.Titulo"),
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                tablaProv.Rows[filaselecionada].Delete();
                guardarEnCSV();
                filaselecionada = -1;
                limpiarCampos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filaselecionada == -1)
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.SeleccionarFilaModificar"),
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.SeleccionarFilaModificar.Titulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!okay())
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.CompletarCamposModificar"),
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.CompletarCamposModificar.Titulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            tablaProv.Rows[filaselecionada]["Nombre"] = textBoxProv.Text;
            tablaProv.Rows[filaselecionada]["Rubro"] = textBoxRubro.Text;
            tablaProv.Rows[filaselecionada]["Contacto"] = textBoxContacto.Text;

            guardarEnCSV();

            MessageBox.Show(
                Idioma.ObtenerTexto("FormProveedores.MessageBox.ProveedorModificado"),
                Idioma.ObtenerTexto("FormProveedores.MessageBox.ProveedorModificado.Titulo"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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
                string rutaCompleta = Path.Combine(Application.StartupPath, rutacsv);

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("ID;Nombre;Rubro;Contacto");

                foreach (DataRow fila in tablaProv.Rows)
                {
                    string id = fila["ID"].ToString();
                    string nombre = fila["Nombre"].ToString();
                    string rubro = fila["Rubro"].ToString();
                    string contacto = fila["Contacto"].ToString();

                    sb.AppendLine($"{id};{nombre};{rubro};{contacto}");
                }

                File.WriteAllText(rutaCompleta, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Idioma.ObtenerTexto("FormProveedores.MessageBox.ErrorGuardarCSV"), ex.Message),
                    Idioma.ObtenerTexto("FormProveedores.MessageBox.ErrorGuardarCSV.Titulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private int ObtenerSiguienteID()
        {
            if (tablaProv.Rows.Count == 0)
                return 1;

            int maxId = tablaProv.AsEnumerable()
                .Where(r => !string.IsNullOrEmpty(r["ID"].ToString()))
                .Max(r => int.Parse(r["ID"].ToString()));

            return maxId + 1;
        }

        private void dataGridViewProv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filaselecionada = e.RowIndex;

                DataGridViewRow fila = dataGridViewProv.Rows[e.RowIndex];

                textBoxProv.Text = fila.Cells["Nombre"].Value.ToString();
                textBoxRubro.Text = fila.Cells["Rubro"].Value.ToString();
                textBoxContacto.Text = fila.Cells["Contacto"].Value.ToString();
            }

        }
    }
}
