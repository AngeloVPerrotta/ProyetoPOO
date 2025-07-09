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
        }
        private void escriba(string texto) 
        {
            tablaProv.Rows.Add(texto);
        }
        private void cargarDesdeCSV() 
        {
            try
            {                                
                using (StreamReader sr = new StreamReader("Proveedores.csv"))
                {
                    string primeralinea = sr.ReadLine();
                    if (primeralinea == null)
                    {
                        string[] cabeceras = primeralinea.Split(';');

                        foreach (string cabecera in cabeceras)
                        {
                            dataGridViewProv.Columns.Add(cabecera, cabecera);
                        }
                        while (sr.EndOfStream)
                        {
                            string linea = sr.ReadLine();
                            string[] valores = linea.Split(';');
                            dataGridViewProv.Rows.Add(valores);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al cargar el archivo CSV: " + ex.Message);
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
                filaselecionada = e.RowIndex;
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
    }
}
