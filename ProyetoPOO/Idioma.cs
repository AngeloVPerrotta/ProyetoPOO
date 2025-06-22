using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Idioma
    {
        public string Nombre { get; set; }  // Ejemplo: "Español", "Inglés"
        private Dictionary<string, string> Textos { get; set; }

        // Constructor
        public Idioma(string nombre)
        {
            Nombre = nombre;
            Textos = new Dictionary<string, string>();
        }

        //faltan metodos 
    }
}
