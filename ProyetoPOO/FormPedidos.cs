using ProyetoPOO;
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
    public partial class FormPedidos : Form, IObserver
    {
        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);
        }
        public FormPedidos()
        {
            InitializeComponent();
            InicializarDataGridView();

            // Fondo y fuente
            this.BackColor = Color.WhiteSmoke;


        }

        private DataTable tablaPedidos;
        private string rutacsv = "pedidos.csv";
        private int filaSeleccionada = -1;

        private void InicializarDataGridView()
        {
            tablaPedidos = new DataTable();
            tablaPedidos.Columns.Add("Proveedor");
            tablaPedidos.Columns.Add("CantidadCajas");
            tablaPedidos.Columns.Add("CodProducto");
            tablaPedidos.Columns.Add("FechaEntrega");
            tablaPedidos.Columns.Add("FechaPedido");
            tablaPedidos.Columns.Add("Costo");

            dataGridViewPedidos.DataSource = tablaPedidos;
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(             
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        private void CargarPedidos()
        {
            tablaPedidos.Rows.Clear();
            string rutaCompleta = Path.Combine(Application.StartupPath, rutacsv);

            try
            {
                if (!File.Exists(rutaCompleta))
                {
                    string encabezado = "Proveedor;Cantidad;CodProducto;FechaEntrega;FechaPedido;Costo";
                    File.WriteAllText(rutaCompleta, encabezado + Environment.NewLine);
                    return;
                }

                var lineas = File.ReadAllLines(rutaCompleta).Skip(1);
                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] valores = linea.Split(';');
                    if (valores.Length >= 6)
                    {
                        tablaPedidos.Rows.Add(valores);
                    }
                }

                dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
    string.Format(Idioma.ObtenerTexto("FormPedidos.MessageBox.ErrorCargarPedidos"), ex.Message),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.ErrorCargarPedidosTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Error
);

            }
        }

        private void GuardarPedidosEnCSV()
        {
            string rutaCompleta = Path.Combine(Application.StartupPath, rutacsv);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Proveedor;Cantidad;CodProducto;FechaEntrega;FechaPedido;Costo");

            foreach (DataRow fila in tablaPedidos.Rows)
            {
                sb.AppendLine(string.Join(";", fila.ItemArray));
            }

            File.WriteAllText(rutaCompleta, sb.ToString());
        }

        private void buttonGenerarpedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_proveedor.Text) ||
                string.IsNullOrWhiteSpace(txt_cantidad.Text) ||
                string.IsNullOrWhiteSpace(txt_codproducto.Text) ||
                string.IsNullOrWhiteSpace(txt_costo.Text))
            {
                MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.CamposIncompletos"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.CamposIncompletosTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning
);

                return;
            }

            tablaPedidos.Rows.Add(
                txt_proveedor.Text,
                txt_cantidad.Text,
                txt_codproducto.Text,
                dateTimePickerEntrega.Value.ToShortDateString(),
                dateTimePickerPedido.Value.ToShortDateString(),
                txt_costo.Text
            );

            GuardarPedidosEnCSV();
            MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.PedidoGuardado"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.PedidoGuardadoTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Information
);
            LimpiarCampos();
        }

            private void LimpiarCampos()
        {
            txt_proveedor.Clear();
            txt_cantidad.Clear();
            txt_codproducto.Clear();
            txt_costo.Clear();
            dateTimePickerEntrega.Value = DateTime.Today;
            dateTimePickerPedido.Value = DateTime.Today;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            CargarPedidos();
            Idioma.Agregar(this); ;
            Idioma.Notificar(Idioma.idiomaActual);

            this.BackColor = Color.WhiteSmoke; 
            if (this.Controls.OfType<DataGridView>().Any())
            {
                var dgv = this.Controls.OfType<DataGridView>().First();
                dgv.BackgroundColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dgv.EnableHeadersVisualStyles = false;
                dgv.GridColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }

          

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada == -1)
            {
                MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.SeleccionaFilaModificar"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.SeleccionaFilaModificarTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning
);

                return;
            }

            if (string.IsNullOrWhiteSpace(txt_proveedor.Text) ||
                string.IsNullOrWhiteSpace(txt_cantidad.Text) ||
                string.IsNullOrWhiteSpace(txt_codproducto.Text) ||
                string.IsNullOrWhiteSpace(txt_costo.Text))
            {
                MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.CamposModificar"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.CamposModificarTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning
);

                return;
            }

            DataRow fila = tablaPedidos.Rows[filaSeleccionada];
            fila["Proveedor"] = txt_proveedor.Text;
            fila["cantidadCajas"] = txt_cantidad.Text;
            fila["CodProducto"] = txt_codproducto.Text;
            fila["FechaEntrega"] = dateTimePickerEntrega.Value.ToShortDateString();
            fila["FechaPedido"] = dateTimePickerPedido.Value.ToShortDateString();
            fila["Costo"] = txt_costo.Text;

            GuardarPedidosEnCSV();
            MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.PedidoModificado"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.PedidoModificadoTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Information
);
            LimpiarCampos();
            filaSeleccionada = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada == -1)
            {
                MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.SeleccionaFilaEliminar"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.SeleccionaFilaEliminarTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning
);

                return;
            }

            var confirm = MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.ConfirmarEliminacion"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.ConfirmarEliminacionTitulo"),
    MessageBoxButtons.YesNo
);

            if (confirm == DialogResult.Yes)
            {
                tablaPedidos.Rows.RemoveAt(filaSeleccionada);
                GuardarPedidosEnCSV();
                MessageBox.Show(
    Idioma.ObtenerTexto("FormPedidos.MessageBox.PedidoEliminado"),
    Idioma.ObtenerTexto("FormPedidos.MessageBox.PedidoEliminadoTitulo"),
    MessageBoxButtons.OK,
    MessageBoxIcon.Information
);
                LimpiarCampos();
                filaSeleccionada = -1;
            }
        }
        //f
        private void dataGridViewPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filaSeleccionada = e.RowIndex;
                DataGridViewRow fila = dataGridViewPedidos.Rows[filaSeleccionada];

                txt_proveedor.Text = fila.Cells["Proveedor"].Value.ToString();
                txt_cantidad.Text = fila.Cells["cantidadCajas"].Value.ToString();
                txt_codproducto.Text = fila.Cells["CodProducto"].Value.ToString();
                txt_costo.Text = fila.Cells["Costo"].Value.ToString();

                if (DateTime.TryParse(fila.Cells["FechaEntrega"].Value.ToString(), out DateTime fechaEntrega))
                {
                    dateTimePickerEntrega.Value = fechaEntrega;
                }
                if (DateTime.TryParse(fila.Cells["FechaPedido"].Value.ToString(), out DateTime fechaPedido))
                {
                    dateTimePickerPedido.Value = fechaPedido;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

