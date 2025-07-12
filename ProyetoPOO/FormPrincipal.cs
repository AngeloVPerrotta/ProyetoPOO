using ProyetoPOO;
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
        private string rolUsuario;

        public string RolUsuario
        {
            get => rolUsuario;
            set
            {
                rolUsuario = value;
                AplicarPermisos(rolUsuario);

            }
        }

        private class MyMenuRenderer : ToolStripProfessionalRenderer
        {
            public MyMenuRenderer() : base(new MyColorTable()) { }
        }

        private class MyColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.DodgerBlue; } // Color de fondo cuando se selecciona el ítem
            }

            public override Color MenuItemBorder
            {
                get { return Color.Transparent; } // Color del borde cuando se selecciona el ítem
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DodgerBlue; }
            }

            

        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        public FormPrincipal()
        {
            this.IsMdiContainer = true;
            this.BackColor = Color.LightSteelBlue;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackColor = Color.LightSteelBlue; // Cambia el fondo del área MDI
                }
            }
            InitializeComponent();
            if (!string.IsNullOrEmpty(RolUsuario))
            {
                AplicarPermisos(RolUsuario);
            }
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        public string RolActual { get; set; }
        
        public void AplicarPermisos(string rol)
        {
            // Primero, ocultar todo por defecto
          

            proveedoresToolStripMenuItem.Visible = false;
            pedidosToolStripMenuItem.Visible = false;
            recepcionesToolStripMenuItem.Visible = false;
            recursosHumanosToolStripMenuItem.Visible = false;


            switch (rol.ToLower())
            {
                case "administrador":
                    
                   
                    proveedoresToolStripMenuItem.Visible = true;
                    pedidosToolStripMenuItem.Visible = true;
                    recepcionesToolStripMenuItem.Visible = true;
                    recursosHumanosToolStripMenuItem.Visible = true;
                    break;

                case "rrhh":
                    
                    recursosHumanosToolStripMenuItem.Visible = true;
                    break;

                case "usuario":
                case "compras":

                    pedidosToolStripMenuItem.Visible = true;
                    recepcionesToolStripMenuItem.Visible = true;
                    break;

                case "visitante":

                    proveedoresToolStripMenuItem.Visible = true;
                    pedidosToolStripMenuItem.Visible = true;
                    break;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); 

            FormLogin login = new FormLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                RolUsuario = login.Rol;
                AplicarPermisos(RolUsuario);
                this.Show(); 
            }
            else
            {
                
                this.Close();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormPedidos pedidos = new FormPedidos();
            pedidos.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormProveedores proveedores = new FormProveedores();
            proveedores.ShowDialog();
        }

       
        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormRRHH RRHH = new FormRRHH();
            RRHH.ShowDialog();
        }

        
        private void mensajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMensajes mensajes = new FormMensajes();
            mensajes.RolActual = this.RolUsuario;
            mensajes.ShowDialog();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
           
            label3.Text = $"Rol actual: {RolUsuario}";

        }
        

        private void recepcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRecepciones recepciones = new FormRecepciones();
            recepciones.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    

        private void recursosHumanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRRHH rrhh = new FormRRHH();
            rrhh.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
