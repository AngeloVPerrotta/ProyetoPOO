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
            string rutaCSV = @"C:\Users\perro\Desktop\PROGRAMACION\ProyectoPOOTEST\DAL\usuario.csv";

            if (!File.Exists(rutaCSV))
            {
                MessageBox.Show("No se encontró el archivo de usuarios.");
                return;
            }

            string user = txt_usuario.Text.Trim();
            string pass = txt_contraseña.Text.Trim();

            var lineas = File.ReadAllLines(rutaCSV).Skip(1);

            foreach (var linea in lineas)
            {
                var partes = linea.Split(',');

                if (partes.Length == 3)
                {
                    string archivoUsuario = partes[0].Trim();
                    string archivoContraseña = partes[1].Trim();
                    string archivoRol = partes[2].Trim().ToLower();

                    if (user == archivoUsuario && pass == archivoContraseña)
                    {
                        Usuario = user;
                        Rol = archivoRol;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                }
            }

            MessageBox.Show("Usuario o contraseña incorrectos.");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}