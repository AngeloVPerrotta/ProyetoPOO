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
    public partial class FormProveedores : Form
    {
        private string rutacsv = "Proveedores.csv";
        private DataTable tablaProv;
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {

        }
        
        private void dataGridViewProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void inicializartabla() 
        {
            tablaProv = new DataTable();
            tablaProv.Columns.Add("Nombre");
            tablaProv.Columns.Add("Rubro");
            tablaProv.Columns.Add("Contacto");
            dataGridViewProv.DataSource = tablaProv;
        }
        private void cargarDesdeCSV() 
        {
            if (File.Exists(rutacsv)) 
            {
                var lineas = File.ReadAllLines(rutacsv);
                foreach (var line in lineas) 
                {
                    var datos = line.Split(';');
                    if (datos.Length == 3) 
                    {
                        tablaProv.Rows.Add(datos);
                    }
                }
            }
        }
    }
}
