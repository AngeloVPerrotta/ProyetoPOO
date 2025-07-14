using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace ProyetoPOO
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin login = new FormLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Idioma.idiomaActual = ("Español");
                Idioma.CargarIdioma(Idioma.idiomaActual);
                Idioma.Notificar(Idioma.idiomaActual);

                FormPrincipal principal = new FormPrincipal();



                principal.RolUsuario = login.Rol;
                principal.AplicarPermisos(login.Rol);
                Application.Run(principal);

            }
            else
            {
                // Si no se loguea, cierra la app
                Application.Exit();
            }




        }
    }
}
