using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();




        }

        private void buttonGenerarpedido_Click(object sender, EventArgs e)
        {
            string RutaCSV = "pedidos.csv";

            if (string.IsNullOrWhiteSpace(txt_proveedor.Text) ||
                string.IsNullOrWhiteSpace(txt_cantidad.Text) ||
                string.IsNullOrWhiteSpace(txt_codproducto.Text) ||
                string.IsNullOrWhiteSpace(txt_costo.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos.");
                return;
            }

            string linea = $"{txt_proveedor.Text}," + $"{txt_cantidad}," + $"{txt_codproducto}," +
                           $"{dateTimePickerEntrega.Value.ToShortDateString()}" + $"{dateTimePickerPedido.Value.ToShortDateString()}" +
                           $"{txt_costo.Text}";

            try
            {
                using (StreamWriter sw = new StreamWriter("pedidos.csv", true))
                {
                    sw.WriteLine(linea);
                }

                MessageBox.Show("Pedido guardado correctamente");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el pedido: " + ex.Message);


            }
        }

            private void LimpiarCampos()
        {
            txt_proveedor.Text = " ";
            txt_cantidad.Text = " ";
            txt_codproducto.Text = " ";
            txt_costo.Text = " ";
            dateTimePickerEntrega.Value = DateTime.Today;
            dateTimePickerPedido.Value = DateTime.Today;
        }




        }
    }

