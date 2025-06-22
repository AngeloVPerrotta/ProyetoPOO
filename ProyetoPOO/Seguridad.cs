using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Seguridad
    {
        public string PoliticaContrasenas { get; set; } // Ejemplo: "Mínimo 6 caracteres, una mayúscula, un número"
        public int IntentosPermitidos { get; set; }
        private Dictionary<string, int> intentosFallidos; // clave: usuario, valor: intentos

        // Constructor
        public Seguridad(string politica, int intentosPermitidos)
        {
            PoliticaContrasenas = politica;
            IntentosPermitidos = intentosPermitidos;
            intentosFallidos = new Dictionary<string, int>();
        }

        //faltarían los metodos
    }
}
