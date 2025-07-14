using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace ProyetoPOO
{
    public interface IObserver
    {
        void ActualizarIdioma();
    }

    


    public static class Idioma
    {
        private static List<IObserver> ListaFormularios = new List<IObserver>();
        private static Dictionary<string, string> Diccionario = new Dictionary<string, string>();
        
        public static string idiomaActual { get; set; }
        // Observer
        public static void  Agregar(IObserver observer)
        {
            if (!ListaFormularios.Contains(observer))
                ListaFormularios.Add(observer);
        }

        public static void Quitar(IObserver observer)
        {
            if (ListaFormularios.Contains(observer))
                ListaFormularios.Remove(observer);
        }

        public static void Notificar(string idiomaActual)
        {
            CultureInfo culture;
            switch (idiomaActual)
            {
                case "Español":
                    culture = new CultureInfo("es-ES");
                    break;
                case "English":
                    culture = new CultureInfo("en-US");
                    break;
                default:
                    culture = new CultureInfo("es-ES");
                    break;
            }

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            foreach (IObserver observer in ListaFormularios)
            {
                observer.ActualizarIdioma();
            }
        }

        public static void CargarIdioma(string idiomaActual)
        {
            try
            {
                var nombreArchivo = Path.Combine("..", "..", "..", $"Idiomas\\{idiomaActual}.json");
                var jsonString = File.ReadAllText(nombreArchivo);
                Diccionario = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            }
            catch (Exception)
            {
                Diccionario = new Dictionary<string, string>();
            }
        }

        public static string ObtenerTexto(string key)
        {
            return Diccionario.ContainsKey(key) ? Diccionario[key] : key;
        }

        public static void CambiarIdiomaControles(Control frm)
        {
            try
            {
                frm.Text = ObtenerTexto(frm.Name + ".Text");

                foreach (Control c in frm.Controls)
                {
                    if (c is Button || c is Label)
                    {
                        if (c.Name != "labelAyuda")
                        {
                            c.Text = ObtenerTexto(frm.Name + "." + c.Name);
                        }
                    }

                    if (c is MenuStrip m)
                    {
                        foreach (ToolStripMenuItem item in m.Items)
                        {
                            item.Text = ObtenerTexto(frm.Name + "." + item.Name);
                            CambiarIdiomaMenuStrip(item.DropDownItems, frm);
                        }
                    }

                    if (c is Form)
                        break;

                    if (c.Controls.Count > 0)
                        CambiarIdiomaControles(c);
                }
            }
            catch (Exception) { }
        }

        private static void CambiarIdiomaMenuStrip(ToolStripItemCollection items, Control frm)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripMenuItem item1)
                {
                    item.Text = ObtenerTexto(frm.Name + "." + item.Name);
                    CambiarIdiomaMenuStrip(item1.DropDownItems, frm);
                }
            }
        }
    }
}
