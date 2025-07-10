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

namespace UI
{
    public partial class FormLogin : Form
    {
        public string Usuario { get; set; }
        public string Rol { get; internal set; }

        public FormLogin()
        {
            InitializeComponent();
        }


        public void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            string rutaCSV = "usuario.csv"; // puede ser ruta completa si está en otro lugar

            if (!File.Exists(rutaCSV))
            {
                MessageBox.Show("No se encontró el archivo de usuarios.");
                return;
            }

            string user = txt_usuario.Text.Trim();
            string pass = txt_contraseña.Text.Trim();
            
            var lineas = File.ReadAllLines(rutaCSV).Skip(1); // Salta la cabecera

            foreach (var linea in lineas)
            { 
                var partes = linea.Split(',');

                if (partes.Length == 3)
                {
                    string archivoUsuario = partes[0];
                    string archivoContraseña = partes[1];
                    string archivoRol = partes[2];

                    if (user == archivoUsuario && pass == archivoContraseña)
                    {
                        Usuario = user;
                        Rol = archivoRol;
                        DialogResult = DialogResult.OK;
                        return;
                    }
                }


            }
            // ❌ Login fallido
            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //No sirve
            string rutaOriginal = "usuarios.csv";
            string rutaEncriptada = "usuario_encriptado.csv";
            EncriptadorUsuarios.EncriptarArchivoUsuarios(rutaOriginal, rutaEncriptada);
        }
    }
}