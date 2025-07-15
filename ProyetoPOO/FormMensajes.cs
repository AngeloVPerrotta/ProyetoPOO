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
    public partial class FormMensajes : Form, IObserver
    {
        public string RolActual { get; set; }

        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        public FormMensajes()
        {
            InitializeComponent();
            string rutaUsuarios = "usuario_encriptado.csv";
            HashSet<string> roles = new HashSet<string>();

            if (File.Exists(rutaUsuarios))
            {
                foreach (var linea in File.ReadAllLines(rutaUsuarios))
                {
                    var partes = linea.Split(';');
                    if (partes.Length == 3)
                    {
                        roles.Add(partes[2]); // el rol
                    }
                }

                cmbDestinatarioRol.Items.Clear();
                foreach (var rol in roles)
                {
                    cmbDestinatarioRol.Items.Add(rol);
                }
            }
        }

        private void CargarMensajesRecibidos()
        {
            string rutaMensajes = "mensajes.txt";

            dgvMensajes.Columns.Clear();
            dgvMensajes.Rows.Clear();

            dgvMensajes.Columns.Add("De", "Remitente");
            dgvMensajes.Columns.Add("Fecha", "Fecha");
            dgvMensajes.Columns.Add("Mensaje", "Mensaje");

            if (!File.Exists(rutaMensajes))
                return;

            var mensajes = File.ReadAllLines(rutaMensajes)
                .Select(l => l.Split(';'))
                .Where(p => p.Length == 4 && p[0].Equals(RolActual, StringComparison.OrdinalIgnoreCase))
                .Select(p => new
                {
                    De = p[1],
                    Fecha = p[2],
                    Mensaje = p[3]
                });

            foreach (var m in mensajes)
            {
                dgvMensajes.Rows.Add(m.De, m.Fecha, m.Mensaje);
            }
        }


        public void FormMensajes_Load(object sender, EventArgs e)
        {

            Idioma.Agregar(this); ;
            Idioma.Notificar(Idioma.idiomaActual);

            CargarMensajesRecibidos();

            dgvMensajes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvMensajes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMensajes.BackgroundColor = Color.White;
            dgvMensajes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvMensajes.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvMensajes.EnableHeadersVisualStyles = false;
            dgvMensajes.GridColor = Color.LightGray;
            dgvMensajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMensajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lblRemitente.Text = $"ROL ACTUAL: {RolActual}";
            string rolDestino = cmbDestinatarioRol.Text.Trim();
            string contenido = txtMensaje.Text.Trim();

            string rutaUsuarios = "usuario_encriptado.csv";
            HashSet<string> roles = new HashSet<string>();

            if (File.Exists(rutaUsuarios))
            {
                foreach (var linea in File.ReadAllLines(rutaUsuarios))
                {
                    var partes = linea.Split(',');
                    if (partes.Length == 3)
                    {
                        string rol = partes[2].Trim();
                        if (!rol.Equals(RolActual, StringComparison.OrdinalIgnoreCase))
                        {
                            roles.Add(rol);  // solo otros roles
                        }
                    }
                }

                cmbDestinatarioRol.Items.Clear();
                foreach (var rol in roles)
                {
                    cmbDestinatarioRol.Items.Add(rol);
                }

                if (cmbDestinatarioRol.Items.Count > 0)
                    cmbDestinatarioRol.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.NoArchivoUsuarios"),
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.NoArchivoUsuariosTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        public void VerMensajes()
        {
            string rutaMensajes = "mensajes.txt";

            if (!File.Exists(rutaMensajes))
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.NoHayMensajes"),
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.NoHayMensajesTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var mensajes = File.ReadAllLines(rutaMensajes)
                .Where(l => l.StartsWith(RolActual + ";"))  // filtro por rol destino
                .Select(l => l.Split(';'))
                .Select(p => $"De: {p[1]} - Fecha: {p[2]}\n{p[3]}")
                .ToList();

            if (mensajes.Count == 0)
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.NoMensajesNuevos"),
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.NoMensajesNuevosTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                string texto = string.Join("\n\n------------------------\n\n", mensajes);
                MessageBox.Show(
                    texto,
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.MensajesRecibidosTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rolDestino = cmbDestinatarioRol.Text.Trim();
            string contenido = txtMensaje.Text.Trim();

            if (string.IsNullOrEmpty(rolDestino) || string.IsNullOrEmpty(contenido))
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.CamposIncompletos"),
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.CamposIncompletosTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (rolDestino == RolActual)
            {
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.MensajePropioRol"),
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.MensajePropioRolTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string rutaMensajes = "mensajes.txt";
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string linea = $"{rolDestino};{RolActual};{fecha};{contenido}";

            try
            {
                File.AppendAllText(rutaMensajes, linea + Environment.NewLine);
                MessageBox.Show(
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.MensajeEnviado"),
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.MensajeEnviadoTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                txtMensaje.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Idioma.ObtenerTexto("FormMensajes.MessageBox.ErrorGuardarMensaje"), ex.Message),
                    Idioma.ObtenerTexto("FormMensajes.MessageBox.ErrorGuardarMensajeTitulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
