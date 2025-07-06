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
        }               
        private void inicializartabla() 
        {
            tablaProv = new DataTable();
            tablaProv.Columns.Add("Nombre");
            tablaProv.Columns.Add("Rubro");
            tablaProv.Columns.Add("Contacto");
            dataGridViewProv.DataSource = tablaProv;
        }
        private void escriba(string texto) 
        {
            tablaProv.Rows.Add(texto);
        }
        private void cargarDesdeCSV() 
        {
            FileStream fs = new FileStream("Proveedores.csv",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);            
            string linea = "";
            string legajo = "";
            string[] vl = new string[0];
            linea = sr.ReadLine();
            linea = sr.ReadLine();
            while (linea != null) 
            {
                vl = linea.Split(';');
                string texto = vl[0] + vl[1] + vl[2] + vl[3];
                legajo = vl[0];
                escriba(texto);
                linea = sr.ReadLine();
                if (linea != null) 
                {
                    vl = linea.Split(';');
                }
                sr.Close();
                fs.Close();
            }
            //if (File.Exists(rutacsv)) 
            //{
            //    var lineas = File.ReadAllLines(rutacsv);
            //    foreach (var line in lineas) 
            //    {
            //        var datos = line.Split(';');
            //        if (datos.Length == 3) 
            //        {
            //            tablaProv.Rows.Add(datos);
            //        }
            //    }
            //}
        }

        private void buttonAgregarProv_Click(object sender, EventArgs e)
        {
            if (okay())
            {
                string[] vectorlinea = new string[3];
                vectorlinea[0] = textBoxProv.Text;
                vectorlinea[1] = textBoxRubro.Text;
                vectorlinea[2] = textBoxContacto.Text;
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

        private void dataGridViewProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var confirm = MessageBox.Show("¿Deseas eliminar esta fila?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    dataGridViewProv.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
