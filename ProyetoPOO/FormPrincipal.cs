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
    public partial class FormPrincipal : Form, IObserver
    {
        private string rutaVentas = Path.Combine(Application.StartupPath, "ventas.txt");
        string rutaStock = Path.Combine(Application.StartupPath, "stock.txt");

        private string rolUsuario;

        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);

        }
        public string RolUsuario
        {
            get => rolUsuario;
            set
            {
                rolUsuario = value;
                AplicarPermisos(rolUsuario);

            }
        }

        private class MyMenuRenderer : ToolStripProfessionalRenderer
        {
            public MyMenuRenderer() : base(new MyColorTable()) { }
        }

        private class MyColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.DodgerBlue; } // Color de fondo cuando se selecciona el ítem
            }

            public override Color MenuItemBorder
            {
                get { return Color.Transparent; } // Color del borde cuando se selecciona el ítem
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DodgerBlue; }
            }

            

        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        public FormPrincipal()
        {
            InitializeComponent();
            StockManager.StockActualizado += (cantidad) => ActualizarLabelStock(cantidad, true);

            this.IsMdiContainer = true;
            this.BackColor = Color.LightSteelBlue;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.LightSteelBlue;
                }
            }

            if (!string.IsNullOrEmpty(RolUsuario))
            {
                AplicarPermisos(RolUsuario);
            }

            this.FormClosing += FormPrincipal_FormClosing;
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        public string RolActual { get; set; }
        
        public void AplicarPermisos(string rol)
        {

          

            proveedoresToolStripMenuItem.Visible = false;
            pedidosToolStripMenuItem.Visible = false;
            recepcionesToolStripMenuItem.Visible = false;
            recursosHumanosToolStripMenuItem.Visible = false;


            switch (rol.ToLower())
            {
                case "administrador":
                    
                   
                    proveedoresToolStripMenuItem.Visible = true;
                    pedidosToolStripMenuItem.Visible = true;
                    recepcionesToolStripMenuItem.Visible = true;
                    recursosHumanosToolStripMenuItem.Visible = true;
                    break;

                case "rrhh":
                    
                    recursosHumanosToolStripMenuItem.Visible = true;
                    break;

                case "usuario":
                case "compras":

                    pedidosToolStripMenuItem.Visible = true;
                    recepcionesToolStripMenuItem.Visible = true;
                    break;

                case "visitante":

                    proveedoresToolStripMenuItem.Visible = true;
                    pedidosToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 

            FormLogin login = new FormLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                RolUsuario = login.Rol;
                AplicarPermisos(RolUsuario);
                this.Show(); 
            }
            else
            {
                
                this.Close();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private const int StockMinimo = 10;
        private void ActualizarLabelStock(int cantidad, bool permitirPedido = true)
        {
            label10.Text = $"Cajas en stock: {cantidad}";

            if (cantidad <= StockMinimo)
            {
                label10.ForeColor = Color.Red;
                var resultado = MessageBox.Show(
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.StockBajo"),
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.StockBajo.Titulo"),
            permitirPedido ? MessageBoxButtons.YesNo : MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

                if (permitirPedido && resultado == DialogResult.Yes)
                {
                    FormPedidos pedidos = new FormPedidos();
                    pedidos.ShowDialog();
                }
            }
            else
            {
                label10.ForeColor = Color.Black;
            }
        }

            protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        ActualizarLabelStock(StockManager.CajasTotales, false); // No abrir el form de pedidos automáticamente
    }
        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormPedidos pedidos = new FormPedidos();
            pedidos.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormProveedores proveedores = new FormProveedores();
            proveedores.ShowDialog();
        }

       
        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormRRHH RRHH = new FormRRHH();
            RRHH.ShowDialog();
        }

        
        private void mensajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMensajes mensajes = new FormMensajes();
            mensajes.RolActual = this.RolUsuario;
            mensajes.ShowDialog();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarVentasEnGrid();
            Idioma.Agregar(this); ;
            Idioma.Notificar(Idioma.idiomaActual);

            label3.Text = $"Rol actual: {RolUsuario}";


            if (File.Exists(rutaStock))
            {
                int stockGuardado;
                var texto = File.ReadAllText(rutaStock).Trim();
                if (int.TryParse(texto, out stockGuardado))
                {
                    StockManager.InicializarStock(stockGuardado);
                }
                else
                {
                    MessageBox.Show(
                Idioma.ObtenerTexto("FormPrincipal.MessageBox.ErrorLeerStock"),
                Idioma.ObtenerTexto("FormPrincipal.MessageBox.ErrorLeerStock.Titulo"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                    StockManager.InicializarStock(0);
                }
            }
            else
            {
                StockManager.InicializarStock(0);
            }

        }
        

        private void recepcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRecepciones recepciones = new FormRecepciones();
            recepciones.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    

        private void recursosHumanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRRHH rrhh = new FormRRHH();
            rrhh.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIdioma idioma = new FormIdioma();
            idioma.ShowDialog();
        }

        private void RegistrarVenta(int cantidadVendida)
        {

            MessageBox.Show(
        string.Format(Idioma.ObtenerTexto("FormPrincipal.MessageBox.StockAntesVenta"), StockManager.CajasTotales),
        Idioma.ObtenerTexto("FormPrincipal.MessageBox.StockAntesVenta.Titulo"),
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
            if (StockManager.DescontarCajas(cantidadVendida))
            {
                MessageBox.Show(
            string.Format(Idioma.ObtenerTexto("FormPrincipal.MessageBox.VentaRegistrada"), StockManager.CajasTotales),
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.VentaRegistrada.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                ActualizarLabelStock(StockManager.CajasTotales); 
            }
            else
            {
                MessageBox.Show(
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.SinStockVenta"),
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.SinStockVenta.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string cliente = txtCliente.Text.Trim();
            string producto = txtProducto.Text.Trim();
            int cantidad;
            decimal precio;

            if (string.IsNullOrEmpty(cliente) || string.IsNullOrEmpty(producto) ||
                !int.TryParse(txtCantidadVendida.Text, out cantidad) || cantidad <= 0 ||
                !decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                MessageBox.Show(
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.CompletarCamposVenta"),
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.CompletarCamposVenta.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
                return;
            }

            RegistrarVenta(cantidad);

            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string linea = $"{cliente};{producto};{cantidad};{precio};{fecha}";
            File.AppendAllText(rutaVentas, linea + Environment.NewLine);

            txtCliente.Clear();
            txtProducto.Clear();
            txtCantidadVendida.Clear();
            txtPrecio.Clear();

            ActualizarLabelStock(StockManager.CajasTotales);
            CargarVentasEnGrid();

         
        }

        private void CargarVentasEnGrid()
        {
            dataGridViewVentas.Rows.Clear();
            dataGridViewVentas.Columns.Clear();

 
            dataGridViewVentas.Columns.Add("Cliente", "Cliente");
            dataGridViewVentas.Columns.Add("Producto", "Producto");
            dataGridViewVentas.Columns.Add("Cantidad", "Cantidad");
            dataGridViewVentas.Columns.Add("Precio", "Precio");
            dataGridViewVentas.Columns.Add("Fecha", "Fecha");

            if (!File.Exists(rutaVentas))
            {
                MessageBox.Show(
            string.Format(Idioma.ObtenerTexto("FormPrincipal.MessageBox.NoArchivoVentas"), rutaVentas),
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.NoArchivoVentas.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
                return;
            }

            string[] lineas = File.ReadAllLines(rutaVentas);

            if (lineas.Length <= 1)
            {
                MessageBox.Show(
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.ArchivoVentasSinDatos"),
            Idioma.ObtenerTexto("FormPrincipal.MessageBox.ArchivoVentasSinDatos.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                return;
            }

            foreach (var linea in lineas.Skip(1)) 
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;

                var partes = linea.Split(';');

                if (partes.Length == 5)
                {
                    dataGridViewVentas.Rows.Add(
                        partes[0].Trim(),
                        partes[1].Trim(),
                        partes[2].Trim(),
                        partes[3].Trim(),
                        partes[4].Trim()
                    );
                }
                else
                {
                    MessageBox.Show(
                string.Format(Idioma.ObtenerTexto("FormPrincipal.MessageBox.LineaFormatoIncorrecto"), linea),
                Idioma.ObtenerTexto("FormPrincipal.MessageBox.LineaFormatoIncorrecto.Titulo"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                }
            }
            EstilizarDataGridView(dataGridViewVentas);

        }
        private void EstilizarDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false; // Permite personalizar los encabezados
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajusta ancho automáticamente
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;       // Ajusta alto automáticamente
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;        // Selección de fila completa
            dgv.MultiSelect = false;                                           // Solo una fila seleccionada a la vez
            dgv.ReadOnly = true;                                               // Solo lectura (opcional)
            dgv.RowHeadersVisible = false;                                     // Oculta el encabezado de las filas

            // Estilo del encabezado
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Estilo de las celdas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Alternancia de color en filas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
         
            File.WriteAllText("stock.txt", StockManager.CajasTotales.ToString());
        
    }
    }
}
