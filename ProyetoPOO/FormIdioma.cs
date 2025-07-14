using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyetoPOO
{
    public partial class FormIdioma : Form, IObserver
    {
        public FormIdioma()
        {
            InitializeComponent();
        }

        public void ActualizarIdioma()
        {
            Idioma.CambiarIdiomaControles(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idiomaSeleccionado = comboBox1.SelectedItem.ToString();
            Idioma.CargarIdioma(idiomaSeleccionado);
            Idioma.Notificar(idiomaSeleccionado);
        }

        private void FormIdioma_Load(object sender, EventArgs e)
        
       {
            Idioma.Agregar(this);

            Idioma.Notificar("Español");
        }

        private void Cambiar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string idiomaSeleccionado = comboBox1.SelectedItem.ToString();
                Idioma.CargarIdioma(idiomaSeleccionado);
                Idioma.Notificar(idiomaSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un idioma.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
