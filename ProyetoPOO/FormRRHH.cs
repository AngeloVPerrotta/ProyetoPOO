using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; // Necesario para DataTable
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography; // Necesario para MD5
using ProyetoPOO;

namespace UI
{
    public partial class FormRRHH : Form, IObserver
    {
        public FormRRHH()
        {
         InitializeComponent();
        }

        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);
        }

        private DataTable tablaUsuarios;
        private string rutaUsuariosCsv = Path.Combine(Application.StartupPath, "usuario_encriptado.csv");
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string rol = txtRol.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(rol))
            {
                MessageBox.Show(
            Idioma.ObtenerTexto("FormRRHH.MessageBox.CamposObligatorios"),
            Idioma.ObtenerTexto("FormRRHH.MessageBox.CamposObligatorios.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
                return;
            }

            string contraseñaHasheada = HashMD5(contraseña);

            try
            {
                if (!File.Exists(rutaUsuariosCsv))
                {
                    File.AppendAllText(rutaUsuariosCsv, "usuario,contraseña,rol" + Environment.NewLine);
                }

                var existentes = File.ReadAllLines(rutaUsuariosCsv);
                foreach (string l in existentes)
                {
                    var partes = l.Split(',');
                    if (partes.Length > 0 && partes[0].Trim().Equals(usuario, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(
                    Idioma.ObtenerTexto("FormRRHH.MessageBox.UsuarioExiste"),
                    Idioma.ObtenerTexto("FormRRHH.MessageBox.UsuarioExiste.Titulo"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                        return;
                    }
                }

                string linea = $"{usuario},{contraseñaHasheada},{rol}";

                File.AppendAllText(rutaUsuariosCsv, linea + Environment.NewLine);
                MessageBox.Show(
            Idioma.ObtenerTexto("FormRRHH.MessageBox.UsuarioRegistrado"),
            Idioma.ObtenerTexto("FormRRHH.MessageBox.UsuarioRegistrado.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

                txtUsuario.Clear();
                txtContraseña.Clear();
                txtRol.Clear();

                CargarUsuariosEnDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
            string.Format(Idioma.ObtenerTexto("FormRRHH.MessageBox.ErrorGuardarUsuario"), ex.Message),
            Idioma.ObtenerTexto("FormRRHH.MessageBox.ErrorGuardarUsuario.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
        }


        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        private void InicializarDataGridView()
        {
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tablaUsuarios = new DataTable();
            tablaUsuarios.Columns.Add("Usuario");
            tablaUsuarios.Columns.Add("Contraseña"); 
            tablaUsuarios.Columns.Add("Rol");

            dataGridViewUsuarios.DataSource = tablaUsuarios;

            // Opcional: Ajustar el ancho de las columnas
            dataGridViewUsuarios.Columns["Usuario"].Width = 100;
            dataGridViewUsuarios.Columns["Contraseña"].Width = 200; 
            dataGridViewUsuarios.Columns["Rol"].Width = 100;

            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.AllowUserToAddRows = false; 
        }

        private void CargarUsuariosEnDataGridView()
        {
            tablaUsuarios.Rows.Clear(); 

            try
            {
                if (!File.Exists(rutaUsuariosCsv))
                {
                    File.AppendAllText(rutaUsuariosCsv, "usuario,contraseña,rol" + Environment.NewLine);
                    return; 
                }

                var lineas = File.ReadAllLines(rutaUsuariosCsv).Skip(1); 

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue; 

                    var partes = linea.Split(','); 

                    if (partes.Length == 3)
                    {
                        string usuario = partes[0].Trim();
                         string rol = partes[2].Trim();

                        tablaUsuarios.Rows.Add(usuario, "********", rol);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
           string.Format(Idioma.ObtenerTexto("FormRRHH.MessageBox.ErrorCargarUsuarios"), ex.Message),
           Idioma.ObtenerTexto("FormRRHH.MessageBox.ErrorCargarUsuarios.Titulo"),
           MessageBoxButtons.OK,
           MessageBoxIcon.Error);
            }
        }

        private string HashMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void FormRRHH_Load(object sender, EventArgs e)
        {
            InicializarDataGridView();
            CargarUsuariosEnDataGridView();

            Idioma.Agregar(this); ;
            Idioma.Notificar(Idioma.idiomaActual);

            this.BackColor = Color.WhiteSmoke; 
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Font = new Font("Segoe UI", 11); 
            }
            if (this.Controls.OfType<DataGridView>().Any())
            {
                var dgv = this.Controls.OfType<DataGridView>().First();
                dgv.BackgroundColor = Color.White;
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                dgv.EnableHeadersVisualStyles = false;
                dgv.GridColor = Color.LightGray;
            }

            foreach (Control ctrl in this.Controls.OfType<Button>())
            {
                ctrl.BackColor = Color.SteelBlue; 
                ctrl.ForeColor = Color.White;          

                ctrl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            }

        }
    }
}
