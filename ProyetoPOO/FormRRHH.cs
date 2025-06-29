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
    public partial class FormRRHH : Form
    {
        public FormRRHH()
        {
            InitializeComponent();
        }

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

            string ruta = "C:\\Users\\perro\\Desktop\\PROGRAMACION\\ProyectoPOOTEST\\DAL\\usuario.csv";


            string linea = $"{usuario};{contraseña};{rol}";

            try
            {

                if (File.Exists(ruta))
                {
                    var existentes = File.ReadAllLines(ruta);
                    foreach (string l in existentes)
                    {
                        var partes = l.Split(';');
                        if (partes[0] == usuario)
                        {
                            MessageBox.Show("El usuario ya existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return;
                        }
                    }
                }


                File.AppendAllText(ruta, linea + Environment.NewLine);
                MessageBox.Show("Usuario registrado correctamente.");


                txtUsuario.Clear();
                txtContraseña.Clear();
                txtRol.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
