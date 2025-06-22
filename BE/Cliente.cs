using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Cliente : Persona
    {
        public string DocumentoIdentidad { get; set; }
        public string TipoCliente { get; set; } // Por ejemplo: "Mayorista", "Minorista", "Interno"
        public string Referencia { get; set; }  // AUX Para guardar datos adicionales


        public Cliente(int id, string nombre, string apellidos, string datosContacto,
                       string documentoIdentidad, string tipoCliente, string referencia)
            : base(id, nombre, apellidos, datosContacto)
        {
            DocumentoIdentidad = documentoIdentidad;
            TipoCliente = tipoCliente;
            Referencia = referencia;
        }
    }

}
