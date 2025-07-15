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
using ProyetoPOO;
// Agregamos estas dos librerías para la conexión web
using System.Net.Http;
using System.Security.Cryptography;

namespace UI
{
    public partial class FormLogin : Form, IObserver

    {
        public string Usuario { get; set; }
        public string Rol { get; internal set; }

        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // Sombra
                return cp;
            }
        }
        public FormLogin()
        {
            InitializeComponent();
           

        }


        public void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            // La ruta al archivo local
            string rutaCsv = Path.Combine(Application.StartupPath, "usuario_encriptado.csv");

            string user = txt_usuario.Text.Trim();
            string pass = txt_contraseña.Text.Trim();

            // Verificación básica
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show(
            Idioma.ObtenerTexto("FormLogin.MessageBox.IngresarUsuarioContraseña"),
            Idioma.ObtenerTexto("FormLogin.MessageBox.IngresarUsuarioContraseña.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
                return;
            }

            string passHasheada = HashMD5(pass);

            try
            {
                // Verificamos si el archivo existe antes de intentar leerlo
                if (!File.Exists(rutaCsv))
                {
                    MessageBox.Show(
                 Idioma.ObtenerTexto("FormLogin.MessageBox.NoArchivoUsuarios"),
                 Idioma.ObtenerTexto("FormLogin.MessageBox.NoArchivoUsuarios.Titulo"),
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
                    return;
                }

                // Leemos todas las líneas del archivo directamente
                var lineas = File.ReadAllLines(rutaCsv).Skip(1); // Salta encabezados

                foreach (var linea in lineas)
                {
                    var partes = linea.Split(',');

                    if (partes.Length == 3)
                    {
                        string archivoUsuario = partes[0].Trim();
                        string archivoContraseña = partes[1].Trim();
                        string archivoRol = partes[2].Trim();

                        // Comparamos el usuario y la CONTRSEÑA HASHEADA
                        if (user.Equals(archivoUsuario, StringComparison.OrdinalIgnoreCase) &&
                            passHasheada.Equals(archivoContraseña, StringComparison.OrdinalIgnoreCase))
                        {
                            Usuario = user;
                            Rol = archivoRol;
                            DialogResult = DialogResult.OK;
                            return;
                        }
                    }
                }

                // Si el bucle termina sin encontrar una coincidencia
                MessageBox.Show(
            Idioma.ObtenerTexto("FormLogin.MessageBox.UsuarioContraseñaIncorrectos"),
            Idioma.ObtenerTexto("FormLogin.MessageBox.UsuarioContraseñaIncorrectos.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
            string.Format(Idioma.ObtenerTexto("FormLogin.MessageBox.ErrorLeerArchivoUsuarios"), ex.Message),
            Idioma.ObtenerTexto("FormLogin.MessageBox.ErrorLeerArchivoUsuarios.Titulo"),
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Idioma.CargarIdioma(Idioma.idiomaActual);
            Idioma.Notificar(Idioma.idiomaActual);
        }

        public void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
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
    }
}