using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                if (login.Rol == "usuario")
                {
                    new FormPedidos().Show();
                }

            }
        }
    }
}
