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
        public FormRecepciones()
        {
            InitializeComponent();
        }

        private void FormRecepciones_Load(object sender, EventArgs e)
        {
            dataGridViewRecepciones.Columns.Add("Proveedor", "Proveedor");
            dataGridViewRecepciones.Columns.Add("Remito", "N° Remito");
            dataGridViewRecepciones.Columns.Add("Empleado", "Empleado");
            dataGridViewRecepciones.Columns.Add("Cajas", "Cantidad de cajas");
            dataGridViewRecepciones.Columns.Add("Hora", "Hora de llegada");

            string ruta = "recepciones.csv";
            if (!File.Exists(ruta))
            {
                File.WriteAllText(ruta, "Proveedor,Remito,Empleado,Cajas,Hora de llegada" + Environment.NewLine);
            }

            var lineas = File.ReadAllLines(ruta).Skip(1);
            foreach (string linea in lineas)
            {
                Recepcion r = Recepcion.FromCsv(linea);
                dataGridViewRecepciones.Rows.Add(r.Proveedor, r.Remito, r.Empleado, r.Cajas, r.HoraLlegada);
            }
        }

        private void btn_CargarRecepcion_Click(object sender, EventArgs e)
        {
            if (txt_proveedor.Text == "" || txt_remito.Text == "" || txt_empleado.Text == "")
            {
                MessageBox.Show("Completá todos los campos.");
                return;
            }

            Recepcion nueva = new Recepcion
            {
                Proveedor = txt_proveedor.Text,
                Remito = txt_remito.Text,
                Empleado = txt_empleado.Text,
                Cajas = (int)num_cajas.Value,
                HoraLlegada = dtp_llegada.Value
            };

            File.AppendAllText("recepciones.csv", nueva.ToCsv() + Environment.NewLine);

            dataGridViewRecepciones.Rows.Add(nueva.Proveedor, nueva.Remito, nueva.Empleado, nueva.Cajas, nueva.HoraLlegada);

            txt_proveedor.Text = "";
            txt_remito.Text = "";
            txt_empleado.Text = "";
            num_cajas.Value = 0;
            dtp_llegada.Value = DateTime.Now;


        }
    }
}
