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
    public partial class FormMensajes : Form
    {
        public string RolActual { get; set; }

        public FormMensajes()
        {
            InitializeComponent();
            string rutaUsuarios = "usuarios.txt";
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
        
        public void FormMensajes_Load(object sender, EventArgs e)
        {
            lblRemitente.Text = "USUARIO ACTUAL: " + RolActual;
            string rolDestino = cmbDestinatarioRol.Text.Trim();
            string contenido = txtMensaje.Text.Trim();

            if (string.IsNullOrEmpty(rolDestino) || string.IsNullOrEmpty(contenido))
            {
                //MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rolDestino == RolActual)
            {
                MessageBox.Show("No puede enviarse un mensaje a su propio rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaMensajes = "mensajes.txt";
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string linea = $"{rolDestino};{RolActual};{fecha};{contenido}";

            try
            {
                File.AppendAllText(rutaMensajes, linea + Environment.NewLine);
                MessageBox.Show("Mensaje enviado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMensaje.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el mensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void VerMensajes()
        {
            string rutaMensajes = "mensajes.txt";

            if (!File.Exists(rutaMensajes))
            {
                MessageBox.Show("No hay mensajes registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var mensajes = File.ReadAllLines(rutaMensajes)
                .Where(l => l.StartsWith(RolActual + ";"))  // filtro por rol destino
                .Select(l => l.Split(';'))
                .Select(p => $"De: {p[1]} - Fecha: {p[2]}\n{p[3]}")
                .ToList();

            if (mensajes.Count == 0)
            {
                MessageBox.Show("No hay mensajes nuevos para su rol.", "Mensajes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string texto = string.Join("\n\n------------------------\n\n", mensajes);
                MessageBox.Show(texto, "Mensajes recibidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
