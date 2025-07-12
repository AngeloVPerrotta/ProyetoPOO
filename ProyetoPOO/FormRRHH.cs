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

namespace UI
{
    public partial class FormRRHH : Form
    {
        public FormRRHH()
        {
            InitializeComponent();
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
                MessageBox.Show("Todos los campos son obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string contraseñaHasheada = HashMD5(contraseña);

            try
            {
                // Si el archivo no existe, lo creamos con el encabezado.
                if (!File.Exists(rutaUsuariosCsv))
                {
                    File.AppendAllText(rutaUsuariosCsv, "usuario,contraseña,rol" + Environment.NewLine);
                }

                // Revisamos si el usuario ya existe para evitar duplicados
                var existentes = File.ReadAllLines(rutaUsuariosCsv);
                foreach (string l in existentes)
                {
                    var partes = l.Split(',');
                    if (partes.Length > 0 && partes[0].Trim().Equals(usuario, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("El usuario ya existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                }

                string linea = $"{usuario},{contraseñaHasheada},{rol}";

                File.AppendAllText(rutaUsuariosCsv, linea + Environment.NewLine);
                MessageBox.Show("Usuario registrado correctamente.");

                // Limpiar campos
                txtUsuario.Clear();
                txtContraseña.Clear();
                txtRol.Clear();

                // --- RECARGAR EL DATAGRIDVIEW DESPUÉS DE AÑADIR UN USUARIO ---
                CargarUsuariosEnDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            tablaUsuarios.Columns.Add("Contraseña"); // Esta columna mostrará el placeholder
            tablaUsuarios.Columns.Add("Rol");

            dataGridViewUsuarios.DataSource = tablaUsuarios;

            // Opcional: Ajustar el ancho de las columnas
            dataGridViewUsuarios.Columns["Usuario"].Width = 100;
            dataGridViewUsuarios.Columns["Contraseña"].Width = 200; // Más ancho para el hash o placeholder
            dataGridViewUsuarios.Columns["Rol"].Width = 100;

            // Deshabilitar la edición directa en el DataGridView si no es deseado
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.AllowUserToAddRows = false; // No permitir añadir filas directamente
        }

        private void CargarUsuariosEnDataGridView()
        {
            tablaUsuarios.Rows.Clear(); // Limpia la tabla antes de recargar

            try
            {
                if (!File.Exists(rutaUsuariosCsv))
                {
                    // Si el archivo no existe, lo creamos con el encabezado.
                    // Esto es importante para que no falle al intentar leerlo.
                    File.AppendAllText(rutaUsuariosCsv, "usuario,contraseña,rol" + Environment.NewLine);
                    return; // No hay usuarios que cargar si se acaba de crear
                }

                var lineas = File.ReadAllLines(rutaUsuariosCsv).Skip(1); // Salta la cabecera

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue; // Ignora líneas vacías

                    var partes = linea.Split(','); // Asegúrate de que el separador sea la coma

                    if (partes.Length == 3)
                    {
                        string usuario = partes[0].Trim();
                        // string contraseñaHasheada = partes[1].Trim(); // No la necesitamos directamente para mostrar
                        string rol = partes[2].Trim();

                        // Añadimos el usuario, un placeholder para la contraseña, y el rol
                        tablaUsuarios.Rows.Add(usuario, "********", rol);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios en DataGridView: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            this.BackColor = Color.WhiteSmoke; // Fondo general más limpio y profesional
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Font = new Font("Segoe UI", 11); // Fuente moderna y legible
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
                ctrl.BackColor = Color.SteelBlue; // Color atractivo
                ctrl.ForeColor = Color.White;            // Texto blanco

                ctrl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            }

        }
    }
}
